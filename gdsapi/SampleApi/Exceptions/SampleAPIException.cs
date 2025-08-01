
using AGL.Api.ApplicationCore.Extensions;
using AGL.Api.ApplicationCore.Models.Enum;
using SampleApi.Enums;

namespace SampleApi.Exceptions
{
    public class SampleAPIException : Exception
    {
        public API_ResultCode ResultCode { get; }
        public ErrorCodeEnum ErrorCode { get; }

        public SampleAPIException(API_ResultCode resultCode, ErrorCodeEnum errorCode)
            : base(errorCode.Description())
        {
            ResultCode = resultCode;
            ErrorCode = errorCode;
        }

        public SampleAPIException(API_ResultCode resultCode, ErrorCodeEnum errorCode, string message)
            : base(message)
        {
            ResultCode = resultCode;
            ErrorCode = errorCode;
        }
    }
} 