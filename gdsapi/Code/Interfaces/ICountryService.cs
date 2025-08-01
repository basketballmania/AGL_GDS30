using Code.DTOs.Response;

namespace Code.Interfaces
{
    public interface ICountryService
    {
        /// <summary>
        /// 국가코드 조회
        /// </summary>
        /// <param name="continentCode">대륙코드</param>
        /// <returns>대륙코드(continentCode), 국가코드(countryCode), 국가명(countryName(en, ko, ja, zh, tw, es))</returns>
        Task<List<CountryResponseDto>> Countries(string? continentCode);

        Task<dynamic> GetCountryCodes(string? continentCodes);
    }
}