using AGL.Api.ApplicationCore.Models.Enum;
using Newtonsoft.Json;

namespace AGL.Api.ApplicationCore.Models
{
    public class API_SuccessModel<T> : API_BaseResult
        where T : class
    {
        public API_SuccessModel()
        {
            Code = API_ResultCode.Success;
        }
        [JsonProperty(Order = 3)]
        public T Data { get; set; }
    }
}
