using AGL.Api.Domain.Entities;

namespace AGL.Api.ApplicationCore.Interfaces
{
    public interface IAdminRepository
    {
        Task<List<AdminEntity>> GetAdminsAsync(string? parameter);
        Task<AdminEntity?> GetAdminByIdAsync(int id);
        Task<AdminEntity?> GetAdminByEmailAsync(string email);
        Task<AdminEntity> CreateAdminAsync(AdminEntity admin);
        Task<AdminEntity> UpdateAdminAsync(AdminEntity admin);
        Task<bool> DeleteAdminAsync(int id);
        Task<bool> CanConnectAsync();
    }
} 