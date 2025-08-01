using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace SecondSampleApi.Enums
{
    [JsonConverter(typeof(StringEnumConverter), typeof(CamelCaseNamingStrategy))]
    public enum AmountTypeEnum
    {
        Undefined = 0,
        teeTimeAmount,
        teeTimeSumAmount,
        staticPackageTotalAmount,
        cancellationFee,
        cancellationFeePerc
    }
}
