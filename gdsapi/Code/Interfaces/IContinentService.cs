using Code.DTOs.Response;

namespace Code.Interfaces
{
    public interface IContinentService
    {
        /// <summary>
        /// 대륙코드 조회
        /// </summary>
        /// <returns>대륙명(continentName(en, ko, ja, zh, tw, es))</returns>
        Task<List<ContinentResponseDto>> Continent();
		Task<dynamic> GetContinentCodes();
		
	}
}