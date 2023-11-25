using AutoMapper;
using Backend_UMR_Work_Program.DataModels;
using Backend_UMR_Work_Program.Helpers;
using Backend_UMR_Work_Program.Models;
using Backend_UMR_Work_Program.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using System.Security.Claims;
using WKP.Application.Features.Accounting.Queries;
using WKP.Application.Features.Accounting.Queries.GetAllUSDPaymentApprovals;
using WKP.Application.Features.Accounting.Queries.GetAppPayOnStaffDeskByStaffId;
using WKP.Application.Features.Accounting.Queries.GetPaymentOnDeskByDeskId;
using WKP.Contracts.Features.Accounting;
using static Backend_UMR_Work_Program.Models.GeneralModel;

namespace Backend_UMR_Work_Program.Controllers
{
    [Route("api/[controller]")]
    public class AccountingController: BaseController
    {
        public WKP_DBContext _context;
        public IConfiguration _configuration;
        IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        private readonly HelperService _helperService;
        private readonly AccountingService _accountingService;
        private readonly ISender _mediator;

        private string? WKPCompanyId => User.FindFirstValue(ClaimTypes.NameIdentifier);
        private string? WKPCompanyName => User.FindFirstValue(ClaimTypes.Name);
        private string? WKPCompanyEmail => User.FindFirstValue(ClaimTypes.Email);
        private string? WKUserRole => User.FindFirstValue(ClaimTypes.Role);

        public AccountingController(WKP_DBContext context, IConfiguration configuration, IMapper mapper, ISender mediator, HelperService helperService, AccountingService accountingService)
        {
            _context = context;
            _configuration = configuration;
            _mapper = mapper;
            _mediator = mediator;
            _helperService = helperService;
            _accountingService = accountingService;
        }

        [HttpGet("GET_APP_PAYMENTS_ON_MY_DESK")]
        public async Task<IActionResult> GetAppPaymentsOnMyDesk()
        {
            var request = new GetAppPaymentsOnMyDeskRequest(WKPCompanyEmail);
            var command = _mapper.Map<GetAppPaymentsOnMyDeskQuery>(request);
            var result = await _mediator.Send(command);
            return Response(result);
        }
        
        [HttpGet("GET_APP_PAYMENTS_ON_STAFF_DESK_BY_STAFF_ID")]
        public async Task<IActionResult> GetAppPayOnStaffDeskByStaffId(GetAppPayOnStaffDeskByStaffIdRequest request)
        {
            var command = _mapper.Map<GetAppPayOnStaffDeskByStaffIdQuery>(request);
            var result = await _mediator.Send(command);
            return Response(result);
        }

        [HttpGet("GET_ALL_USD_APP_PAYMENT_APPROVALS")]
        public async Task<IActionResult> GetAllAppPaymentApprovals(GetAllUSDPaymentApprovalsRequest request)
        {
            var query = _mapper.Map<GetAllUSDPaymentApprovalsQuery>(request);
            var result = await _mediator.Send(query);
            return Response(result);
        }

        [HttpGet("GET_ALL_APP_PAYMENTS")]
        public async Task<IActionResult> GetAllAppPayments(GetAllAppPaymentsRequest request)
        {
            var query = _mapper.Map<GetAllAppPaymentsQuery>(request);
            var result = await _mediator.Send(query);
            return Response(result);
        }

        [HttpGet("GET_PAYMENT_ON_DESK")]
        public async Task<IActionResult>  GetAppPaymentsOnMyDesk(GetPaymentOnDeskByDeskIdRequest request)
        {
            var query = _mapper.Map<GetPaymentOnDeskByDeskIdQuery>(request);
            var result = await _mediator.Send(query);
            return Response(result);
        }
        
        //public async Task<WebApiResponse> GetAppPaymentsOnMyDesk(int deskId) => await _accountingService.GetPaymentOnDesk(deskId);

        [HttpGet("CONFIRM_USD_PAYMENT")]
        public async Task<IActionResult> ConfirmUSDPayment(int deskId) => await _accountingService.ConfirmUSDPayment(deskId);
    }
}
