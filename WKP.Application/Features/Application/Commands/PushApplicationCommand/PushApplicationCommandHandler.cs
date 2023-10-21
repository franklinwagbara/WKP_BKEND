using System.Text.Json;
using ErrorOr;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WKP.Application.Application.Common;
using WKP.Application.Common.Interfaces;
using WKP.Application.Features.Common;
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
        private readonly IStaffNotifier _staffNotifier;
        private readonly AppStatusHelper _appStatusHelper;

            string exPath = "";


        public PushApplicationCommandHandler(IUnitOfWork unitOfWork, Helper helper, IStaffNotifier staffNotifier, AppStatusHelper appStatusHelper)
        {
            _unitOfWork = unitOfWork;
            _helper = helper;
            _staffNotifier = staffNotifier;
            _appStatusHelper = appStatusHelper;
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
                                    await PushAppToNextDesk(request, staffDesk, app, appFlow);
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
                                    await PushAppFromECToNexDesk(request, actingStaff, staffDesk, app, appFlow);
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
                return Error.Failure(code: ErrorCodes.InternalFailure, description: exPath + ex.Message + ex.StackTrace?.ToString());
            }
        }

        private async Task PushAppFromECToNexDesk(PushApplicationCommand request, staff actingStaff, MyDesk staffDesk, Domain.Entities.Application? app, ApplicationProccess appFlow)
        {

            var targetRoles_SBUs = await _unitOfWork.StaffRepository.GetStaffIdsByRoleSBU(appFlow.TargetedToRole, appFlow.TargetedToSBU);
            var deskTemp = await _helper.GetNextStaffDesk_EC(targetRoles_SBUs.ToList(), app.Id);

            exPath += " 1 ";

            if (deskTemp.DeskID != -1)
            {
                exPath += " 2 ";
                await UpdateDesk(request.Comment, app.Id, staffDesk.StaffID, appFlow, deskTemp, DESK_PROCESS_STATUS.FinalAuthorityApproved);
                exPath += " 3 ";
            }
            else
            {
                exPath += " 4 // " + JsonSerializer.Serialize(deskTemp) + " // ";
                deskTemp = await _unitOfWork.DeskRepository.GetDeskByStaffIdAppIdWithStaff(deskTemp.StaffID, deskTemp.AppId, true);
                exPath += " 5 ";
            }

            await _helper.UpdateDeskAfterPush(staffDesk, request.Comment, DESK_PROCESS_STATUS.Pushed);
            await _helper.SaveApplicationHistory(app.Id, staffDesk.StaffID, APPLICATION_HISTORY_STATUS.FinalAuthorityApproved, request.Comment, null, false, null, APPLICATION_ACTION.Approve);

                exPath += " 6 // " + JsonSerializer.Serialize(deskTemp) + " // " ;

            //Update Final Authority Approvals Table
            await _helper.UpdateApprovalTable(app.Id, request.Comment, staffDesk.StaffID, (int)staffDesk.Staff.Staff_SBU, staffDesk.DeskID, APPLICATION_HISTORY_STATUS.FinalAuthorityApproved);

                exPath += " 7 ";
            
            //Sending notifications to Actor Staff
            _staffNotifier.Init(actingStaff, app, app.Concession, app.Field);
            await _staffNotifier.SendApprovalNotification();

                exPath += " 8 ";


            //Sending notifications to Receiver Staff
            var recStaff = await _unitOfWork.StaffRepository.GetStaffByIdWithSBU(deskTemp.StaffID);

                exPath += " 9 ";

            if (recStaff != null)
            {
                _staffNotifier.Init(recStaff, app, app.Concession, app.Field);
                await _staffNotifier.SendPushNotification();
            }

                exPath += " 10 ";

            await _appStatusHelper.UpdateAppStatus(app, deskTemp, recStaff, DESK_PROCESS_STATUS.SubmittedByStaff);

                exPath += " 11 ";
        }

        private async Task PushAppToNextDesk(PushApplicationCommand request, MyDesk staffDesk, Domain.Entities.Application? app, ApplicationProccess appFlow)
        {
            var targetRoles_SBUs = await _unitOfWork.StaffRepository.GetStaffIdsByRoleSBU(appFlow.TargetedToRole, appFlow.TargetedToSBU);
            var deskTemp = await _helper.GetNextStaffDesk(targetRoles_SBUs.ToList(), app.Id);

            if (deskTemp != null)
                await UpdateDesk(request.Comment, app.Id, staffDesk.StaffID, appFlow, deskTemp, DESK_PROCESS_STATUS.SubmittedByStaff);
            else
            {
                MyDesk desk = await CreateNewDesk(request.Comment, app.Id, staffDesk, appFlow, deskTemp);
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

            await _appStatusHelper.UpdateAppStatus(app, deskTemp, recStaff, DESK_PROCESS_STATUS.SubmittedByStaff);
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