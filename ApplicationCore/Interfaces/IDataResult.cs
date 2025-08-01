namespace AGL.Api.ApplicationCore.Interfaces
{
    public interface IDataResult
    {
        string RstCd { get; }
        string RstMsg { get; set; }
    }

	public interface IApiResult
	{
		string Status { get; }
		string Data { get; set; }
	}
}
