using AGL.Api.ApplicationCore.Extensions;
using AGL.Api.ApplicationCore.Interfaces;
using AGL.Api.ApplicationCore.Models.Enum;
using Newtonsoft.Json;

namespace AGL.Api.ApplicationCore.Models
{
    public class API_BaseResult : IApiResult
	{
        [JsonIgnore]
        public API_ResultCode Code { get; set; }
        [JsonProperty(Order = 0)]
        public string Status
        {
            get
            {
                return Code.Description();
            }
        }
        [JsonProperty(Order = 1)]
        public string Data { get; set; } = string.Empty;
    }
}
