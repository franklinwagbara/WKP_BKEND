using AutoMapper;
using Backend_UMR_Work_Program.Common.Implementations;
using Backend_UMR_Work_Program.Common.Interfaces;
using Backend_UMR_Work_Program.DataModels;
using Backend_UMR_Work_Program.DTOs;
using Backend_UMR_Work_Program.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WKP.Application.Fee.Commands;
using WKP.Contracts.Fee;
using static Backend_UMR_Work_Program.Models.GeneralModel;

namespace Backend_UMR_Work_Program.Controllers
{
    [Route("api/[controller]")]
    public class FeeController: Controller
    {
        private readonly IMapper _mapper;
        private readonly ISender _mediator;
        public WKP_DBContext _context;
        public IConfiguration _configuration;
        private readonly FeeService _feeService;
        public FeeController(ISender mediator, WKP_DBContext context, IConfiguration configuration, IMapper mapper, HelperService helperService, AccountingService accountingService, FeeService feeService)
        {
            _mediator = mediator;
            _context = context;
            _configuration = configuration;
            _mapper = mapper;
            _feeService = feeService;
        }

        [HttpGet("GET_FEES")]
        public async Task<WebApiResponse> GetFees() => await _feeService.GetFees();

        /// <summary>
        ///     Add a new fee
        /// </summary>
        /// <param name="request"></param>
        /// <returns> ApiResponse object </returns>
        [HttpPost("ADD_FEE")]
        public async Task<IApiResponse> AddFee([FromBody]AddFeeRequest request)
        {
            var command = _mapper.Map<AddFeeCommand>(request);
            var result = await _mediator.Send(command);

            return SuccessResponse.ResponseObject(result);
        }

        [HttpGet("GET_OTHER_FEES")]
        public async Task<WebApiResponse> GetOtherFees() => await _feeService.GetOtherFees();

        [HttpDelete("DELETE_FEE")]
        public async Task<WebApiResponse> DeleteFee(int id) => await _feeService.DeleteFee(id);
    }
}
