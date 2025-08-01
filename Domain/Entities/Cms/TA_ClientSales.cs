using System.ComponentModel.DataAnnotations;

namespace AGL.Api.Domain.Entities
{
    public class TA_ClientSales
    {
        [Key]
        [Required]
        public string StoreSaleId { get; set; }
        public string SalesItemId { get; set; }
        public string FieldId { get; set; }
        public string SaleDateInLocal { get; set; }
        public DateTime CreatedDate { get; set; }
        public string OpId { get; set; }
        public int ItemCount { get; set; }
        public decimal Price { get; set; }
        public string CurrencyOrigin { get; set; }
        public string CurrencyDestination { get; set; }
        public decimal ExchangeRate { get; set; }
        public int Status { get; set; }
        public decimal? Discount { get; set; }
        public string? DiscountReason { get; set; }
        public decimal Commission { get; set; }
        public decimal TotalPrice { get; set; }
        public string? CheckinMemberId { get; set; }
        public int PrePaid { get; set; }
        public int Point { get; set; }
        public string TransactionId { get; set; }
        public int Checked { get; set; }
        public int Paid { get; set; }
        public string? SamePaymentId { get; set; }
        public string? CheckinId { get; set; }
        public decimal Tax { get; set; }
        public DateTime LastUpdate { get; set; }
        public string? Memo { get; set; }
        public int DiscountCode { get; set; }
        public string? OriginalTransactionId { get; set; }
        public int Splited { get; set; }
        public int DiscountPercent { get; set; }
        public string? PlayDate { get; set; }
        public string? ClientId { get; set; }
        public DateTime? RefundDate { get; set; }
        public string IsBackmargin { get; set; }
    }
}
