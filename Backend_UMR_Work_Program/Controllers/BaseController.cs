using AutoMapper;
using Backend_UMR_Work_Program.Common.Implementations;
using Backend_UMR_Work_Program.Common.Interfaces;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WKP.Application.Application.Common;
using WKP.Application.Fee.Common;

namespace Backend_UMR_Work_Program.Controllers
{
    public class BaseController: Controller
    {
        public string? WKPCompanyId => User.FindFirstValue(ClaimTypes.NameIdentifier);
        public string? WKPCompanyName => User.FindFirstValue(ClaimTypes.Name);
        public string? WKPCompanyEmail => User.FindFirstValue(ClaimTypes.Email);
        public string? WKUserRole => User.FindFirstValue(ClaimTypes.Role);

        public static IActionResult Response(ErrorOr<FeeResult> result)
        {
            return result.Match(
                res => SuccessResponse.ResponseObject(res),
                errors => FailResponse.ResponseObject(errors)
            );
        }
        public static IActionResult Response(ErrorOr<DashboardResult> result)
        {
            return result.Match(
                res => SuccessResponse.ResponseObject(res.Result),
                errors => FailResponse.ResponseObject(errors)
            );
        }

        public static IActionResult Response(ErrorOr<ApplicationResult> result)
        {
            return result.Match(
                res => SuccessResponse.ResponseObject(res.Result, res.Message),
                errors => FailResponse.ResponseObject(errors[0])
            );
        }

        public static IActionResult EnumerableResponse(ErrorOr<FeeListResult> result)
        {
            return result.Match(
                res => SuccessResponse.ResponseObject(res.Fees),
                errors => FailResponse.ResponseObject(errors)
            );
        }
    }
}
