using AGL.Api.Domain.Entities;

namespace AGL.Api.ApplicationCore.Interfaces
{
    public interface IGolfFieldRepository
    {
        Task<List<TA_GolfField>> GetGolfFieldsAsync(string? parameter);
        Task<TA_GolfField?> GetGolfFieldByIdAsync(string fieldId);
        Task<TA_GolfField> CreateGolfFieldAsync(TA_GolfField golfField);
        Task<TA_GolfField> UpdateGolfFieldAsync(TA_GolfField golfField);
        Task<bool> DeleteGolfFieldAsync(string fieldId);
        Task<bool> CanConnectAsync();
    }
} 