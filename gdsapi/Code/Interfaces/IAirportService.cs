namespace Code.Interfaces
{
    public interface IAirportService
	{
        
        /// <summary>
        /// 항공 코드 조회
        /// </summary>
        /// <returns></returns>
        Task<dynamic> GetAirportCodes();
    }
}