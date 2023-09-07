using Backend_UMR_Work_Program.Common.Interfaces;
using DocumentFormat.OpenXml.Drawing.Charts;

namespace Backend_UMR_Work_Program.Common.Implementations
{
    /// <summary>
    ///     Api Response object
    /// </summary>
    public class ApiResponse : IApiResponse
    {
        /// <summary>
        ///     Data return from API response
        /// </summary>
        /// <value> object </value>
        public object? Data { get; set; }

        /// <summary>
        ///     Message return from API response
        /// </summary>
        /// <value> object </value>
        public string? Message { get; set; } = string.Empty;

        /// <summary>
        ///     App Response code return from API response
        /// </summary>
        /// <value> object </value>
        public string? ResponseCode { get; set; } = string.Empty;
        
        /// <summary>
        ///     Status code return from API response
        /// </summary>
        /// <value> object </value>
        public int StatusCode {get; set; }


        /// <summary>
        ///     Response return from API response
        /// </summary>
        /// <value> object </value>
        public IApiResponse Response(object Data, string? Message, int? StatusCode, string? ResponseCode)
        {
            return new ApiResponse { Data = Data, Message = Message, ResponseCode = ResponseCode, StatusCode = StatusCode ?? StatusCodes.Status200OK };
        }
    }
}