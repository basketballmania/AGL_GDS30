namespace AGL.Api.ApplicationCore.Interfaces
{
    public interface IImgEncrypt
    {
        Task<string> GetEncryptUrl(string ImgUrl);
    }
}