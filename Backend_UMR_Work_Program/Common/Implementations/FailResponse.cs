using Backend_UMR_Work_Program.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Backend_UMR_Work_Program.Common.Implementations
{
    /// <summary>
    ///     specifies the success response object
    /// </summary>
    public class FailResponse : IApiResponse
    {
        /// <summary>
        ///     specifies the success response object
        /// </summary>
        /// <returns>
        ///     IApiResponse
        /// </returns>
        public IActionResult Response(object? Data, string? Message, int? StatusCode, string? ResponseCode)
        {
            return new ObjectResult(new ApiResponse{Data = Data, Message = Message, StatusCode = StatusCode ?? StatusCodes.Status500InternalServerError, ResponseCode = ResponseCode})
            {
                StatusCode = StatusCode ?? StatusCodes.Status500InternalServerError
            };
        }

        /// <summary>
        ///     specifies the success response object
        /// </summary>
        /// <returns>
        ///     IApiResponse
        /// </returns>
        public static IActionResult ResponseObject(object? Data = null, string? Message = null, int? StatusCode = null, string? ResponseCode = null)
        {
            return new FailResponse().Response(Data, Message, StatusCode, ResponseCode);
        }
    }
}