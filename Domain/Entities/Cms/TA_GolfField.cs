using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AGL.Api.Domain.Entities
{
    public class TA_GolfField
    {
        /// <summary>
        /// 골프장ID
        /// <summary>
        [Required]
        [Key]
        public string FieldId { get; set; }
        /// <summary>
        /// 골프장명
        /// <summary>
        [Required]

        public string FieldName { get; set; }
        /// <summary>
        /// 위치
        /// <summary>
        [Required]

        public int Location { get; set; }
        /// <summary>
        /// 전화번호
        /// <summary>
        [Required]

        public string Phone { get; set; }
        /// <summary>
        /// 팩스
        /// <summary>
        [Required]

        public string Fax { get; set; }
        /// <summary>
        /// 경도
        /// <summary>
        [Required]

        public string Longitude { get; set; }
        /// <summary>
        /// 위도
        /// <summary>
        [Required]

        public string Latitude { get; set; }
        /// <summary>
        /// 주소
        /// <summary>
        [Required]

        public string Address { get; set; }
        /// <summary>
        /// 언어
        /// <summary>
        [Required]

        public string Language { get; set; }
        /// <summary>
        /// 홀수
        /// <summary>
        [Required]

        public int Holes { get; set; }
        /// <summary>
        /// 전체Par
        /// <summary>
        [Required]

        public int Par { get; set; }
        /// <summary>
        /// 길이
        /// <summary>
        public int? Length { get; set; }
        /// <summary>
        /// 길이단위
        /// <summary>
        public string? LengthDimension { get; set; }
        /// <summary>
        /// 통화단위
        /// <summary>
        public string? DefaultCurrency { get; set; }
        /// <summary>
        /// 시간대
        /// <summary>
        [Required]

        public int TimeZone { get; set; } = 420;
        /// <summary>
        /// SummerTime
        /// <summary>
        [Required]

        public int SummerTime { get; set; } = 0;
        /// <summary>
        /// 영문 골프장명
        /// <summary>
        public string? FieldNameEng { get; set; }
        /// <summary>
        /// E-Mail
        /// <summary>
        public string? Email { get; set; }
        /// <summary>
        /// 사용여부/*** Pass에서는 권한설정으로 사용한다.
        /// <summary>
        [Required]

        public int UsdEnable { get; set; } = 0;
        /// <summary>
        /// 영문 주소
        /// <summary>
        public string? AddressEng { get; set; }
        /// <summary>
        /// 세금종류1
        /// <summary>
        public decimal? Tax1 { get; set; } = 0;
        /// <summary>
        /// 세금종류2
        /// <summary>
        public decimal? Tax2 { get; set; } = 0;
        /// <summary>
        /// 세금종류3
        /// <summary>
        public decimal? Tax3 { get; set; } = 0;
        /// <summary>
        /// 세금종류4
        /// <summary>
        public decimal? Tax4 { get; set; } = 0;
        /// <summary>
        /// 
        /// <summary>
        [Required]

        public int UnitCount { get; set; } = 9;
        /// <summary>
        /// 그룹ID
        /// <summary>
        [Required]

        public string GroupId { get; set; }
        /// <summary>
        /// 
        /// <summary>
        public string? AccommodationId { get; set; }
        /// <summary>
        /// 
        /// <summary>
        [Required]

        public int GroupType { get; set; } = 0;
        /// <summary>
        /// 
        /// <summary>
        public string? CompanyName { get; set; }
        /// <summary>
        /// 
        /// <summary>
        public string? CompanyNameEng { get; set; }
        /// <summary>
        /// 
        /// <summary>
        public int? PenaltyCloseTime { get; set; } = 17;
        /// <summary>
        /// 
        /// <summary>
        public int? IsPublic { get; set; }
        /// <summary>
        /// 
        /// <summary>
        public string? FieldCode { get; set; }
        /// <summary>
        /// 
        /// <summary>
        public string? Homepage { get; set; }
        /// <summary>
        /// 1:TigerPass,2,4(teeupNjoy)불러오는내용: 사용중 1024: GDS가능

        /// <summary>
        public int? FieldType { get; set; } = 1;
        /// <summary>
        /// 

        /// <summary>
        public string? linkids { get; set; }
        /// <summary>
        /// 통화종류

        /// <summary>
        [Required]

        public string Currency { get; set; } = "KRW";
        /// <summary>
        /// 국가코드 TA_CountryCode 맞물림

        /// <summary>
        public string? CountryCode { get; set; }
        /// <summary>
        /// 

        /// <summary>
        public string? FieldNameKor { get; set; }
        /// <summary>
        /// 

        /// <summary>
        public int? IsKoreanStaff { get; set; } = 0;
        /// <summary>
        /// 

        /// <summary>
        public int? IsWifi { get; set; } = 0;
        /// <summary>
        /// 

        /// <summary>
        public int? IsCaddie { get; set; } = 0;
        /// <summary>
        /// 
        /// <summary>
        public int? IsGolfCart { get; set; } = 0;
        /// <summary>
        /// 
        /// <summary>
        public int? IsProShop { get; set; } = 0;
        /// <summary>
        /// 
        /// <summary>
        public int? IsSnackBar { get; set; } = 0;
        /// <summary>
        /// 
        /// <summary>
        public int? IsRestaurant { get; set; } = 0;
        /// <summary>
        /// 
        /// <summary>
        public int? IsKoreanFood { get; set; } = 0;
        /// <summary>
        /// 
        /// <summary>
        public int? IsDrivingRange { get; set; } = 0;
        /// <summary>
        /// 
        /// <summary>
        public int? IsPuttingRange { get; set; } = 0;
        /// <summary>
        /// 
        /// <summary>
        public int? IsGolfAcademy { get; set; } = 0;
        /// <summary>
        /// 
        /// <summary>
        public int? IsPickUpService { get; set; } = 0;
        /// <summary>
        /// 
        /// <summary>
        public int? IsLockerRoom { get; set; } = 0;
        /// <summary>
        /// 
        /// <summary>
        public int? IsMassageShop { get; set; } = 0;
        /// <summary>
        /// 
        /// <summary>
        public int? IsClubRental { get; set; } = 0;
        /// <summary>
        /// 
        /// <summary>
        public int? IsKoreanAvailable { get; set; } = 0;
        /// <summary>
        /// 
        /// <summary>
        public int? IsEnglishAvailable { get; set; } = 0;
        /// <summary>
        /// 
        /// <summary>
        public int? IsJapaneseAvailable { get; set; } = 0;
        /// <summary>
        /// 
        /// <summary>
        public int? IsChineseAvailable { get; set; } = 0;
        /// <summary>
        /// 
        /// <summary>
        public int? TeetimeGatherType { get; set; } = 1;
        /// <summary>
        /// 
        /// <summary>
        public decimal? MinPrice { get; set; }
        /// <summary>
        /// 
        /// <summary>
        public decimal? MaxPrice { get; set; }
        /// <summary>
        /// 
        /// <summary>
        public int? IsTeetimeTomorrow { get; set; } = 0;
        /// <summary>
        /// 
        /// <summary>
        public string? OneLineKor { get; set; }
        /// <summary>
        /// 
        /// <summary>
        public string? OneLineEng { get; set; }
        /// <summary>
        /// Google PlaceId
        /// <summary>
        public string? PlaceId { get; set; }
        /// <summary>
        /// 50% 환불가능한 기간(마지막기간) 2주면 15
        /// <summary>
        public int? Refund_50 { get; set; }
        /// <summary>
        /// 0% 환불(환불불가 마지막일자) 7일이면 8로
        /// <summary>
        public int? Refund_0 { get; set; }
        /// <summary>
        /// 
        /// <summary>
        public int? IsReserverEqualVisitor { get; set; } = 0;
        /// <summary>
        /// 티타임 골프장으로 되돌려주는 시간
        /// <summary>
        public int? CutOff { get; set; } = 0;
        /// <summary>
        /// 
        /// <summary>
        public int? MustPickup { get; set; } = 0;
        /// <summary>
        /// 
        /// <summary>
        public string? MustOption { get; set; }
        /// <summary>
        /// 
        /// <summary>
        public int? IncludeCart { get; set; } = 0;
        /// <summary>
        /// 
        /// <summary>
        public int? IncludeCaddie { get; set; } = 0;
        /// <summary>
        /// 
        /// <summary>
        public int? IncludeAccommodation { get; set; } = 0;
        /// <summary>
        /// 
        /// <summary>
        public int? IncludePickUp { get; set; } = 0;
        /// <summary>
        /// 
        /// <summary>
        public string? SaleOpenTime { get; set; }
        /// <summary>
        /// 
        /// <summary>
        public string? BrandName { get; set; }
        /// <summary>
        /// 
        /// <summary>
        public int? MustMember { get; set; }
        /// <summary>
        /// 
        /// <summary>
        public int? IsWeddingChapel { get; set; }
        /// <summary>
        /// 
        /// <summary>
        public int? IsAccommodation { get; set; }
        /// <summary>
        /// 
        /// <summary>
        public int? isDelete { get; set; } = 0;
        /// <summary>
        /// 
        /// <summary>
        public int? PlayDays { get; set; }
        /// <summary>
        /// 
        /// <summary>
        public int? PlayNights { get; set; }
        /// <summary>
        /// 
        /// <summary>
        public int? PlayCount { get; set; }
        /// <summary>
        /// 
        /// <summary>
        public int? StartDays { get; set; }
        /// <summary>
        /// 1 : LandMark 2 : Hotel Package4 : Hotel 항공 Package 8 : Exclusive
        /// <summary>
        public int? GDSType { get; set; }
        /// <summary>
        /// 
        /// <summary>
        public decimal? MinPriceLocal { get; set; }
        /// <summary>
        /// 
        /// <summary>
        public string? RequestURL { get; set; }
        /// <summary>
        /// TA_Area
        /// <summary>
        public string? AreaCode { get; set; }
        /// <summary>
        /// 공항정보 IATA 코드
        /// <summary>
        public string? IATA { get; set; }
        /// <summary>
        /// 
        /// <summary>
        public int? SortOrder { get; set; } = 99999;
    }
}
