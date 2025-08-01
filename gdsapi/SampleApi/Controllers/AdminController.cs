using AGL.Api.ApplicationCore.Infrastructure.Base;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using SampleApi.DTOs.Request;
using SampleApi.Interfaces;

namespace SampleApi.Controllers
{
    [ApiController]
    [Route("v{version:apiVersion}/admin")]
    public class AdminController : BaseController
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        /// <summary>$
        /// 관리자 목록 조회
        /// </summary>
        /// <param name="parameter">검색 파라미터</param>
        /// <returns>관리자 목록</returns>
        [ApiVersion("1.0")]
        [HttpGet]
        public async Task<IActionResult> GetAdmins([FromQuery] string? parameter)
        {
            var admins = await _adminService.GetAdmins(parameter);
            return Ok(admins);
        }

        /// <summary>
        /// 관리자 상세 조회
        /// </summary>
        /// <param name="id">관리자 ID</param>
        /// <returns>관리자 상세 정보</returns>
        [ApiVersion("1.0")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAdminById(int id)
        {
            var admin = await _adminService.GetAdminById(id);
            if (admin == null)
                return NotFound();
            return Ok(admin);
        }

        /// <summary>
        /// 관리자 생성
        /// </summary>
        /// <param name="request">관리자 생성 요청</param>
        /// <returns>생성된 관리자 정보</returns>
        [ApiVersion("1.0")]
        [HttpPost]
        public async Task<IActionResult> CreateAdmin([FromBody] AdminRequestDto request)
        {
            var createdAdmin = await _adminService.CreateAdmin(request);
            return CreatedAtAction(nameof(GetAdminById), new { id = createdAdmin.Id }, createdAdmin);
        }

        /// <summary>
        /// 관리자 수정
        /// </summary>
        /// <param name="id">관리자 ID</param>
        /// <param name="request">관리자 수정 요청</param>
        /// <returns>수정된 관리자 정보</returns>
        [ApiVersion("1.0")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAdmin(int id, [FromBody] AdminRequestDto request)
        {
            var updatedAdmin = await _adminService.UpdateAdmin(id, request);
            return Ok(updatedAdmin);
        }

        /// <summary>
        /// 관리자 삭제
        /// </summary>
        /// <param name="id">관리자 ID</param>
        /// <returns>삭제 결과</returns>
        [ApiVersion("1.0")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdmin(int id)
        {
            var result = await _adminService.DeleteAdmin(id);
            return Ok(result);
        }

        /// <summary>
        /// 관리자 로그인
        /// </summary>
        /// <param name="request">로그인 요청</param>
        /// <returns>로그인 결과</returns>
        [ApiVersion("1.0")]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto request)
        {
            try
            {
                var result = await _adminService.Login(request);
                
                if (!result.Success)
                {
                    // 로그인 실패 시 상세한 메시지와 함께 401 Unauthorized 반환
                    return Unauthorized(new
                    {
                        success = false,
                        message = result.Message,
                        error = "LOGIN_FAILED",
                        timestamp = DateTime.UtcNow
                    });
                }
                
                // 로그인 성공 시 200 OK 반환
                return Ok(new
                {
                    success = true,
                    message = result.Message,
                    token = result.Token,
                    admin = result.Admin,
                    timestamp = DateTime.UtcNow
                });
            }
            catch (Exception ex)
            {
                // 예외 발생 시 500 Internal Server Error 반환
                return StatusCode(500, new
                {
                    success = false,
                    message = "로그인 처리 중 오류가 발생했습니다.",
                    error = "INTERNAL_SERVER_ERROR",
                    details = ex.Message,
                    timestamp = DateTime.UtcNow
                });
            }
        }
    }
}