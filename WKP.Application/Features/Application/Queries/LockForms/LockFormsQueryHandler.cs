using ErrorOr;
using MediatR;
using RestSharp;
using WKP.Application.Application.Common;
using WKP.Domain.Entities;
using WKP.Domain.Enums_Contants;
using WKP.Domain.Repositories;

namespace WKP.Application.Features.Application.Queries.LockForms
{
    public class LockFormsQueryHandler : IRequestHandler<LockFormsQuery, ErrorOr<ApplicationResult>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public LockFormsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ErrorOr<ApplicationResult>> Handle(LockFormsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                if(request.Year == 0 || request.ConcessionId == 0)
                    throw new Exception("Year && ConcessionId cannot be zero");
                
                var apps = await _unitOfWork.ApplicationRepository.GetAsync(request.Year, request.ConcessionId, request.FieldId) ?? throw new Exception($"No Applications was found with Year: {request.Year}, ConcessionId: {request.ConcessionId}, FieldId: {request.FieldId}");
                var submittedApp = apps?.FirstOrDefault(a => a.Submitted == true);
                AccountDesk? accountDesk = null;

                if(apps != null)
                    accountDesk = await _unitOfWork.AccountDeskRepository.GetAsync(x => x.AppId == apps.First().Id, null); 

                if (submittedApp != null)
                {
                    var returnedApp = await _unitOfWork.ReturnedApplicationRepository.GetAsync(x => x.AppId == submittedApp.Id, null);
                    var selectedTables = returnedApp?.SelectedTables.Split('|').ToList();

                    var res = new FormLock
                    {
                        disableSubmission = submittedApp != null || accountDesk != null,
                        enableReSubmission = returnedApp == null ? false : true,
                        formsToBeEnabled = selectedTables
                    };

                    return new ApplicationResult(res);
                }
                else
                {
                    var res = new FormLock
                    {
                        disableSubmission = accountDesk != null,
                        enableReSubmission = false,
                        formsToBeEnabled = null,
                    };

                    return new ApplicationResult(res);
                }
            }
            catch (Exception e)
            {
                return Error.Failure(code: ErrorCodes.InternalFailure, description: $"Error: {e.Message} --- {e?.StackTrace} ~~~ {e?.InnerException.ToString()}");
            }
        }
    }
}