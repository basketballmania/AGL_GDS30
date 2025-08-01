namespace Code.Interfaces
{
    public interface IFacilityService
	{
        
        /// <summary>
        /// 부대 시설 코드 조회
        /// </summary>
        /// <returns></returns>
        Task<dynamic> GetFacilityCodes();
    }
}