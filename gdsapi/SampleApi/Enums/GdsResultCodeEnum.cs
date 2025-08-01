using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel;

namespace SampleApi.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum GdsResultCodeEnum
    {
        [Description("Undifined result code.")]
        Undefined,
        [Description("Success.")]
        I00001,
        [Description("The package plan is out of stock and cannot be reserved.")]
        E02041,
        [Description("The reservation confirmation period has expired. The reservation cannot be confirmed.")]
        E02042,
    }
}
