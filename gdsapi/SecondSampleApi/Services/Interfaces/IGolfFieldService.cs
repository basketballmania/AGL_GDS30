using SecondSampleApi.DTOs.Request;
using SecondSampleApi.DTOs.Response;

namespace SecondSampleApi.Services.Interfaces
{
    public interface IGolfFieldService
    {
        Task<List<GolfFieldResponseDto>> GetGolfFields(string? parameter);
        Task<GolfFieldResponseDto?> GetGolfFieldById(string fieldId);
        Task<GolfFieldResponseDto> CreateGolfField(GolfFieldRequestDto request);
        Task<GolfFieldResponseDto> UpdateGolfField(string fieldId, GolfFieldRequestDto request);
        Task<bool> DeleteGolfField(string fieldId);
    }
} 