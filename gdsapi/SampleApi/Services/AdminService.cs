using AGL.Api.ApplicationCore.Interfaces;
using AGL.Api.Domain.Entities;
using SampleApi.Interfaces;
using SampleApi.DTOs.Request;
using SampleApi.DTOs.Response;
using System.Security.Cryptography;
using System.Text;

namespace SampleApi.Services
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepository;

        public AdminService(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public async Task<List<AdminResponseDto>> GetAdmins(string? parameter)
        {
            try
            {
                var admins = await _adminRepository.GetAdminsAsync(parameter);

                return admins.Select(x => new AdminResponseDto
                {
                    Id = x.Id,
                    Email = x.Email,
                    Name = x.Name,
                    Role = x.Role,
                    IsActive = x.IsActive,
                    Source = "PostgreSQL",
                    CreatedAt = x.CreatedAt,
                    UpdatedAt = x.UpdatedAt
                }).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"GetAdmins error: {ex.Message}");
                throw new InvalidOperationException("관리자 목록 조회 중 오류가 발생했습니다.", ex);
            }
        }

        public async Task<AdminResponseDto?> GetAdminById(int id)
        {
            try
            {
                var admin = await _adminRepository.GetAdminByIdAsync(id);
                
                if (admin == null)
                    return null;

                return new AdminResponseDto
                {
                    Id = admin.Id,
                    Email = admin.Email,
                    Name = admin.Name,
                    Role = admin.Role,
                    IsActive = admin.IsActive,
                    Source = "PostgreSQL",
                    CreatedAt = admin.CreatedAt,
                    UpdatedAt = admin.UpdatedAt
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"GetAdminById error: {ex.Message}");
                throw new InvalidOperationException($"관리자 조회 중 오류가 발생했습니다. (ID: {id})", ex);
            }
        }

        public async Task<AdminResponseDto?> GetAdminByEmail(string email)
        {
            try
            {
                var admin = await _adminRepository.GetAdminByEmailAsync(email);
                
                if (admin == null)
                    return null;

                return new AdminResponseDto
                {
                    Id = admin.Id,
                    Email = admin.Email,
                    Name = admin.Name,
                    Role = admin.Role,
                    IsActive = admin.IsActive,
                    Source = "PostgreSQL",
                    CreatedAt = admin.CreatedAt,
                    UpdatedAt = admin.UpdatedAt
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"GetAdminByEmail error: {ex.Message}");
                throw new InvalidOperationException($"관리자 조회 중 오류가 발생했습니다. (Email: {email})", ex);
            }
        }

        public async Task<AdminResponseDto> CreateAdmin(AdminRequestDto request)
        {
            try
            {
                var passwordHash = HashPassword(request.Password);

                var newAdmin = new AdminEntity
                {
                    Email = request.Email,
                    PasswordHash = passwordHash,
                    Name = request.Name,
                    Role = request.Role
                };

                var createdAdmin = await _adminRepository.CreateAdminAsync(newAdmin);

                return new AdminResponseDto
                {
                    Id = createdAdmin.Id,
                    Email = createdAdmin.Email,
                    Name = createdAdmin.Name,
                    Role = createdAdmin.Role,
                    IsActive = createdAdmin.IsActive,
                    Source = "PostgreSQL",
                    CreatedAt = createdAdmin.CreatedAt,
                    UpdatedAt = createdAdmin.UpdatedAt
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"CreateAdmin error: {ex.Message}");
                throw new InvalidOperationException("관리자 생성 중 오류가 발생했습니다.", ex);
            }
        }

        public async Task<AdminResponseDto> UpdateAdmin(int id, AdminRequestDto request)
        {
            try
            {
                var existingAdmin = await _adminRepository.GetAdminByIdAsync(id);
                if (existingAdmin == null)
                    throw new InvalidOperationException($"Admin with ID {id} not found");

                existingAdmin.Email = request.Email;
                existingAdmin.Name = request.Name;
                existingAdmin.Role = request.Role;

                if (!string.IsNullOrEmpty(request.Password))
                {
                    existingAdmin.PasswordHash = HashPassword(request.Password);
                }

                var updatedAdmin = await _adminRepository.UpdateAdminAsync(existingAdmin);

                return new AdminResponseDto
                {
                    Id = updatedAdmin.Id,
                    Email = updatedAdmin.Email,
                    Name = updatedAdmin.Name,
                    Role = updatedAdmin.Role,
                    IsActive = updatedAdmin.IsActive,
                    Source = "PostgreSQL",
                    CreatedAt = updatedAdmin.CreatedAt,
                    UpdatedAt = updatedAdmin.UpdatedAt
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"UpdateAdmin error: {ex.Message}");
                throw new InvalidOperationException($"관리자 수정 중 오류가 발생했습니다. (ID: {id})", ex);
            }
        }

        public async Task<bool> DeleteAdmin(int id)
        {
            try
            {
                return await _adminRepository.DeleteAdminAsync(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"DeleteAdmin error: {ex.Message}");
                throw new InvalidOperationException($"관리자 삭제 중 오류가 발생했습니다. (ID: {id})", ex);
            }
        }

        public async Task<LoginResponseDto> Login(LoginRequestDto request)
        {
            try
            {
                var admin = await _adminRepository.GetAdminByEmailAsync(request.Email);
                
                if (admin == null)
                {
                    return new LoginResponseDto
                    {
                        Success = false,
                        Message = "이메일 또는 비밀번호가 올바르지 않습니다."
                    };
                }

                var hashedPassword = HashPassword(request.Password);
                
                if (admin.PasswordHash != hashedPassword)
                {
                    return new LoginResponseDto
                    {
                        Success = false,
                        Message = "이메일 또는 비밀번호가 올바르지 않습니다."
                    };
                }

                if (!admin.IsActive)
                {
                    return new LoginResponseDto
                    {
                        Success = false,
                        Message = "비활성화된 계정입니다."
                    };
                }

                // 간단한 토큰 생성 (실제 프로덕션에서는 JWT 등을 사용해야 함)
                var token = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{admin.Id}:{admin.Email}:{DateTime.UtcNow.Ticks}"));

                return new LoginResponseDto
                {
                    Success = true,
                    Token = token,
                    Message = "로그인 성공",
                    Admin = new AdminResponseDto
                    {
                        Id = admin.Id,
                        Email = admin.Email,
                        Name = admin.Name,
                        Role = admin.Role,
                        IsActive = admin.IsActive,
                        Source = "PostgreSQL",
                        CreatedAt = admin.CreatedAt,
                        UpdatedAt = admin.UpdatedAt
                    }
                };
            }
            catch (Exception ex)
            {
                // 로그 기록 (실제 프로덕션에서는 ILogger를 사용해야 함)
                Console.WriteLine($"Login error: {ex.Message}");
                
                return new LoginResponseDto
                {
                    Success = false,
                    Message = "로그인 처리 중 오류가 발생했습니다. 잠시 후 다시 시도해주세요."
                };
            }
        }

        public async Task WarmUpAsync()
        {
            try
            {
                await _adminRepository.CanConnectAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"WarmUpAsync error: {ex.Message}");
                throw new InvalidOperationException("데이터베이스 연결 확인 중 오류가 발생했습니다.", ex);
            }
        }

        private string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(hashedBytes);
        }
    }
} 