using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AGL.Api.Domain.Entities
{
    public class TA_CheckIn
    {
        [Key]
        [Display(Name = "CheckinId"), Required]
        public string CheckinId { get; set; } // CheckinId, PK

        [Display(Name = "MemberId")]
        public string? MemberId { get; set; } // MemberId, nullable

        [Display(Name = "MemberName")]
        public string? MemberName { get; set; } // MemberName, nullable

        [Display(Name = "MemberPhone")]
        public string? MemberPhone { get; set; } // MemberPhone, nullable

        [Display(Name = "Nationality")]
        public string? Nationality { get; set; } // Nationality, nullable

        [Display(Name = "IsCheckIn"), Required]
        public int IsCheckIn { get; set; } // IsCheckIn, non-nullable

        [Display(Name = "CreatedDate"), Required]
        public DateTime CreatedDate { get; set; } // CreatedDate, non-nullable

        [Display(Name = "CheckInTime")]
        public DateTime? CheckInTime { get; set; } // CheckInTime, nullable

        [Display(Name = "CancelDate")]
        public DateTime? CancelDate { get; set; } // CancelDate, nullable

        [Display(Name = "IsRepresent"), Required]
        public int IsRepresent { get; set; } // IsRepresent, non-nullable

        [Display(Name = "ResvAgency")]
        public string? ResvAgency { get; set; } // ResvAgency, nullable

        [Display(Name = "IsConfirm")]
        public int? IsConfirm { get; set; } // IsConfirm, nullable

        [Display(Name = "MemberEmail")]
        public string MemberEmail { get; set; } // MemberEmail, nullable

        [Display(Name = "TransactionId"), Required]
        public string TransactionId { get; set; } // TransactionId, non-nullable

        [Display(Name = "ReservedPlayerCount"), Required]
        public int ReservedPlayerCount { get; set; } // ReservedPlayerCount, non-nullable

        [Display(Name = "CreditLimit"), Required]
        public decimal CreditLimit { get; set; } // CreditLimit, non-nullable

        [Display(Name = "CreditLimitCurrency"), Required]
        public string CreditLimitCurrency { get; set; } // CreditLimitCurrency, non-nullable

        [Display(Name = "Opid")]
        public string? Opid { get; set; } // Opid, nullable

        [Display(Name = "PlayDate"), Required]
        public string PlayDate { get; set; } // PlayDate, non-nullable

        [Display(Name = "CheckoutTime")]
        public DateTime? CheckoutTime { get; set; } // CheckoutTime, nullable

        [Display(Name = "CheckoutOp")]
        public string? CheckoutOp { get; set; } // CheckoutOp, nullable

        [Display(Name = "PNR")]
        public string? PNR { get; set; } // PNR, nullable

        [Display(Name = "IATACode")]
        public string? IATACode { get; set; } // IATACode, nullable

        [Display(Name = "ClientId")]
        public string? ClientId { get; set; } // ClientId, nullable

        [Display(Name = "FieldId"), Required]
        public string FieldId { get; set; } // FieldId, non-nullable

        [Display(Name = "CheckinType")]
        public int? CheckinType { get; set; } // CheckinType, nullable

        [Display(Name = "FieldReservationType")]
        public int? FieldReservationType { get; set; } // FieldReservationType, nullable

        [Display(Name = "FieldReservationTypeName")]
        public string? FieldReservationTypeName { get; set; } // FieldReservationTypeName, nullable

        [Display(Name = "T_StartTime")]
        public string? T_StartTime { get; set; } // T_StartTime, nullable

        [Display(Name = "T_CourseId")]
        public string? T_CourseId { get; set; } // T_CourseId, nullable

        [Display(Name = "Memo")]
        public string? Memo { get; set; } // Memo, nullable

        [Display(Name = "ShowName")]
        public string? ShowName { get; set; } // ShowName, nullable

        [Display(Name = "ShowPhone")]
        public string? ShowPhone { get; set; } // ShowPhone, nullable

        [Display(Name = "CheckoutMemo")]
        public string? CheckoutMemo { get; set; } // CheckoutMemo, nullable

        [Display(Name = "ProcessMemo")]
        public string? ProcessMemo { get; set; } // ProcessMemo, nullable

        [Display(Name = "SMSSent"), Required]
        public int SMSSent { get; set; } // SMSSent, non-nullable

        [Display(Name = "SMSDate")]
        public DateTime? SMSDate { get; set; } // SMSDate, nullable

        [Display(Name = "ConfirmOp")]
        public string? ConfirmOp { get; set; } // ConfirmOp, nullable

        [Display(Name = "HoldingOp")]
        public string? HoldingOp { get; set; } // HoldingOp, nullable

        [Display(Name = "DiscountGroupCode")]
        public string? DiscountGroupCode { get; set; } // DiscountGroupCode, nullable

        [Display(Name = "ReqStartTime")]
        public string? ReqStartTime { get; set; } // ReqStartTime, nullable

        [Display(Name = "ReqStartTime2")]
        public string? ReqStartTime2 { get; set; } // ReqStartTime2, nullable

        [Display(Name = "WaitOrder"), Required]
        public int WaitOrder { get; set; } // WaitOrder, non-nullable

        [Display(Name = "GroupId")]
        public string? GroupId { get; set; } // GroupId, nullable

        [Display(Name = "IsCheckOut"), Required]
        public int IsCheckOut { get; set; } // IsCheckOut, non-nullable

        [Display(Name = "LastUpdate"), Required]
        public DateTime LastUpdate { get; set; } // LastUpdate, non-nullable

        [Display(Name = "RealStartTime")]
        public string? RealStartTime { get; set; } // RealStartTime, nullable

        [Display(Name = "RealCourseId")]
        public string? RealCourseId { get; set; } // RealCourseId, nullable

        [Display(Name = "ConfirmTime")]
        public DateTime? ConfirmTime { get; set; } // ConfirmTime, nullable

        [Display(Name = "DelegateMemberId")]
        public string? DelegateMemberId { get; set; } // DelegateMemberId, nullable

        [Display(Name = "DelegateMemberName")]
        public string? DelegateMemberName { get; set; } // DelegateMemberName, nullable

        [Display(Name = "DelegateMemberPhone")]
        public string? DelegateMemberPhone { get; set; } // DelegateMemberPhone, nullable

        [Display(Name = "CancelMemberName")]
        public string? CancelMemberName { get; set; } // CancelMemberName, nullable

        [Display(Name = "CancelMemberPhone")]
        public string? CancelMemberPhone { get; set; } // CancelMemberPhone, nullable

        [Display(Name = "IsVIP")]
        public int? IsVIP { get; set; } // IsVIP, nullable

        [Display(Name = "OriginalTransactionId")]
        public string? OriginalTransactionId { get; set; } // OriginalTransactionId, nullable

        [Display(Name = "ReserveCondition")]
        public int? ReserveCondition { get; set; } // ReserveCondition, nullable

        [Display(Name = "PartnerPrice")]
        public decimal? PartnerPrice { get; set; } // PartnerPrice, nullable

        [Display(Name = "MemberCount")]
        public int? MemberCount { get; set; } // MemberCount, nullable

        [Display(Name = "PartnerSerial")]
        public string? PartnerSerial { get; set; } // PartnerSerial, nullable

        [Display(Name = "PartnerCartPrice")]
        public decimal? PartnerCartPrice { get; set; } // PartnerCartPrice, nullable

        [Display(Name = "FlightEnterDate")]
        public string? FlightEnterDate { get; set; } // FlightEnterDate, nullable

        [Display(Name = "FlightLeaveDate")]
        public string? FlightLeaveDate { get; set; } // FlightLeaveDate, nullable

        [Display(Name = "FlightEnterNumber")]
        public string? FlightEnterNumber { get; set; } // FlightEnterNumber, nullable

        [Display(Name = "FlightLeaveNumber")]
        public string? FlightLeaveNumber { get; set; } // FlightLeaveNumber, nullable

        [Display(Name = "PartnerAdditionalPrice")]
        public decimal? PartnerAdditionalPrice { get; set; } // PartnerAdditionalPrice, nullable

        [Display(Name = "InboundNumber")]
        public string? InboundNumber { get; set; } // InboundNumber, nullable

        [Display(Name = "InboundKey")]
        public string? InboundKey { get; set; } // InboundKey, nullable

        [Display(Name = "SettlementType"), Required]
        public int SettlementType { get; set; }

    }

}