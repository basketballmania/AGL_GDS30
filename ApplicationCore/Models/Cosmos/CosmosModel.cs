using System.Collections.Generic;

namespace AGL.Api.ApplicationCore.Models
{
    public record PayerInfo
    {
        public string id { get; set; } = string.Empty;
        public string clientId { get; set; } = string.Empty;
        public string name { get; set; } = string.Empty;
        public string name2 { get; set; } = string.Empty;
        public string name3 { get; set; } = string.Empty;

    }

    /// <summary>
    /// 주문 정보
    /// </summary>
    public record OrderInfo
    {
        /// <summary>
        /// 회원번호 (코스모스 ID) - 필수값
        /// </summary>
        public string id { get; set; } = string.Empty;
        /// <summary>
        /// 클라이언트 ID  - 필수값
        /// </summary>
        public string clientId { get; set; } = string.Empty;
        /// <summary>
        /// 사용자 세션ID
        /// </summary>
        public string sessionId { get; set; } = string.Empty;

        /// <summary>
        /// 예약정보
        /// </summary>
        public BookingInfo bookingInfo { get; set; } = new BookingInfo();

        /// <summary>
        /// 티타임정보
        /// </summary>
        public List<BookingTeeInfo> bookingTeeInfo { get; set; } = new List<BookingTeeInfo>();

        /// <summary>
        /// 결제정보
        /// </summary>
        public PaymentInfo paymentInfo { get; set; } = new PaymentInfo();

        /// <summary>
        /// 항공정보
        /// </summary>
        public FlightInfo flightInfo { get; set; } = new FlightInfo();
    }

    /// <summary>
    /// 예약정보
    /// </summary>
    public record BookingInfo
    {
        /// <summary>
        /// 회원키
        /// </summary>
        public int user_idx { get; set; } = 0;
        /// <summary>
        /// 예약자명
        /// </summary>
        public string rev_name { get; set; } = string.Empty;
        /// <summary>
        /// 예약자명(이름)
        /// </summary>
        public string rev_first_name { get; set; } = string.Empty;
        /// <summary>
        /// 예약자명(성)
        /// </summary>
        public string rev_last_name { get; set; } = string.Empty;
        /// <summary>
        /// 예약자성별
        /// </summary>
        public string rev_sex_type { get; set; } = string.Empty;
        /// <summary>
        /// 예약자이메일
        /// </summary>
        public string rev_email { get; set; } = string.Empty;
        /// <summary>
        /// 국가코드
        /// </summary>
        public string rev_country_code { get; set; } = string.Empty;
        /// <summary>
        /// 예약자연락처
        /// </summary>
        public string rev_phone_number { get; set; } = string.Empty;
        /// <summary>
        /// 요청사항
        /// </summary>
        public string request_memo { get; set; } = string.Empty;

        /// <summary>
        /// 내장자 주소록 추가 1: 저장 0:저장x
        /// </summary>
        public int isAddressBook { get; set; } = 0;
        /// <summary>
        /// 비회원 예약시 자동 회원가입 유무 1:회원가입 0:X
        /// </summary>
        public int isSignUp { get; set; } = 0;

        /// <summary>
        /// 패널티 리스트
        /// </summary>
        public List<PenaltyInfo> penalty_info { get; set; }

        /// <summary>
        /// 쿠폰지급정보 idx
        /// </summary>
        public uint coupon_issue_idx { get; set; } = 0;

        /// <summary>
        /// 쿠폰 idx & 쿠폰 대상 여부
        /// </summary>
        public uint coupon_idx { get; set; } = 0;

    }

    /// <summary>
    /// 내장자리스트
    /// </summary>
    public class PartnerInfo
    {
        /// <summary>
        /// 내장자명(이름)
        /// </summary>
        public string first_name { get; set; } = string.Empty;
        /// <summary>
        /// 내장자명(성)
        /// </summary>
        public string last_name { get; set; } = string.Empty;
        /// <summary>
        /// 내장자 성별
        /// </summary>
        public string sex_type { get; set; } = string.Empty;
    }

    /// <summary>
    /// StayAndPlay 정보
    /// </summary>
    public class StayAndPlayInfo
    {
        /// <summary>
        /// 옵션아이디
        /// </summary>
        public string sales_itemid { get; set; } = string.Empty;
        /// <summary>
        /// 옵션유형
        /// </summary>
        public string sales_type { get; set; } = string.Empty; //숙박+골프:C, 송영:V
        /// <summary>
        /// 옵션일자
        /// </summary>
        public string sales_playdate { get; set; } = string.Empty;
        /// <summary>
        /// 옵션수량
        /// </summary>
        public int sales_count { get; set; } = 0;
        /// <summary>
        /// SingleCharge여부
        /// </summary>
        public int sales_singlecharge { get; set; } = 0;
        /// <summary>
        /// 사용 여부
        /// </summary>
        public string isUse { get; set; } = "N";
        /// <summary>
        /// 옵션판매가격
        /// </summary>
        public double salePrice { get; set; } = 0;
        /// <summary>
        /// 싱글차지가격
        /// </summary>
        public double singleCharge { get; set; } = 0;
    }

    /// <summary>
    /// 송영 정보
    /// </summary>
    public class PickUpInfo
    {
        /// <summary>
        /// 옵션아이디
        /// </summary>
        public string sales_itemid { get; set; } = string.Empty;
        /// <summary>
        /// 옵션유형
        /// </summary>
        public string sales_type { get; set; } = string.Empty; //숙박+골프:C, 송영:V
        /// <summary>
        /// 옵션일자
        /// </summary>
        public string sales_playdate { get; set; } = string.Empty;
        /// <summary>
        /// 옵션수량
        /// </summary>
        public int sales_count { get; set; } = 0;
        /// <summary>
        /// 사용 여부
        /// </summary>
        public string isUse { get; set; } = "N";
        /// <summary>
        /// 옵션판매가격
        /// </summary>
        public double salePrice { get; set; } = 0;

    }

    /// <summary>
    /// 패널티 정보
    /// </summary>
    public class PenaltyInfo
    {
        /// <summary>
        /// 환불키
        /// </summary>
        public int seq { get; set; } = 0;
        /// <summary>
        /// ~까지 취소일 / 20240731001900
        /// </summary>
        public string dueDate { get; set; } = string.Empty;
        /// <summary>
        /// true: 요율, false:요금
        /// </summary>
        public bool isRate { get; set; }
        /// <summary>
        /// 금액, 요율
        /// </summary>
        public decimal rateOrPrice { get; set; } = 0;
    }

    /// <summary>
    /// 티타임정보
    /// </summary>
    public record BookingTeeInfo
    {
        /// <summary>
        /// 티타임키
        /// </summary>
        public string prod_id { get; set; } = string.Empty;
        /// <summary>
        /// 상품구분 ex.1: teetime_only 2: teetime + 숙박 3: teetime_숙박_송영 4 : teetime_송영
        /// </summary>
        public int prod_kind { get; set; } = 0;
        /// <summary>
        /// 패키지구분 ex.1: 티타임상품 2: 패키지상품
        /// </summary>
        public int isPackage { get; set; } = 0;
        /// <summary>
        /// 내장객 명단 필수여부 ex.0: 필수아님, 1:필수
        /// </summary>
        public int isPerson { get; set; } = 0;

        /// <summary>
        /// 상품명
        /// </summary>
        public string prod_name { get; set; } = string.Empty;

        /// <summary>
        /// 티타임일자 ex.20240531
        /// </summary>
        public string play_date { get; set; } = string.Empty;

        /// <summary>
        /// 티타임시간 ex.0730
        /// </summary>
        public string tee_time { get; set; } = string.Empty;

        /// <summary>
        /// GDS1.0 teetimeid "a56d1e88d622405399599504002f4100"
        /// </summary>
        public string time_id { get; set; } = string.Empty;

        /// <summary>
        /// 코스 아이디
        /// </summary>
        public string course_id { get; set; } = string.Empty;

        /// <summary>
        /// 코스명
        /// </summary>
        public string course_name { get; set; } = string.Empty;

        /// <summary>
        /// 구매수량
        /// </summary>
        public int prod_cnt { get; set; } = 0;

        /// <summary>
        /// 정상가
        /// </summary>
        public double regular_price { get; set; } = 0;

        /// <summary>
        /// 판매가
        /// </summary>
        public double sale_price { get; set; } = 0;

        /// <summary>
        /// 결제화폐 ex.USD
        /// </summary>
        public string currency_code { get; set; } = string.Empty;

        /// <summary>
        /// 기준화폐 ex.KRW
        /// </summary>
        public string origin_currency_code { get; set; } = string.Empty;

        /// <summary>
        /// 예약인원
        /// </summary>
        public int person_count { get; set; } = 0;

        /// <summary>
        /// 동반여부
        /// </summary>
        public string is_partner { get; set; } = "N";

        /// <summary>
        /// 항공포함여부
        /// </summary>
        public string is_flight { get; set; } = "N";

        /// <summary>
        /// 락카포함여부
        /// </summary>
        public string is_locker { get; set; } = "N";

        /// <summary>
        /// 카트포함여부
        /// </summary>
        public string is_cart { get; set; } = "N";

        /// <summary>
        /// 캐디포함여부
        /// </summary>
        public string is_caddie { get; set; } = "N";

        /// <summary>
        /// 클럽랜탈여부
        /// </summary>
        public string is_club { get; set; } = "N";

        /// <summary>
        /// 숙박포함여부
        /// </summary>
        public string is_hotel { get; set; } = "N";

        /// <summary>
        /// 내장자리스트
        /// </summary>
        public List<PartnerInfo> partner_info { get; set; }

        /// <summary>
        /// StayAndPlay여부
        /// </summary>
        public string is_stayandplay { get; set; } = "N";

        /// <summary>
        /// StayAndPlay리스트
        /// </summary>
        public StayAndPlayInfo stayandplay_info { get; set; }

        /// <summary>
        /// 송영포함여부
        /// </summary>
        public string is_pickup { get; set; } = "N";

        /// <summary>
        /// StayAndPlay리스트
        /// </summary>
        public List<PickUpInfo> pickup_info { get; set; }

    }

    /// <summary>
    /// 결제정보
    /// </summary>
    public record PaymentInfo
    {
        /// <summary>
        /// 임시주문번호
        /// </summary>
        public string orderId { get; set; } = string.Empty;

        /// <summary>
        /// PG결제 금액
        /// </summary>
        public double price { get; set; } = 0;

        /// <summary>
        /// 현장결제 금액  
        /// </summary>
        public decimal offline_price { get; set; } = 0;

        /// <summary>
        /// 결제화폐 ex.USD
        /// </summary>
        public string price_currency { get; set; } = string.Empty;

        /// <summary>
        /// 기준화폐 ex.KRW
        /// </summary>
        public string price_currency_origin { get; set; } = string.Empty;

        /// <summary>
        /// 총쿠폰할인금액
        /// </summary>
        public decimal coupon_discount { get; set; } = 0;

        /// <summary>
        /// 총포인트할인금액
        /// </summary>
        public decimal point_discount { get; set; } = 0;

        /// <summary>
        /// 총사용포인트
        /// </summary>
        public decimal point_amount { get; set; } = 0;

        /// <summary>
        /// 결제방법 ex.CARD
        /// </summary>
        public string payment_method { get; set; } = string.Empty;

        /// <summary>
        /// 결제구분코드 ex.EXIMBAY
        /// </summary>
        public string payment_code { get; set; } = string.Empty;

        /// <summary>
        /// 결제구분명 ex.해외카드결제
        /// </summary>
        public string payment_name { get; set; } = string.Empty;

        /// <summary>
        /// 결제방식구분(1:전액결제,2:일부결제,3:현장결제)
        /// </summary>
        public int payment_type { get; set; } = 1;

        /// <summary>
        /// 결제메모
        /// </summary>
        public string memo { get; set; } = string.Empty;

        /// <summary>
        /// 요청일시(UTC시간) ex."2024-05-29 14:29:32" 
        /// </summary>
        public string reg_date { get; set; } = string.Empty;

        /// <summary>
        /// 언어코드
        /// </summary>
        public string lang { get; set; } = string.Empty;

    }

    /// <summary>
    /// 항공정보
    /// </summary>
    public record FlightInfo
    {
        /// <summary>
        /// 여행지 입국 날짜(YYYYMMDD)
        /// </summary>
        public string flightEnterDate { get; set; } = string.Empty;

        /// <summary>
        /// 입국 항공편명(KE001)
        /// </summary>
        public string flightEnterNumber { get; set; } = string.Empty;

        /// <summary>
        /// 입국 항공 도착 시간(1030)
        /// </summary>
        public string flightEnterTime { get; set; } = string.Empty;

        /// <summary>
        /// 여행지 출국 날짜(YYYYMMDD)
        /// </summary>
        public string flightLeaveDate { get; set; } = string.Empty;

        /// <summary>
        /// 출국 항공편명(KE001)
        /// </summary>
        public string flightLeaveNumber { get; set; } = string.Empty;

        /// <summary>
        /// 출국 항공 출발 시간(1430)
        /// </summary>
        public string flightLeaveTime { get; set; } = string.Empty;

        /// <summary>
        /// 픽업 요청사항(영문)
        /// </summary>
        public string vehicleMemo { get; set; } = string.Empty;

    }

}
