using ErrorOr;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WKP.Application.Application.Common;
using WKP.Application.Common.Interfaces;
using WKP.Domain.Entities;
using WKP.Domain.Enums_Contants;
using WKP.Domain.Repositories;
using WKP.Infrastructure.GeneralServices.Interfaces;

namespace WKP.Application.Application.Commands.PushApplicationCommand
{
    public class PushApplicationCommandHandler : IRequestHandler<PushApplicationCommand, ErrorOr<ApplicationResult>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly Helper _helper;
        private readonly IEmailAuditMessage _emailAuditMessage;
        private readonly IStaffNotifier _staffNotifier;

        public PushApplicationCommandHandler(IUnitOfWork unitOfWork, Helper helper, IEmailAuditMessage emailAuditMessage, IStaffNotifier staffNotifier)
        {
            _unitOfWork = unitOfWork;
            _helper = helper;
            _emailAuditMessage = emailAuditMessage;
            _staffNotifier = staffNotifier;
        }
        public async Task<ErrorOr<ApplicationResult>> Handle(PushApplicationCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var actingStaff = await _unitOfWork.StaffRepository.GetStaffByDeskId(request.DeskId);

                if(actingStaff is null)
                    return Error.NotFound(code: ErrorCodes.NotFound, description: $"Staff for Desk Id {request.DeskId} not found.");
        
                var actingStaffRole = await _unitOfWork.RoleRepository.GetAsync((r) => r.id == actingStaff.RoleID, null);

                if(actingStaffRole is null)
                    return Error.NotFound(code: ErrorCodes.NotFound, description:  $"Role for Id {actingStaff.RoleID} not found.");

                if(request.SelectedApps is not null)
                {
                    foreach(var sApp in request.SelectedApps)
                    {
                        int appId = int.Parse(sApp.Replace('[', ' ').Replace(']', ' ').Trim());
                        var staffDesk = await _unitOfWork.DeskRepository.GetDeskByDeskIdAppIdWithStaff(request.DeskId, appId);
                        var app = await _unitOfWork.ApplicationRepository.GetAppByIdWithAll(appId);

                        var appFlows = await _unitOfWork.AppProcessFlowRepo
                                .GetAppProcessFlowBySBU_Role_Action(PROCESS_CONSTANTS.Push, 
                                (int)staffDesk.Staff.RoleID, (int)staffDesk.Staff.Staff_SBU);
                        
                        var appFlowECs = await _unitOfWork.AppProcessFlowRepo
                                .GetAppProcessFlowBySBU_Role_Action(PROCESS_CONSTANTS.ApprovedByEC, 
                                (int)staffDesk.Staff.RoleID, (int)staffDesk.Staff.Staff_SBU);

                        if (appFlows.Count() > 0)
                        {
                            foreach (var appFlow in appFlows)
                            {
                                await _unitOfWork.ExecuteTransaction(async () =>
                                {
                                    var targetRoles_SBUs = await _unitOfWork.StaffRepository.GetStaffIdsByRoleSBU(appFlow.TargetedToRole, appFlow.TargetedToSBU);
                                    var deskTemp = await _helper.GetNextStaffDesk(targetRoles_SBUs.ToList(), appId);

                                    if (deskTemp != null)
                                        await UpdateDesk(request.Comment, appId, staffDesk.StaffID, appFlow, deskTemp, DESK_PROCESS_STATUS.SubmittedByStaff);
                                    else
                                    {
                                        MyDesk desk = await CreateNewDesk(request.Comment, appId, staffDesk, appFlow, deskTemp);
                                        deskTemp = desk;
                                    }

                                    await _helper.UpdateDeskAfterPush(staffDesk, request.Comment, DESK_PROCESS_STATUS.Pushed);
                                    await _helper.SaveApplicationHistory(app.Id, staffDesk.Staff.StaffID, DESK_PROCESS_STATUS.Pushed, request.Comment, null, false, null, PROCESS_CONSTANTS.Push);

                                    //Sending notifications to Actor Staff
                                    _staffNotifier.Init(staffDesk.Staff, app, app.Concession, app.Field);
                                    await _staffNotifier.SendPushNotification();

                                    //Sending notifications to Receiver Staff
                                    var recStaff = await _unitOfWork.StaffRepository.GetStaffByIdWithSBU(deskTemp.StaffID);

                                    if (recStaff != null)
                                    {
                                        _staffNotifier.Init(recStaff, app, app.Concession, app.Field);
                                        await _staffNotifier.SendPushNotification();
                                    }

                                    await UpdateAppStatus(app, deskTemp, recStaff, DESK_PROCESS_STATUS.SubmittedByStaff);
                                });

                                return new ApplicationResult(null, $"Application for concession {app.Concession.Concession_Held} has been pushed successfully.");
                            }
                        }
                        else if (appFlowECs.Count() > 0)
                        {
                            foreach (var appFlow in appFlowECs)
                            {
                                await _unitOfWork.ExecuteTransaction(async () =>
                                {
                                    var targetRoles_SBUs = await _unitOfWork.StaffRepository.GetStaffIdsByRoleSBU(appFlow.TargetedToRole, appFlow.TargetedToSBU);
                                    var deskTemp = await _helper.GetNextStaffDesk_EC(targetRoles_SBUs.ToList(), appId);

                                    if (deskTemp.DeskID != -1)
                                        await UpdateDesk(request.Comment, appId, staffDesk.StaffID, appFlow, deskTemp, DESK_PROCESS_STATUS.FinalAuthorityApproved);
                                    else
                                        deskTemp = await _unitOfWork.DeskRepository.GetDeskByStaffIdAppIdWithStaff(deskTemp.StaffID, deskTemp.AppId, true);

                                    await _helper.UpdateDeskAfterPush(staffDesk, request.Comment, DESK_PROCESS_STATUS.Pushed);
                                    _helper.SaveApplicationHistory(appId, staffDesk.StaffID, APPLICATION_HISTORY_STATUS.FinalAuthorityApproved, request.Comment, null, false, null, APPLICATION_ACTION.Approve);

                                    //Update Final Authority Approvals Table
                                    await _helper.UpdateApprovalTable(appId, request.Comment, staffDesk.StaffID, (int)staffDesk.Staff.Staff_SBU, staffDesk.DeskID, APPLICATION_HISTORY_STATUS.FinalAuthorityApproved);

                                    //Sending notifications to Actor Staff
                                    _staffNotifier.Init(actingStaff, app, app.Concession, app.Field);
                                    await _staffNotifier.SendApprovalNotification();

                                    //Sending notifications to Receiver Staff
                                    var recStaff = await _unitOfWork.StaffRepository.GetStaffByIdWithSBU(deskTemp.StaffID);

                                    if (recStaff != null)
                                    {
                                        _staffNotifier.Init(recStaff, app, app.Concession, app.Field);
                                        await _staffNotifier.SendPushNotification();
                                    }

                                    await UpdateAppStatus(app, deskTemp, recStaff, DESK_PROCESS_STATUS.SubmittedByStaff);
                                });

                                return new ApplicationResult(null, $"Application for concession {app.Concession.Concession_Held} has been approved by Final Authority successfully.");
                            }
                        }
                        else
                        {
                            return Error.Failure(code: ErrorCodes.InternalFailure, description: "An error occured while trying to get process flow for this application.");
                        }
                        
                    }

                    return Error.Failure(code: ErrorCodes.InternalFailure, description: "Something went wrong while processing your request.");
                }
                else
                    return Error.Validation(code: ErrorCodes.InvalidParameterPassed, description: "SelectApps can not be null.");
            }
            catch (Exception ex) 
            {
                return Error.Failure(code: ErrorCodes.InternalFailure, description: ex.Message);
            }
        }

        private async Task UpdateAppStatus(Domain.Entities.Application app, MyDesk desk, staff staff, string InternalStatus)
        {
            if(app is null || app.Id is 0)
                throw new Exception("AppId can not be null.");
            
            var appStatus = await _unitOfWork.AppStatusRepository.GetByAppIdSBUId(app.Id, (int)staff.Staff_SBU);
            if (appStatus != null)
            {
                appStatus.InternalStatus = InternalStatus;
                appStatus.DeskId = desk != null? desk.DeskID: 0;
                appStatus.UpdatedAt = DateTime.Now;
                await _unitOfWork.AppStatusRepository.Update(appStatus);
            }
            else
            {
                var newStatus = new AppStatus
                {
                    AppId = app.Id,
                    CompanyId = app.CompanyID,
                    FieldId = app.FieldID ?? null,
                    ConcessionId = app.ConcessionID ?? throw new Exception("Concession cannot be null."),
                    SBUId = staff.Staff_SBU,
                    DeskId = desk != null? desk.DeskID: 0,
                    Status = app.Status,
                    InternalStatus = InternalStatus
                };
                await _unitOfWork.AppStatusRepository.AddAsync(newStatus);
            }
        }

        private async Task<MyDesk> CreateNewDesk(string Comment, int appId, MyDesk? staffDesk, ApplicationProccess appFlow, MyDesk? deskTemp)
        {
            var desk = new MyDesk
            {
                //save staff desk
                StaffID = deskTemp.StaffID,
                FromRoleId = appFlow.TriggeredByRole,
                FromSBU = (int)appFlow.TriggeredBySBU,
                FromStaffID = staffDesk.Staff.StaffID,
                ProcessID = appFlow.ProccessID,
                AppId = appId,
                HasPushed = false,
                HasWork = true,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Comment = Comment,
                LastJobDate = DateTime.Now,
                ProcessStatus = DESK_PROCESS_STATUS.SubmittedByStaff,
            };

            await _unitOfWork.DeskRepository.AddAsync(desk);
            return desk;
        }

        private async Task UpdateDesk(string Comment, int appId, int FromStaffID, ApplicationProccess appFlow, MyDesk? deskTemp, string Status)
        {
            deskTemp.FromRoleId = appFlow.TriggeredByRole;
            deskTemp.FromSBU = (int)appFlow.TriggeredBySBU;
            deskTemp.FromStaffID = FromStaffID;
            deskTemp.ProcessID = appFlow.ProccessID;
            deskTemp.AppId = appId;
            deskTemp.HasPushed = false;
            deskTemp.HasWork = true;
            deskTemp.CreatedAt = DateTime.Now;
            deskTemp.UpdatedAt = DateTime.Now;
            deskTemp.Comment = Comment;
            deskTemp.LastJobDate = DateTime.Now;
            deskTemp.ProcessStatus = Status;

            await _unitOfWork.DeskRepository.Update(deskTemp);
        }
    }
}