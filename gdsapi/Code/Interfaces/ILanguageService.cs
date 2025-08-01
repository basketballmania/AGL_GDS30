namespace Code.Interfaces
{
    public interface ILanguageService
	{
        
        /// <summary>
        /// 언어 조회
        /// </summary>
        /// <returns></returns>
        Task<dynamic> GetLanguageCodes();
    }
}