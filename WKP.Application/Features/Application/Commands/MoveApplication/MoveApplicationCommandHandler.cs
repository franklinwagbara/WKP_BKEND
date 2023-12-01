using ErrorOr;
using MediatR;
using WKP.Application.Application.Common;
using WKP.Application.Common.Interfaces;
using WKP.Domain.Entities;
using WKP.Domain.Enums_Contants;
using WKP.Domain.Repositories;

namespace WKP.Application.Features.Application.Commands.MoveApplication
{
    public class MoveApplicationCommandHandler : IRequestHandler<MoveApplicationCommand, ErrorOr<ApplicationResult>>
    {
        private IUnitOfWork _unitOfWork;
        private IStaffNotifier _notifyStaff;
        public MoveApplicationCommandHandler(IUnitOfWork unitOfWork, IStaffNotifier staffNotifier)
        {
            _unitOfWork = unitOfWork;
            _notifyStaff = staffNotifier;
        }

        public async Task<ErrorOr<ApplicationResult>> Handle(MoveApplicationCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if(request.SelectedApps == null || request.SelectedApps.Length == 0)
                    return Error.Failure(code: ErrorCodes.InternalFailure, description: "Error: No application ID was passed for this action to be completed.");


                foreach(var sApp in request.SelectedApps)
                {
                    string tempId = sApp.Replace('[', ' ').Replace(']', ' ').Trim();
                    int appId = int.Parse(tempId);

                    if(request.SourceStaffID == 0 || request.TargetStaffID == 0 || appId == 0)
                            return Error.Failure(code: ErrorCodes.InternalFailure, description: "An error occured while trying to get process flow for this application. Make sure that source and target staffIDs are valid including appId");
                    
                    var sourceStaff = await _unitOfWork.StaffRepository.GetStaffByIdWithSBURole(request.SourceStaffID);
                    var targetStaff = await _unitOfWork.StaffRepository.GetStaffByIdWithSBURole(request.TargetStaffID);
                    var sourceStaffDesk = await _unitOfWork.DeskRepository.GetDeskByStaffIdAppIdWithStaff(request.SourceStaffID, appId);
                    var targetStaffDesk = await _unitOfWork.DeskRepository.GetDeskByStaffIdAppIdWithStaff(request.TargetStaffID, appId);
                    var app = await _unitOfWork.ApplicationRepository.GetAppByIdWithAll(appId);

                    if(sourceStaff.Role.RoleId == ROLEID.Accountant)
                    {
                        await MoveAccDesk(sourceStaff, targetStaff, app);
                        return new ApplicationResult(request);
                    }

                    if(sourceStaff == null || targetStaff == null || sourceStaffDesk == null || app == null)
                        return Error.Failure(code: ErrorCodes.InternalFailure, description: "An error occured while trying to get process flow for this application. Make sure that source and appId are valid.");
                    
                    if(sourceStaff.Staff_SBU != targetStaff.Staff_SBU && sourceStaff.RoleID == targetStaff.RoleID)
                        return Error.Failure(code: ErrorCodes.InternalFailure, description: "An error occured while trying to get process flow for this application. Source Staff's SBU and Role must match the Target Staff's.");

                    await _unitOfWork.ExecuteTransaction(async () =>
                    {
                        await CreateOrUpdateDesk(request, appId, sourceStaffDesk, targetStaffDesk);
                        await _unitOfWork.SaveChangesAsync();
                        await _unitOfWork.DeskRepository.DeleteAsync(sourceStaffDesk);

                        _notifyStaff.Init(targetStaff, app, app.Concession, app.Field);
                        await _notifyStaff.SendMoveNotification();

                        _notifyStaff.Init(sourceStaff, app, app.Concession, app.Field);
                        await _notifyStaff.SendMoveNotification(true);
                    });
                }
                return new ApplicationResult(request);
            }
            catch (Exception e)
            {
                return Error.Failure(code: ErrorCodes.InternalFailure, description: e.Message);
            }
        }

        private async Task MoveAccDesk(staff sourceStaff, staff? targetStaff, Domain.Entities.Application? app)
        {
            if(targetStaff == null) throw new Exception("Target Staff can not be null.");

            var sourceDesk = await _unitOfWork.AccountDeskRepository.GetAsync((a) => a.StaffID == sourceStaff.StaffID && a.AppId == app.Id, null);
            
            if(sourceDesk == null) throw new Exception("No source desk for the specified staff and app id.");

            //check if app already exist on targets desk
            var foundDesk = await _unitOfWork.AccountDeskRepository.GetAsync((a) => a.StaffID == targetStaff.StaffID && a.AppId == app.Id, null);

            if(foundDesk != null) throw new Exception("Desk already exists for this staff.");

            await _unitOfWork.ExecuteTransaction(async () => 
            {
                var newDesk = new AccountDesk
                {
                    ProcessID = sourceDesk.ProcessID,
                    AppId = sourceDesk.AppId,
                    CreatedAt = sourceDesk.CreatedAt,
                    UpdatedAt = DateTime.Now,
                    Comment = sourceDesk.Comment,
                    LastJobDate = sourceDesk.LastJobDate,
                    ProcessStatus = sourceDesk.ProcessStatus,
                    StaffID = targetStaff.StaffID,
                    PaymentId = sourceDesk.PaymentId,
                    isApproved = sourceDesk.isApproved
                };

                await _unitOfWork.AccountDeskRepository.AddAsync(newDesk);
                //delete desk from source
                await _unitOfWork.AccountDeskRepository.DeleteAsync(sourceDesk);

                _notifyStaff.Init(targetStaff, app, app.Concession, app.Field);
                        await _notifyStaff.SendMoveNotification();

                _notifyStaff.Init(sourceStaff, app, app.Concession, app.Field);
                await _notifyStaff.SendMoveNotification(true);
            });
        }

        private async Task CreateOrUpdateDesk(MoveApplicationCommand request, int appId, MyDesk sourceStaffDesk, MyDesk? targetStaffDesk)
        {
            if (targetStaffDesk == null)
            {
                var desk = new MyDesk
                {
                    //save staff desk
                    StaffID = request.TargetStaffID,
                    FromRoleId = sourceStaffDesk.FromRoleId,
                    FromSBU = sourceStaffDesk.FromSBU,
                    FromStaffID = sourceStaffDesk.FromStaffID,
                    //ProcessID = processFlow.ProccessID,
                    AppId = appId,
                    HasPushed = false,
                    HasWork = true,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    Comment = sourceStaffDesk.Comment,
                    LastJobDate = DateTime.Now,
                    ProcessStatus = sourceStaffDesk.ProcessStatus,
                };

                await _unitOfWork.DeskRepository.AddAsync(desk);
            }
            else
            {
                targetStaffDesk.StaffID = request.TargetStaffID;
                targetStaffDesk.FromRoleId = sourceStaffDesk.FromRoleId;
                targetStaffDesk.FromSBU = sourceStaffDesk.FromSBU;
                targetStaffDesk.FromStaffID = sourceStaffDesk.FromStaffID;
                targetStaffDesk.AppId = appId;
                targetStaffDesk.HasWork = true;
                targetStaffDesk.UpdatedAt = DateTime.Now;
                targetStaffDesk.Comment = sourceStaffDesk.Comment;
                targetStaffDesk.ProcessStatus = sourceStaffDesk.ProcessStatus;
                targetStaffDesk.LastJobDate = DateTime.Now;

                await _unitOfWork.DeskRepository.Update(targetStaffDesk);
            }
        }
    }
}