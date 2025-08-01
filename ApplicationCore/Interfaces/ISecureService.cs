using AGL.Api.ApplicationCore.Models.Queries;
using AGL.Api.ApplicationCore.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AGL.Api.ApplicationCore.Interfaces
{
	//public interface ISecureService
	//{
	//    public void IpCheck();

	//}

	//public class SecureService : Identifiable, ISecureService
	//{
	//    private List<string> SecureIpList = new List<string>
	//      {
	//          "0.0.0.1",
	//          "3.38.14.183", //Agl Admin IP
	//          "118.32.134.203", //5층 공인아이피
	//          "15.164.249.67", //HTT2.0 개발서버 아이피
	//          "222.109.244.219", // 3층 공인아이피
	//          "222.109.244.205", // 2층 공인 아이피
	//          "13.124.139.129", //AGL Admin 개발 IP
	//          "3.34.242.9", // 구글 피드 전송 서버
	//	"118.32.134.212",//GDS 2.0
	//	"222.109.244.205",//GDS 2.0
	//	"52.78.217.214",//GDS 2.0
	//	"15.164.11.52",//GDS 2.0
	//	"3.36.141.227",//GDS 2.0
	//          "40.82.144.54", //W/L FE
	//	"4.230.17.200",//DEV W/L FE
	//	"20.214.181.113", //OTA-API
	//	"20.39.195.165",//DEV OTA-API 
	//          "220.117.31.88",//6층 공인아이피
	//          "211.46.59.54",//4층 공인아이피
	//};

	//    public SecureService(IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor) { }

	//    public void IpCheck()
	//    {
	//        if (!SecureIpList.Contains(GetRemoteIp()))
	//        {
	//            throw new DomainException(ApplicationCore.Models.Enum.ResultCode.비로그인, "허용되지 않은 IP 입니다.");
	//        }

	//    }
	//}

	//public interface ISecureIpRepository
	//{
	//    Task<List<string>> GetSecureIpListAsync();
	//}

	//public interface ISecureService
	//{
	//    Task IpCheck();
	//}


	public interface ISecureService
	{
		Task IpCheck(string clientIp, string controllerName, string apiTitle);
	}

	public interface ISecureIpRepository
	{
		/// <summary>
		/// 전부 허용 IP 확인
		/// </summary>
		/// <returns></returns>
		Task<bool> GetSecureIpListAsync(string ip);
		/// <summary>
		/// 특정 API/컨트롤러 허용 IP 확인
		/// </summary>
		/// <param name="controllerName"></param>
		/// <param name="apiTitle"></param>
		/// <returns></returns>
		Task<bool> GetSecureIpListAsync(string ip, string controllerName, string apiTitle);
	}
}
