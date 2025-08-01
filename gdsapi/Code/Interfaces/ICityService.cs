using Code.DTOs.Response;

namespace Code.Interfaces
{
    public interface ICityService
    {
        /// <summary>
        /// 도시코드 조회
        /// </summary>
        /// <param name="countryCode">국가코드</param>
        /// <returns>국가코드(countryCode), 도시코드(cityCode), 도시명(cityName(en, ko, ja, zh, tw, es))</returns>
        Task<List<CityResponseDto>> Cities(string? countryCode);

        /// <summary>
        /// 도시코드 조회
        /// </summary>
        /// <returns></returns>
		Task<dynamic> GetCityCodes(string? countryCodes);

		
	}
}