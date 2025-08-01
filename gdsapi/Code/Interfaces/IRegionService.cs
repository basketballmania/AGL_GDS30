using Code.DTOs.Response;

namespace Code.Interfaces
{
    public interface IRegionService
    {
        /// <summary>
        /// 지역코드 조회
        /// </summary>
        /// <param name="countryCode">국가코드</param>
        /// <returns>국가코드(countryCode), 지역코드(regionCode), 지역명(regionName(en, ko, ja, zh, tw, es))</returns>
        Task<List<RegionsResponseDto>> Regions(string? countryCode);

        /// <summary>
        /// 지역코드 조회
        /// </summary>
        /// <returns></returns>
		Task<dynamic> GetRegionCodes(string? countryCodes);
		
	}
}