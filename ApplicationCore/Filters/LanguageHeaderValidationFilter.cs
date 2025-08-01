using AGL.Api.ApplicationCore.Models;
using AGL.Api.ApplicationCore.Models.Enum;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AGL.Api.ApplicationCore.Filters
{
    public class LanguageHeaderValidationFilter : ActionFilterAttribute
    {
        private readonly string[] _validLanguageCodes = { "KO", "EN", "JA", "ES", "ZH", "TW" };

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // Language 헤더 체크
            if (!context.HttpContext.Request.Headers.TryGetValue("Language", out var languageValue) || string.IsNullOrEmpty(languageValue))
            {
                var result = new API_FailureModel
                {
                    Code = API_ResultCode.BadRequest,
                    Data = "Language header cannot be null.",
                };

                context.Result = new BadRequestObjectResult(result);
                return;
            }

            // 값 유효성 체크: 허용된 언어가 아닐 경우 영어로 대체
            var language = languageValue.ToString().ToUpper();
            if (!_validLanguageCodes.Contains(language))
            {
                context.HttpContext.Request.Headers["Language"] = "EN";
            }

            base.OnActionExecuting(context);
        }
    }
}