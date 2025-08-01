namespace Code.Interfaces
{
    public interface ICurrencyService
	{
        
        /// <summary>
        /// 통화 코드 조회
        /// </summary>
        /// <returns></returns>
        Task<dynamic> GetCurrencyCodes();
    }
}