using AGL.Api.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using AGL.Api.ApplicationCore.Models;

namespace AGL.Api.ApplicationCore.Middleware
{
	public class IpCheckFilter : IAsyncActionFilter
	{
		private readonly ISecureService _secureService;
		private readonly IConfiguration _configuration;


		public IpCheckFilter(ISecureService secureService, IConfiguration configuration)
		{
			_secureService = secureService;
			_configuration = configuration;
		}

		public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
		{
			var clientIp = context.HttpContext.Connection.RemoteIpAddress?.MapToIPv4()?.ToString();
			var controllerName = context.RouteData.Values["controller"]?.ToString();
			var apiTitle = _configuration.GetSection("OpenApi").Get<OpenApiConfiguration>().Title;
			try
			{
				// 기존 메서드 호출
				await _secureService.IpCheck(clientIp, controllerName, apiTitle);
				await next();
			}
			catch (Exception ex)
			{
				throw new DomainException(Models.Enum.ResultCode.비로그인, ex.Message);
				//context.Result = new UnauthorizedResult();
			}
		}
	}
}
