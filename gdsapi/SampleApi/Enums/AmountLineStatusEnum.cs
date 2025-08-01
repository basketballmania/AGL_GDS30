using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace SampleApi.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum AmountLineStatusEnum
    {
        UNDEFINED,
        CHARGED,
        VOIDED
    }
}
