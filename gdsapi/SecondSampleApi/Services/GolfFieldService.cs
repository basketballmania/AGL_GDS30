using AGL.Api.ApplicationCore.Interfaces;
using AGL.Api.Domain.Entities;
using SecondSampleApi.Services.Interfaces;
using SecondSampleApi.DTOs.Request;
using SecondSampleApi.DTOs.Response;

namespace SecondSampleApi.Services
{
    public class GolfFieldService : IGolfFieldService, IWarmUpService
    {
        private readonly IGolfFieldRepository _golfFieldRepository;

        public GolfFieldService(IGolfFieldRepository golfFieldRepository)
        {
            _golfFieldRepository = golfFieldRepository;
        }

        public async Task<List<GolfFieldResponseDto>> GetGolfFields(string? parameter)
        {
            var golfFields = await _golfFieldRepository.GetGolfFieldsAsync(parameter);

            return golfFields.Select(x => new GolfFieldResponseDto
            {
                FieldId = x.FieldId,
                FieldName = x.FieldName,
                Location = x.Location.ToString(),
                Description = x.FieldNameEng ?? string.Empty,
                IsActive = x.isDelete == 0,
                Source = "MSSQL",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            }).ToList();
        }

        public async Task<GolfFieldResponseDto?> GetGolfFieldById(string fieldId)
        {
            var golfField = await _golfFieldRepository.GetGolfFieldByIdAsync(fieldId);
            
            if (golfField == null)
                return null;

            return new GolfFieldResponseDto
            {
                FieldId = golfField.FieldId,
                FieldName = golfField.FieldName,
                Location = golfField.Location.ToString(),
                Description = golfField.FieldNameEng ?? string.Empty,
                IsActive = golfField.isDelete == 0,
                Source = "MSSQL",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
        }

        public async Task<GolfFieldResponseDto> CreateGolfField(GolfFieldRequestDto request)
        {
            var newGolfField = new TA_GolfField
            {
                FieldId = Guid.NewGuid().ToString(),
                FieldName = request.FieldName,
                Location = int.TryParse(request.Location, out var location) ? location : 0,
                FieldNameEng = request.Description,
                Phone = "",
                Fax = "",
                Longitude = "",
                Latitude = "",
                Address = "",
                Language = "KO",
                Holes = 18,
                Par = 72,
                TimeZone = 420,
                SummerTime = 0,
                UsdEnable = 0,
                UnitCount = 9,
                GroupId = "",
                GroupType = 0,
                Currency = "KRW",
                isDelete = 0
            };

            var createdGolfField = await _golfFieldRepository.CreateGolfFieldAsync(newGolfField);

            return new GolfFieldResponseDto
            {
                FieldId = createdGolfField.FieldId,
                FieldName = createdGolfField.FieldName,
                Location = createdGolfField.Location.ToString(),
                Description = createdGolfField.FieldNameEng ?? string.Empty,
                IsActive = createdGolfField.isDelete == 0,
                Source = "MSSQL",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
        }

        public async Task<GolfFieldResponseDto> UpdateGolfField(string fieldId, GolfFieldRequestDto request)
        {
            var existingGolfField = await _golfFieldRepository.GetGolfFieldByIdAsync(fieldId);
            if (existingGolfField == null)
                throw new InvalidOperationException($"GolfField with ID {fieldId} not found");

            existingGolfField.FieldName = request.FieldName;
            existingGolfField.Location = int.TryParse(request.Location, out var location) ? location : existingGolfField.Location;
            existingGolfField.FieldNameEng = request.Description;

            var updatedGolfField = await _golfFieldRepository.UpdateGolfFieldAsync(existingGolfField);

            return new GolfFieldResponseDto
            {
                FieldId = updatedGolfField.FieldId,
                FieldName = updatedGolfField.FieldName,
                Location = updatedGolfField.Location.ToString(),
                Description = updatedGolfField.FieldNameEng ?? string.Empty,
                IsActive = updatedGolfField.isDelete == 0,
                Source = "MSSQL",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
        }

        public async Task<bool> DeleteGolfField(string fieldId)
        {
            return await _golfFieldRepository.DeleteGolfFieldAsync(fieldId);
        }

        public async Task WarmUpAsync()
        {
            await _golfFieldRepository.CanConnectAsync();
        }
    }
} 