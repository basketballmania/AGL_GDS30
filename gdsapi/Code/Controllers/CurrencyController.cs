using AGL.Api.ApplicationCore.Exceptions;
using AGL.Api.ApplicationCore.Infrastructure.Base;
using AGL.Api.ApplicationCore.Models.Enum;
using Asp.Versioning;
using Code.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Code.Controllers
{
    [ApiController]
    [Route("v{version:apiVersion}/codes/[action]")]
    public class CurrencyController : BaseController
    {
        private readonly ICurrencyService _currencyService;

        public CurrencyController(ICurrencyService currencyService)
        {
            _currencyService = currencyService;
        }

        /// <summary>
        /// Retrieve Currency Codes 
        /// </summary>
        /// <returns></returns>
        [ApiVersion("2.0")]
        [HttpGet]
        public async Task<IActionResult> currencies()
        {
            //var rst = await _currencyService.GetCurrencyCodes();

            return Ok("");
        }
    }
}