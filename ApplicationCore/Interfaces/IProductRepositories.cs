using AGL.Api.ApplicationCore.Models.Queries;
using AGL.Api.ApplicationCore.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AGL.Api.ApplicationCore.Interfaces
{

	public interface IProductRepositories
	{
		/// <summary>
		/// S&P 상품 가져오기
		/// </summary>
		/// <returns></returns>
		Task<string[]> GetStayAndPlayProducts(HashSet<string> productIds);

	}
}
