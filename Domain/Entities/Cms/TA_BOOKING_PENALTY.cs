using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AGL.Api.Domain.Entities
{
    /// <summary>
    /// 예약 패널티
    /// </summary>
    [Table("TA_BOOKING_PENALTY", Schema = "dbo")]
    public class TA_BOOKING_PENALTY
    {
        /// <summary>
        /// 예약 패널티 idx
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDX { get; set; }

        [Required]
        [StringLength(32)]
        public string TRANSACTIONID { get; set; } = string.Empty;

        [Required]
        [StringLength(32)]
        public string CHECKINID { get; set; } = string.Empty;

        [Required]
        [StringLength(6)]
        public string FIELDID { get; set; } = string.Empty;

        /// <summary>
        /// 환불키
        /// </summary>
        [Required]
        public int GCP_REFUND_SEQ { get; set; } = 0;

        /// <summary>
        /// 1:티타임 주중, 2:티타임 주말, 3:티타임 공휴일, 4:s&p, 9 : 구분없음
        /// </summary>
        [Required]
        public int WEEK_GUBUN { get; set; } = 1;

        /// <summary>
        /// 시작일
        /// </summary>
        public DateTime? SDATE { get; set; }

        /// <summary>
        /// 종료일
        /// </summary>
        public DateTime? EDATE { get; set; }

        /// <summary>
        /// play date까지 남은 영업일
        /// </summary>
        [Required]
        public int GIJUN_DAY { get; set; } = 0;

        /// <summary>
        /// 페널티일수 예약일포함여부 Y/N
        /// </summary>
        [Required]
        [StringLength(1)]
        public string REV_DAY_YN { get; set; } = "N";

        /// <summary>
        /// 패널티구분코드 / 1:요율, 2:요금
        /// </summary>
        [Required]
        public int PENALTY_GUBUN { get; set; } = 1;

        /// <summary>
        /// 환불내용코드 code_menu.cmenu_seq=152
        /// </summary>
        [Required]
        public int PENALTY_CODE { get; set; } = 0;

        /// <summary>
        /// 패널티 금액 or 퍼센트
        /// </summary>
        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal PENALTY_VALUE { get; set; } = 0.00M;

        /// <summary>
        /// 패널티기간 단위-월
        /// </summary>
        [Required]
        public int PENALTY_MONTH { get; set; } = 0;

        /// <summary>
        /// 취소가능일시
        /// </summary>
        public DateTime? CANCEL_USE_DATE { get; set; }

        /// <summary>
        /// 환불 자동추가일
        /// </summary>
        [Required]
        public int PENALTY_PLUS_DAY { get; set; } = 0;

        /// <summary>
        /// 예약 패널티 금액 /환산된 위약금
        /// </summary>
        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal PENALTY_PRICE { get; set; } = 0.00M;

        /// <summary>
        /// 결제화폐
        /// </summary>
        [StringLength(50)]
        public string PRICE_CURRENCY { get; set; } = string.Empty;

        /// <summary>
        /// 당시 환율(KRW>결제화폐)
        /// </summary>
        [Required]
        [Column(TypeName = "decimal(11,10)")]
        public decimal CURRENCY_RATE { get; set; } = 0.0000000000M;
    }
}
