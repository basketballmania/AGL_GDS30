using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SampleApi.Enums
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
