using Azure;
using Backend_UMR_Work_Program.Common.Interfaces;

namespace Backend_UMR_Work_Program.Common.Implementations
{
    /// <summary>
    ///     specifies the success response object
    /// </summary>
    public class SuccessResponse : IApiResponse
    {
        /// <summary>
        ///     specifies the success response object
        /// </summary>
        /// <returns>
        ///     IApiResponse
        /// </returns>
        public IApiResponse Response(object? Data, string? Message, int? StatusCode, string? ResponseCode)
        {
            return new ApiResponse{Data = Data, Message = Message, StatusCode = StatusCode ?? StatusCodes.Status200OK, ResponseCode = ResponseCode};
        }

        /// <summary>
        ///     specifies the success response object
        /// </summary>
        /// <returns>
        ///     IApiResponse
        /// </returns>
        public static IApiResponse ResponseObject(object? Data = null, string? Message = null, int? StatusCode = null, string? ResponseCode = null)
        {
            return new SuccessResponse().Response(Data, Message, StatusCode, ResponseCode);
        }
    }
}