using SampleApi.DTOs.Request;
using SampleApi.DTOs.Response;

namespace SampleApi.Services.Interfaces
{
    public interface IAdminService
    {
        Task<List<AdminResponseDto>> GetAdmins(string? parameter);
        Task<AdminResponseDto?> GetAdminById(int id);
        Task<AdminResponseDto?> GetAdminByEmail(string email);
        Task<AdminResponseDto> CreateAdmin(AdminRequestDto request);
        Task<AdminResponseDto> UpdateAdmin(int id, AdminRequestDto request);
        Task<bool> DeleteAdmin(int id);
    }
} 