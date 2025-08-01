using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AGL.Api.Domain.Entities
{
    [Table("TA_Payment")]
    public class TA_Payment
    {
        [Key]
        [Column(TypeName = "char(32)")]
        public string PaymentID { get; set; }

        [Required]
        [Column(TypeName = "char(32)")]
        public string TransactionID { get; set; }

        [Column(TypeName = "char(32)")]
        public string MemberID { get; set; }

        [Required]
        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        [Required]
        [Column(TypeName = "char(3)")]
        public string PriceCurrency { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        [Column(TypeName = "char(8)")]
        public string SaleDateInLocal { get; set; }

        [Column(TypeName = "char(8)")]
        public string PaymentDateInLocal { get; set; }

        public int? PaymentMethod { get; set; }

        [Column(TypeName = "char(32)")]
        public string OpId { get; set; }

        [Column(TypeName = "nvarchar(2048)")]
        public string TransactionDetail { get; set; }

        [Column(TypeName = "varchar(32)")]
        public string HashData { get; set; }

        [Column(TypeName = "varchar(64)")]
        public string TransactionKey { get; set; }

        [Column(TypeName = "varchar(64)")]
        public string StripeId { get; set; }

        [Column(TypeName = "varchar(64)")]
        public string StripeCustomer { get; set; }

        [Column(TypeName = "char(3)")]
        public string PaymentCode { get; set; }

        [Required]
        public int Status { get; set; } = 0;

        [Column(TypeName = "varchar(20)")]
        public string CardNumber { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string PaymentName { get; set; }

        [Column(TypeName = "char(6)")]
        public string FieldId { get; set; }

        [Column(TypeName = "char(32)")]
        public string ShopId { get; set; }

        [Column(TypeName = "char(32)")]
        public string SamePaymentId { get; set; }

        [Column(TypeName = "char(32)")]
        public string CheckinMemberId { get; set; }

        [Column(TypeName = "char(32)")]
        public string CheckinShopId { get; set; }

        public int? PaymentLocation { get; set; } = 32;

        [Column(TypeName = "char(32)")]
        public string OriginalPaymentId { get; set; }

        [Column(TypeName = "char(32)")]
        public string CheckinId { get; set; }

        [Required]
        public int CardPurchaseNo { get; set; } = 0;

        [Required]
        public DateTime LastUpdate { get; set; } = DateTime.UtcNow;

        [Required]
        [Column(TypeName = "money")]
        public decimal Tax { get; set; } = 0;

        [Column(TypeName = "nvarchar(256)")]
        public string Memo { get; set; }

        [Column(TypeName = "char(32)")]
        public string OriginalTransactionId { get; set; }

        [Column(TypeName = "char(32)")]
        public string OriginalShopId { get; set; }

        [Column(TypeName = "varchar(32)")]
        public string PartnerLink { get; set; }

        [ForeignKey("TransactionID")]
        public virtual TA_Transactions Transaction { get; set; }
    }
}