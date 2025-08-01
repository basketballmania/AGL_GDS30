using AGL.Api.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGL.Api.ApplicationCore.Services
{
	public class SecureService : Identifiable, ISecureService
	{
		private readonly ISecureIpRepository _secureIpRepository;

		public SecureService(IHttpContextAccessor httpContextAccessor, ISecureIpRepository secureIpRepository)
			: base(httpContextAccessor)
		{
			_secureIpRepository = secureIpRepository;
		}
		//public async Task IpCheck()
		//{
		//    //var secureIpList = await _secureIpRepository.GetSecureIpListAsync();
		//    //string clientIp = GetRemoteIp();
		//    //
		//    //if (!secureIpList.Contains(clientIp))
		//    //{
		//    //    throw new DomainException(ApplicationCore.Models.Enum.ResultCode.비로그인, "허용되지 않은 IP 입니다.");
		//    //}
		//    string clientIp = GetRemoteIp();

		//    if (!await IsAllowedIpAsync(clientIp, ""))
		//    {
		//        throw new DomainException(ApplicationCore.Models.Enum.ResultCode.비로그인, "허용되지 않은 IP 입니다.");
		//    }
		//}

		public async Task IpCheck(string clientIp, string controllerName, string apiTitle)
		{
			if (!await IsAllowedIpAsync(clientIp, controllerName, apiTitle))
			{
				throw new DomainException(ApplicationCore.Models.Enum.ResultCode.비로그인, "허용되지 않은 IP 입니다.");
			}
		}


		public async Task<bool> IsAllowedIpAsync(string clientIp, string controllerName, string apiTitle)
		{
			clientIp = await NormalizeIp(clientIp);
			var isHasSecureIp= await _secureIpRepository.GetSecureIpListAsync(clientIp);
			if (isHasSecureIp)
			{
				return true;
			}
			else
			{

				var isHasRestrictedIp = await _secureIpRepository.GetSecureIpListAsync(clientIp, controllerName, apiTitle);
				if (isHasRestrictedIp)
				{
					return true;
				}
			}

			// 허용되지 않은 IP
			return false;
		}
		private async Task<string> NormalizeIp(string ip)
		{

			ip = string.Join(".", ip.Split('.').Select(o => int.Parse(o).ToString("D3")));

			await Task.CompletedTask;

			return ip;
		}

	}
}
