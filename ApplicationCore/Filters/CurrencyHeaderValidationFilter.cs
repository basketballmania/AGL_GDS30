using AGL.Api.ApplicationCore.Models;
using AGL.Api.ApplicationCore.Models.Enum;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AGL.Api.ApplicationCore.Filters
{
    public class CurrencyHeaderValidationFilter : ActionFilterAttribute
    {
        private readonly string[] _validCurrencyCodes = { "KRW", "USD", "JPY", "EUR", "GBP", "SGD", "TWD" };

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // Currency 헤더 체크
            if (!context.HttpContext.Request.Headers.TryGetValue("Currency", out var currencyValue) || string.IsNullOrEmpty(currencyValue))
            {
                var result = new API_FailureModel
                {
                    Code = API_ResultCode.BadRequest,
                    Data = "Currency header cannot be null.",
                };

                context.Result = new BadRequestObjectResult(result);
                return;
            }

            // 값 유효성 체크: 허용된 화폐가 아닐 경우 USD로 대체
            var language = currencyValue.ToString().ToUpper();
            if (!_validCurrencyCodes.Contains(language))
            {
                context.HttpContext.Request.Headers["Currency"] = "USD";
            }

            base.OnActionExecuting(context);
        }
    }
}