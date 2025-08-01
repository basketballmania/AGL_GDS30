using System.ComponentModel;

namespace AGL.Api.ApplicationCore.Models.Enum
{
    public enum API_ResultCode
    {
        [Description("ok")]
        Success = 200,

        [Description("fail")]
        BadRequest = 400,

        [Description("fail")]
        ValidationError = 422,

        [Description("fail")]
        AuthenticationFailed = 401,

        [Description("fail")]
        Unauthorized = 403,

        [Description("fail")]
        NotFound = 404,

        [Description("fail")]
        Conflict = 409,

        [Description("fail")]
        SystemError = 500,

        [Description("fail")]
        ExternalSystemError = 502,

        [Description("fail")]
        SampleAPIError = 1001,

        [Description("fail")]
        SecondSampleAPIError = 1002
    }
} 