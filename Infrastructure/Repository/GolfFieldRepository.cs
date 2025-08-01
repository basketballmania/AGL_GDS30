using AGL.Api.ApplicationCore.Interfaces;
using AGL.Api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using AGL.Api.Domain.Entities;

namespace AGL.Api.Infrastructure.Repository
{
    public class GolfFieldRepository : IGolfFieldRepository
    {
        private readonly CmsDbContext _context;

        public GolfFieldRepository(CmsDbContext context)
        {
            _context = context;
        }

        public async Task<List<TA_GolfField>> GetGolfFieldsAsync(string? parameter)
        {
            var query = _context.TA_GolfField.AsQueryable();

            if (!string.IsNullOrEmpty(parameter))
            {
                query = query.Where(x => x.FieldName.Contains(parameter) || x.FieldNameEng.Contains(parameter));
            }

            return await query.ToListAsync();
        }

        public async Task<TA_GolfField?> GetGolfFieldByIdAsync(string fieldId)
        {
            return await _context.TA_GolfField.FindAsync(fieldId);
        }

        public async Task<TA_GolfField> CreateGolfFieldAsync(TA_GolfField golfField)
        {
            _context.TA_GolfField.Add(golfField);
            await _context.SaveChangesAsync();

            return golfField;
        }

        public async Task<TA_GolfField> UpdateGolfFieldAsync(TA_GolfField golfField)
        {
            _context.TA_GolfField.Update(golfField);
            await _context.SaveChangesAsync();

            return golfField;
        }

        public async Task<bool> DeleteGolfFieldAsync(string fieldId)
        {
            var golfField = await _context.TA_GolfField.FindAsync(fieldId);
            if (golfField == null)
                return false;

            _context.TA_GolfField.Remove(golfField);
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