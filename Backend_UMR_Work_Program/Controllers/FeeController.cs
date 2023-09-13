using AutoMapper;
using Backend_UMR_Work_Program.Common.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WKP.Application.Fee.Commands;
using WKP.Application.Fee.Commands.DeleteFee;
using WKP.Application.Fee.Queries.GetFees;
using WKP.Application.Fee.Queries.GetOtherFees;
using WKP.Contracts.Fee;

namespace Backend_UMR_Work_Program.Controllers
{
    /// <summary>
    ///     Fee controller
    /// </summary>
    [Route("api/[controller]")]
    public class FeeController: BaseController
    {
        private readonly IMapper _mapper;
        private readonly ISender _mediator;

        /// <summary>
        ///     Fee controller constructor
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="mediator"></param>        
        public FeeController(
            IMapper mapper,
            ISender mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        /// <summary>
        ///     Get all fees
        /// </summary>
        /// <returns> ApiResponse object </returns>
        [HttpGet("GET_FEES")]
        public async Task<IApiResponse> GetFees(GetFeesRequest request)
        {
            var query = _mapper.Map<GetFeesQuery>(request);
            var result = await _mediator.Send(query);
            return EnumerableResponse(result);
        }

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
            return Response(result);
        }

        /// <summary>
        ///     Get Other payment fee types
        /// </summary>
        /// <returns> ApiResponse object </returns>
        [HttpGet("GET_OTHER_FEES")]
        public async Task<IApiResponse> GetOtherFees(GetOtherFeesRequest request)
        {
            var query = _mapper.Map<GetOtherFeesQuery>(request);
            var result = await _mediator.Send(query);
            return EnumerableResponse(result);
        }

        /// <summary>
        ///     Delete a fee
        /// </summary>
        /// <param name="request">Id of the fee</param>
        /// <returns> ApiResponse object </returns>
        [HttpDelete("DELETE_FEE")]
        public async Task<IApiResponse> DeleteFee(DeleteFeeCommand request)
        {
            var result = await _mediator.Send(request);
            return Response(result);
        }
    }
}
