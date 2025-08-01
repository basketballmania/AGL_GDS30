using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AGL.Api.Domain.Entities
{
    [Table("TA_OTAPayment")]
    [Description("[GDS] 결제 정보")]
    public class TA_OTAPayment
    {
        [Key]
        [Column("OTAPaymentID")]
        [StringLength(32)]
        [Description("결제 고유 ID")]
        public string OTAPaymentID { get; set; } = null!;

        [Required]
        [Column("TransactionID")]
        [StringLength(32)]
        [Description("거래 ID")]
        public string TransactionID { get; set; } = null!;

        [Column("MemberID")]
        [StringLength(32)]
        [Description("회원 ID")]
        public string? MemberID { get; set; }

        [Required]
        [Column("Price")]
        [Description("결제 금액")]
        public decimal Price { get; set; }

        [Required]
        [Column("PriceCurrency")]
        [StringLength(3)]
        [Description("결제 통화")]
        public string PriceCurrency { get; set; } = null!;

        [Required]
        [Column("CreatedDate")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Description("결제 생성 날짜")]
        public DateTime CreatedDate { get; set; }

        [Column("SaleDateInLocal")]
        [StringLength(8)]
        [Description("현지 판매 날짜 (YYYYMMDD)")]
        public string? SaleDateInLocal { get; set; }

        [Column("PaymentDateInLocal")]
        [StringLength(8)]
        [Description("현지 결제 날짜 (YYYYMMDD)")]
        public string? PaymentDateInLocal { get; set; }

        [Column("PaymentMethod")]
        [Description("결제 방법")]
        public int? PaymentMethod { get; set; }

        [Column("OpId")]
        [StringLength(32)]
        [Description("운영자 ID")]
        public string? OpId { get; set; }

        [Column("TransactionDetail")]
        [StringLength(2048)]
        [Description("거래 상세 정보")]
        public string? TransactionDetail { get; set; }

        [Column("TransactionKey")]
        [StringLength(64)]
        [Description("거래 키")]
        public string? TransactionKey { get; set; }

        [Column("StripeId")]
        [StringLength(64)]
        [Description("Stripe 결제 ID")]
        public string? StripeId { get; set; }

        [Column("StripeCustomer")]
        [StringLength(64)]
        [Description("Stripe 고객 ID")]
        public string? StripeCustomer { get; set; }

        [Column("PaymentCode")]
        [StringLength(3)]
        [Description("결제 코드 (예: CAD, KAK, STR)")]
        public string? PaymentCode { get; set; }

        [Required]
        [Column("Status")]
        [Description("결제 상태 (0: 무시, 1: 정상, 2: 취소, 3: 취소에 대한 원거래)")]
        public int Status { get; set; } = 0;

        [Column("CardNumber")]
        [StringLength(20)]
        [Description("카드 번호 (마스킹 처리)")]
        public string? CardNumber { get; set; }

        [Column("PaymentName")]
        [StringLength(255)]
        [Description("결제명")]
        public string? PaymentName { get; set; }

        [Column("ClientId")]
        [StringLength(32)]
        [Description("클라이언트 ID")]
        public string? ClientId { get; set; }

        [Column("OriginalPaymentId")]
        [StringLength(32)]
        [Description("원 결제 ID")]
        public string? OriginalPaymentId { get; set; }

        [Required]
        [Column("CardPurchaseNo")]
        [Description("카드 거래 횟수")]
        public int CardPurchaseNo { get; set; } = 0;

        [Required]
        [Column("LastUpdate")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Description("마지막 업데이트 시간")]
        public DateTime LastUpdate { get; set; }

        [Required]
        [Column("Tax")]
        [Description("세금 금액")]
        public decimal Tax { get; set; } = 0;

        [Column("Memo")]
        [StringLength(256)]
        [Description("메모")]
        public string? Memo { get; set; }

        [Column("OriginalTransactionId")]
        [StringLength(32)]
        [Description("원 거래 ID")]
        public string? OriginalTransactionId { get; set; }

        [Column("MemberPhone")]
        [StringLength(64)]
        [Description("회원 전화번호")]
        public string? MemberPhone { get; set; }

        [Column("MemberEmail")]
        [StringLength(128)]
        [Description("회원 이메일")]
        public string? MemberEmail { get; set; }

        [Column("SiteCurrency")]
        [StringLength(3)]
        [Description("사이트 결제 통화")]
        public string? SiteCurrency { get; set; }

        [Column("SitePrice")]
        [Description("사이트 결제 금액")]
        public decimal? SitePrice { get; set; }

        [Column("InterfaceSite")]
        [StringLength(10)]
        [Description("연동 사이트")]
        public string? InterfaceSite { get; set; }

        [Column("InterfaceMember")]
        [StringLength(100)]
        [Description("연동 회원")]
        public string? InterfaceMember { get; set; }

        // Foreign Key Relationship
        [ForeignKey("TransactionID")]
        public virtual TA_Transactions Transaction { get; set; } = null!;
    }
}
