using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AGL.Api.Domain.Entities
{
    public class TA_TeeTime
    {
        /// <summary>
        /// 
        /// <summary>
        [Key]
        [Required]
        [Column(TypeName = "char(32)")]
        public string TimeId { get; set; }
        /// <summary>
        /// 
        /// <summary>
        [Required]
        [Column(TypeName = "char(6)")]

        public string FieldId { get; set; }
        /// <summary>
        /// 
        /// <summary>
        [Required]
        [Column(TypeName = "char(32)")]
        public string CourseId { get; set; }
        /// <summary>
        /// 
        /// <summary>
        [Required]
        [Column(TypeName = "char(8)")]
        public string PlayDate { get; set; }
        /// <summary>
        /// 
        /// <summary>
        [Required]
        [Column(TypeName = "char(4)")]
        public string StartTime { get; set; }
        /// <summary>
        /// 
        /// <summary>
        [Required]

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        /// <summary>
        /// 
        /// <summary>
        public int? MinMembers { get; set; }
        /// <summary>
        /// 
        /// <summary>
        public int? MaxMembers { get; set; }
        /// <summary>
        /// 0:예약불가, 1:정상_모든단말예약가능, 2:정상_자사인터넷과현장만예약가능, 3:정상,현장만예약가능, 4:정상, 일반권한으로예약불가(Block) 5:정상:Holding 9:정상:대행사만 예약가능
        /// <summary>
        public int? CurrentStatus { get; set; }
        /// <summary>
        /// 
        /// <summary>
        public string? Operator { get; set; }
        /// <summary>
        /// 
        /// <summary>
        public DateTime? RequestDate { get; set; }
        /// <summary>
        /// 
        /// <summary>
        [Required]

        public int ReservationType { get; set; } = 0;
        /// <summary>
        /// 회원제 타임 구분
        /// <summary>
        [Required]

        public int TimeSort { get; set; } = 0;
        /// <summary>
        /// '0':Actual '1':Deleted
        /// <summary>
        [Required]

        public int Deleted { get; set; } = 0;
        /// <summary>
        /// 
        /// <summary>
        [Required]

        public string TGId { get; set; } = "";
        /// <summary>
        /// 
        /// <summary>
        public string? CheckinId { get; set; }
        /// <summary>
        /// 연계된 TimeId
        /// <summary>
        public string? LinkedId { get; set; }
        /// <summary>
        /// 
        /// <summary>
        public string? OriginalLinkedId { get; set; }
        /// <summary>
        /// 
        /// <summary>
        public string? DiscountId { get; set; }
        /// <summary>
        /// 
        /// <summary>
        [Required]

        public int Serial { get; set; } = 0;
        /// <summary>
        /// 
        /// <summary>
        public string? TimeName { get; set; }
        /// <summary>
        /// 외부 공개 여부(0:비공개, 1:공개)
        /// <summary>
        public int? IsOpenPublic { get; set; }
        /// <summary>
        /// 온라인 예약 가능 여부(0: 불가, 1: 가능)
        /// <summary>
        public int? EnableOnlineReservation { get; set; }
        /// <summary>
        /// 위임 요청한 멤버타입 정의
        /// <summary>
        public int? RequestMemberType { get; set; }
        /// <summary>
        /// 위탁판매처(2 ^32)까지 정리된 Bigint 사용
        /// <summary>
        [Required]

        public long ClientFlag { get; set; } = 0;
        /// <summary>
        /// 
        /// <summary>
        [Required]

        public int HoleCount { get; set; } = 9;
        /// <summary>
        /// 
        /// <summary>
        public string? OpenTime { get; set; }
        /// <summary>
        /// 
        /// <summary>
        public string? CloseTime { get; set; }
        /// <summary>
        /// 
        /// <summary>
        public DateTime? LastUpdate { get; set; }
        /// <summary>
        /// 
        /// <summary>
        public string? BlockReason { get; set; }
        /// <summary>
        /// 0:IsCaddie, 1:NoCaddie
        /// <summary>
        public long? ReservationKind { get; set; } = 0;
        /// <summary>
        /// 
        /// <summary>
        public string? OpId { get; set; }
        /// <summary>
        /// 
        /// <summary>
        public DateTime? BlockTime { get; set; }
        /// <summary>
        /// GDS : Teeprice로 사용(2,3,4 인용)
        /// <summary>
        public decimal? OuterPrice { get; set; }
        /// <summary>
        /// GDS : SinglePrice TeePrice로 사용(1인용)
        /// <summary>
        public decimal? OriginalOuterPrice { get; set; }
        /// <summary>
        /// 
        /// <summary>
        public int? GameTimes { get; set; } = 1;
        /// <summary>
        /// 
        /// <summary>
        public int? IncludeCondo { get; set; } = 0;
        /// <summary>
        /// 
        /// <summary>
        public string? CondoDate { get; set; }
        /// <summary>
        /// 
        /// <summary>
        public int? IsUnLimited { get; set; } = 0;
        /// <summary>
        /// 
        /// <summary>
        public string? OuterPricingId { get; set; }
        /// <summary>
        /// 티타임 필수 항목 (BIT) 1: 카트, 2: 캐디
        /// <summary>
        public int? MandatoryItems { get; set; } = 0;
        /// <summary>
        /// 
        /// <summary>
        public decimal? OuterPrice_1P { get; set; }
        /// <summary>
        /// 
        /// <summary>
        public decimal? OuterPrice_2P { get; set; }
        /// <summary>
        /// 
        /// <summary>
        public decimal? OuterPrice_3P { get; set; }
    }

}
