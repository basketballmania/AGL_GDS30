using AGL.Api.ApplicationCore.Interfaces;
using AGL.Api.Domain.Entities;
using AGL.Api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AGL.Api.Infrastructure.Repository
{
    public class AdminRepository : IAdminRepository
    {
        private readonly ShoppingDbContext _context;

        public AdminRepository(ShoppingDbContext context)
        {
            _context = context;
        }

        public async Task<List<AdminEntity>> GetAdminsAsync(string? parameter)
        {
            var query = _context.AdminEntities.AsQueryable();

            if (!string.IsNullOrEmpty(parameter))
            {
                query = query.Where(x => x.Name.Contains(parameter) || x.Email.Contains(parameter));
            }

            return await query.ToListAsync();
        }

        public async Task<AdminEntity?> GetAdminByIdAsync(int id)
        {
            return await _context.AdminEntities.FindAsync(id);
        }

        public async Task<AdminEntity?> GetAdminByEmailAsync(string email)
        {
            return await _context.AdminEntities.FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<AdminEntity> CreateAdminAsync(AdminEntity admin)
        {
            admin.CreatedAt = DateTime.UtcNow;
            admin.UpdatedAt = DateTime.UtcNow;

            _context.AdminEntities.Add(admin);
            await _context.SaveChangesAsync();

            return admin;
        }

        public async Task<AdminEntity> UpdateAdminAsync(AdminEntity admin)
        {
            admin.UpdatedAt = DateTime.UtcNow;

            _context.AdminEntities.Update(admin);
            await _context.SaveChangesAsync();

            return admin;
        }

        public async Task<bool> DeleteAdminAsync(int id)
        {
            var admin = await _context.AdminEntities.FindAsync(id);
            if (admin == null)
                return false;

            _context.AdminEntities.Remove(admin);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> CanConnectAsync()
        {
            try
            {
                await _context.Database.CanConnectAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
} 