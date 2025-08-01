namespace Reservation.Enums
{
    /// <summary>
    /// 0: 자체홈페이지 운영 0:자체정산 1:선불클라이언트, 2:후불클라이언트, 4:카드클라이언트, 8현금클라이언트, 16: API 연동 골프장 상품만 판매
    /// </summary>
    [Flags]
    public enum ClientTypeEnum
    {
        None = 0,

        /// <summary>
        /// Operates own homepage
        /// </summary>
        OwnHomepage = 0,

        /// <summary>
        /// Settles payment independently
        /// </summary>
        SelfSettlement = 0,

        /// <summary>
        /// Prepaid client
        /// </summary>
        PrepaidClient = 1,

        /// <summary>
        /// Postpaid client
        /// </summary>
        PostpaidClient = 2,

        /// <summary>
        /// Card-based client
        /// </summary>
        CardClient = 4,

        /// <summary>
        /// Cash-based client
        /// </summary>
        CashClient = 8,

        /// <summary>
        /// Only sells API-linked golf course products
        /// </summary>
        ApiIntegratedProductClient = 16
    }
}
