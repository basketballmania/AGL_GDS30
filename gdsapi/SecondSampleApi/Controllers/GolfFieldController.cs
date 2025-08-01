using AGL.Api.ApplicationCore.Exceptions;
using AGL.Api.ApplicationCore.Infrastructure.Base;
using AGL.Api.ApplicationCore.Models.Enum;
using Asp.Versioning;
using SecondSampleApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using SecondSampleApi.DTOs.Request;

namespace SecondSampleApi.Controllers
{
    [ApiController]
    [Route("v{version:apiVersion}/secondsample/golffields")]
    public class GolfFieldController : BaseController
    {
        private readonly IGolfFieldService _golfFieldService;

        public GolfFieldController(IGolfFieldService golfFieldService)
        {
            _golfFieldService = golfFieldService;
        }

        /// <summary>
        /// 골프장 목록 조회
        /// </summary>
        /// <param name="parameter">검색 파라미터</param>
        /// <returns>골프장 목록</returns>
        [ApiVersion("1.0")]
        [HttpGet]
        public async Task<IActionResult> GetGolfFields([FromQuery] string? parameter)
        {
            var golfFields = await _golfFieldService.GetGolfFields(parameter);
            return Ok(golfFields);
        }

        /// <summary>
        /// 골프장 상세 조회
        /// </summary>
        /// <param name="fieldId">골프장 ID</param>
        /// <returns>골프장 상세 정보</returns>
        [ApiVersion("1.0")]
        [HttpGet("{fieldId}")]
        public async Task<IActionResult> GetGolfFieldById(string fieldId)
        {
            var golfField = await _golfFieldService.GetGolfFieldById(fieldId);
            if (golfField == null)
                return NotFound();
            return Ok(golfField);
        }

        /// <summary>
        /// 골프장 생성
        /// </summary>
        /// <param name="request">골프장 생성 요청</param>
        /// <returns>생성된 골프장 정보</returns>
        [ApiVersion("1.0")]
        [HttpPost]
        public async Task<IActionResult> CreateGolfField([FromBody] GolfFieldRequestDto request)
        {
            var createdGolfField = await _golfFieldService.CreateGolfField(request);
            return CreatedAtAction(nameof(GetGolfFieldById), new { fieldId = createdGolfField.FieldId }, createdGolfField);
        }

        /// <summary>
        /// 골프장 수정
        /// </summary>
        /// <param name="fieldId">골프장 ID</param>
        /// <param name="request">골프장 수정 요청</param>
        /// <returns>수정된 골프장 정보</returns>
        [ApiVersion("1.0")]
        [HttpPut("{fieldId}")]
        public async Task<IActionResult> UpdateGolfField(string fieldId, [FromBody] GolfFieldRequestDto request)
        {
            var updatedGolfField = await _golfFieldService.UpdateGolfField(fieldId, request);
            return Ok(updatedGolfField);
        }

        /// <summary>
        /// 골프장 삭제
        /// </summary>
        /// <param name="fieldId">골프장 ID</param>
        /// <returns>삭제 결과</returns>
        [ApiVersion("1.0")]
        [HttpDelete("{fieldId}")]
        public async Task<IActionResult> DeleteGolfField(string fieldId)
        {
            var result = await _golfFieldService.DeleteGolfField(fieldId);
            return Ok(result);
        }
    }
} 