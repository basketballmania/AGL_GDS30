using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AGL.Api.Domain.Entities
{
    public class TA_TeetimePrice_Master
    {
        /// <summary>
        /// 
        /// <summary>
        [Required]
        [Key]
        public string TPMId { get; set; }
        /// <summary>
        /// 
        /// <summary>
        public string? FieldId { get; set; }
        /// <summary>
        /// 시작일자
        /// <summary>
        public string? StartDate { get; set; }
        /// <summary>
        /// 종료일자
        /// <summary>
        public string? EndDate { get; set; }
        /// <summary>
        /// 시작시간
        /// <summary>
        public string? StartTime { get; set; }
        /// <summary>
        /// 종료시간
        /// <summary>
        public string? EndTime { get; set; }
        /// <summary>
        /// Holiday 여부
        /// <summary>
        public int? IsHoliday { get; set; } = 0;
        /// <summary>
        /// 1: 일요일 ~ 64: 토요일까지 합계
        /// <summary>
        public int? DayKind { get; set; } = 62;
        /// <summary>
        /// 1:타이거멤버
        /// <summary>
        public int? MemberKind { get; set; } = 1;
        /// <summary>
        /// 임의의 가격코드 부여
        /// <summary>
        public string? PriceCode { get; set; }
        /// <summary>
        /// 표준 Teeprice
        /// <summary>
        public decimal? TeePrice { get; set; }
        /// <summary>
        /// 
        /// <summary>
        public int? IsDelete { get; set; } = 0;
        /// <summary>
        /// 
        /// <summary>
        public DateTime? CreateDt { get; set; }
        /// <summary>
        /// 
        /// <summary>
        public string? CreateBy { get; set; }
        /// <summary>
        /// 
        /// <summary>
        public DateTime? UpdateDt { get; set; }
        /// <summary>
        /// 
        /// <summary>
        public string? UpdateBy { get; set; }
        /// <summary>
        /// 현지 GreenFee
        /// <summary>
        public decimal? GreenFeeLocal { get; set; }
        /// <summary>
        /// AGL GreenFee
        /// <summary>
        public decimal? GreenFeeAGL { get; set; }
        /// <summary>
        /// 인터넷 노출 최저 GreenFee
        /// <summary>
        public decimal? GreenFeeLimit { get; set; }
        /// <summary>
        /// 카트피 포함여부
        /// <summary>
        public int? IncludeCartFee { get; set; }
        /// <summary>
        /// 캐디피 포함여부
        /// <summary>
        public int? IncludeCaddieFee { get; set; }
        /// <summary>
        /// 
        /// <summary>
        [Required]

        public decimal GreenFee_2P { get; set; } = 0;
        /// <summary>
        /// 
        /// <summary>
        [Required]

        public decimal GreenFee_3P { get; set; } = 0;
        /// <summary>
        /// 
        /// <summary>
        [Required]

        public decimal SingleCharge { get; set; } = 0;
        /// <summary>
        /// 
        /// <summary>
        public decimal? GreenFee_1P { get; set; }
    }
}
