using ErrorOr;
using MediatR;
using WKP.Application.Application.Common;
using WKP.Application.Common.Interfaces;
using WKP.Domain.Entities;
using WKP.Domain.Enums_Contants;
using WKP.Domain.Repositories;

namespace WKP.Application.Features.Application.Commands.ReturnAppToStaff
{
    public class ReturnAppToStaffCommandHandler : IRequestHandler<ReturnAppToStaffCommand, ErrorOr<ApplicationResult>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly Helper _helper;
        private readonly IStaffNotifier _staffNotifier;

        public ReturnAppToStaffCommandHandler(IUnitOfWork unitOfWork, Helper helper, IStaffNotifier staffNotifier)
        {
            _unitOfWork = unitOfWork;
            _helper = helper;
            _staffNotifier = staffNotifier;
        }

        public async Task<ErrorOr<ApplicationResult>> Handle(ReturnAppToStaffCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if(request.SelectedApps is not null)
                {
                    foreach(var SA in request.SelectedApps)
                    {
                        int appId = SA;
                        var staffActing = await _unitOfWork.StaffRepository.GetStaffByCompanyNumber(request.CompanyId);
                        var staffDesk = await _unitOfWork.DeskRepository.GetDeskByDeskIdAppIdWithStaff(request.DeskID, appId);
                        var app = await _unitOfWork.ApplicationRepository.GetAppByIdWithAll(appId);
                        var returnedTables = await _helper.getTableNames(request.SelectedTables);

                        if(request.FromWPAReviewer is not true)
                        {
                            await _unitOfWork.ExecuteTransaction(async () => 
                            {
                                await ReturnAppBackToStaff(staffActing, staffDesk, app, request.Comment, returnedTables);

                                //Send notification to both parties
                                //Notify Source Staff
                                _staffNotifier.Init(staffActing, app, app.Concession, app.Field);
                                await _staffNotifier.SendReturnNotification();

                                //Notify Target Staff
                                var targetStaff = await _unitOfWork.StaffRepository
                                                .GetStaffByIdWithSBU((int)staffDesk.FromStaffID);
                                _staffNotifier.Init(targetStaff, app, app.Concession, app.Field);
                            });
                            
                            return new ApplicationResult(null, $"The Application {app.Concession.Concession_Held} has been returned to staff.");
                        }
                        else
                        {
                            return await ReturnAppToStaffFromWPAReviewer(staffDesk, app, request.SBU_IDs, request.Comment, returnedTables);
                        }
                    }
                }
                else
                    return Error.Failure(code: ErrorCodes.InternalFailure, description: "Error: No action was carried out on this application.");
                
                return Error.Failure(code: ErrorCodes.InternalFailure, description: "Error: No action was carried out on this application.");
            }
            catch (Exception e)
            {
                return Error.Failure(code: ErrorCodes.InternalFailure, description: e.Message);
            }
        }

        private async Task ReturnAppBackToStaff(staff StaffActing, MyDesk SourceDesk, Domain.Entities.Application App, string Comment, string ReturnedTables)
        {
            var targetDesk = await _unitOfWork.DeskRepository
                .GetDeskByStaffIdAppIdWithStaff((int)SourceDesk.FromStaffID, App.Id);

            targetDesk.HasWork = true;
            targetDesk.UpdatedAt = DateTime.Now;
            targetDesk.Comment = Comment;
            targetDesk.ProcessStatus = APPLICATION_HISTORY_STATUS.ReturnedToStaff;
            await _unitOfWork.DeskRepository.Update(targetDesk);
            await _unitOfWork.SaveChangesAsync();
            await _helper.UpdateDeskAfterReject(SourceDesk, Comment, APPLICATION_HISTORY_STATUS.ReturnedToStaff);
            await _helper.SaveApplicationHistory(App.Id, StaffActing.StaffID, APPLICATION_HISTORY_STATUS.ReturnedToStaff, Comment, ReturnedTables, false, null, APPLICATION_ACTION.ReturnToStaff);
        }

        private async Task<ApplicationResult> ReturnAppToStaffFromWPAReviewer(MyDesk actingStaffDesk, Domain.Entities.Application App, int[]? SBUIds, string Comment, string ReturnedTables)
        {
            var finalAuthorityDesks = await GetAffectedFinalAuthDesks(App, SBUIds);
            
            if(finalAuthorityDesks is not null && finalAuthorityDesks.Count > 0)
            {
                foreach(var desk in finalAuthorityDesks)
                {
                    await UpdateAuthorityDesk(Comment, desk);

                    await _helper.UpdateDeskAfterReject(actingStaffDesk, Comment, APPLICATION_HISTORY_STATUS.ReturnedToStaff);
                    await _helper.SaveApplicationHistory(
                        App.Id, actingStaffDesk.StaffID, 
                        APPLICATION_HISTORY_STATUS.ReturnedToStaff, 
                        Comment, ReturnedTables, false, null, 
                        APPLICATION_ACTION.ReturnToStaff);
                    await _helper.UpdateApprovalTable(
                        App.Id, Comment, desk.StaffID, 
                        desk.DeskID, (int)desk.Staff.Staff_SBU, 
                        APPLICATION_HISTORY_STATUS.ReturnedToStaff);

                    //If there is still approval(s) by atleast one other FA then still keep the application on the wpa rev desk.
                    var foundApproval = await _unitOfWork.AppSBUApprovalRepository
                            .GetAsync(
                                (x) => x.AppId == App.Id && x.Status == DESK_PROCESS_STATUS.FinalAuthorityApproved,
                                null
                            );
                    
                    if(foundApproval is not null)
                    {
                        actingStaffDesk.HasWork = true;
                        await _unitOfWork.DeskRepository.Update(actingStaffDesk);
                    }

                    await _unitOfWork.SaveChangesAsync();

                    //Notify staff
                    var targetStaff = await _unitOfWork.StaffRepository
                        .GetStaffByIdWithSBU(desk.StaffID);

                    _staffNotifier.Init(targetStaff, App, App.Concession, App.Field);
                    _staffNotifier.SendReturnNotification();
                }

                return new ApplicationResult(null, "Application(s) has been sent back successfully.");
            }
            else throw new Exception("Error: No application ID was passed for this action to be completed.");
        }

        private async Task UpdateAuthorityDesk(string Comment, MyDesk desk)
        {
            desk.HasWork = true;
            desk.UpdatedAt = DateTime.Now;
            desk.Comment = Comment;
            desk.ProcessStatus = APPLICATION_HISTORY_STATUS.ReturnedToStaff;
            await _unitOfWork.DeskRepository.Update(desk);
        }

        private async Task<List<MyDesk>> GetAffectedFinalAuthDesks(Domain.Entities.Application App, int[]? SBUIDs)
        {
            if(App is null) throw new Exception("Application can not be null.");

            if(SBUIDs is null || SBUIDs.Length == 0) throw new Exception("You must provide atleast one SBU for this operation.");

            var finalAuthorityApprovals = (await _unitOfWork.AppSBUApprovalRepository
                .GetListByAppIdIncludeStaff(App.Id) ?? throw new Exception("No Final Authority was found for this operation"))
                .ToList();
            
            var finalAuthorityDesks = new List<MyDesk>();

            foreach(var SBUId in SBUIDs)
            {
                var apr = finalAuthorityApprovals.Find(x => x.Staff.Staff_SBU == SBUId);
                var tempDesk = await _unitOfWork.DeskRepository.GetDeskByDeskIdIncludeStaff((int)apr.DeskID);
                finalAuthorityDesks.Add(tempDesk);
            }

            return finalAuthorityDesks;
        }
    }
}