using AGL.Api.ApplicationCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace AGL.Api.ApplicationCore.Infrastructure.Base
{
    public class BaseController : ControllerBase
    {
        [ApiExplorerSettings(IgnoreApi = true)]
        public new OkObjectResult Ok()
        {
            return Ok(string.Empty);
        }

        public override OkObjectResult Ok(object? data)
        {
            var result = new API_SuccessModel<dynamic>
            {
                Data = data ?? string.Empty
            };

            return base.Ok(result);
        }

        public override BadRequestObjectResult BadRequest(object? error = null)
        {
            string errorMessage = (error as Exception)?.Message ?? (error as string) ?? "Bad request";
            
            var result = new API_FailureModel
            {
                Code = Models.Enum.API_ResultCode.BadRequest,
                Data = errorMessage,
            };
            
            return base.BadRequest(result);
        }
        
        public override BadRequestObjectResult BadRequest(ModelStateDictionary modelState)
        {
            var firstErrorMessage = modelState.Values
                                      .SelectMany(v => v.Errors)
                                      .Select(e => e.ErrorMessage)
                                      .FirstOrDefault() ?? "Bad request. Model state is invalid.";

            var result = new API_FailureModel
            {
                Code = Models.Enum.API_ResultCode.BadRequest,
                Data = firstErrorMessage,
            };
            
            return base.BadRequest(result);
        }
    }
}
