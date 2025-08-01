namespace AGL.Api.ApplicationCore.Interfaces
{
    public interface ISha512Hashing
    {
        Task<string> ComputeSha512Hash(string text);
    }
};