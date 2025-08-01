using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Reservation.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum CurrencyEnum
    {
        KRW,
        USD,
        SGD,
        JPY,
        EUR,
        TWD,
        GBP
    }
}
