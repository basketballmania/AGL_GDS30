using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace AGL.Api.Domain.Entities
{
    public class TA_CheckIn_Members
    {
        [Key]
        [Required]
        public string CheckinMemberId { get; set; }
        public string CheckInId { get; set; }
        public string? MemberId { get; set; }
        public string MemberName { get; set; }
        public string? MemberPhone { get; set; }
        public string? Nationality { get; set; }
        public string? MemberEmail { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? Status { get; set; }
        public decimal? Handicap { get; set; }
        public int CurrentFieldMember { get; set; }
        public string? Gender { get; set; }
        public int MemberType { get; set; }
        public decimal TeePrice { get; set; }
        public string? Currency { get; set; }
        public decimal? Tax1 { get; set; }
        public decimal? Tax2 { get; set; }
        public decimal? Tax3 { get; set; }
        public decimal? Tax4 { get; set; }
        public decimal? Discount { get; set; }
        public string? DiscountId { get; set; }
        public string? PriceId { get; set; }
        public decimal? AdditionalPrice { get; set; }
        public decimal? AdditionalPrice2 { get; set; }
        public int IsSuspend { get; set; }
        public int SuspendHole { get; set; }
        public decimal? RefundPrice { get; set; }
        public int Paid { get; set; }
        public string? SamePaymentId { get; set; }
        public string? OtherKey { get; set; }
        public string? CheckinTime { get; set; }
        public string? CheckoutTime { get; set; }
        public string? MemberKindId { get; set; }
        public int MemberCount { get; set; }
        public int HoleCount { get; set; }
        public decimal CartPrice { get; set; }
        public int PointRate { get; set; }
        public decimal SalePrice { get; set; }
        public decimal CaddiePrice { get; set; }
        public decimal AccommodiationPrice { get; set; }
        public decimal MiscPrice { get; set; }
        public DateTime LastUpdate { get; set; }
        public decimal SaleNPrice { get; set; }
        public decimal FacilityPrice { get; set; }
        public int SortOrder { get; set; }
        public int IsRepresentative { get; set; }
        public string? OuterLocker { get; set; }
        public string? ClientId { get; set; }
        public decimal? PriceClient { get; set; }
        public decimal? PriceOTA { get; set; }
        public int? IsEditedName { get; set; }
        public string? InboundKey { get; set; }
        public string? PlayerSerialNo { get; set; }
        public decimal? RefundPrice_Cart { get; set; }
    }
}
