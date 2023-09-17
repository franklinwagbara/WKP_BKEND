using Microsoft.AspNetCore.Mvc;

namespace Backend_UMR_Work_Program.Common.Interfaces
{
    /// <summary>
    ///     Specifies the response
    /// </summary>
    public interface IApiResponse
    {
        /// <summary>
        ///     Specifies the response type
        /// </summary>
        /// <returns>IActionResult</returns>
        IActionResult Response(object Data, string? Message, int? StatusCode, string? ResponseCode);
    }
}