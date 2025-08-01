using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace SecondSampleApi.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum AmountLineStatusEnum
    {
        UNDEFINED,
        CHARGED,
        VOIDED
    }
}
