using AGL.Api.ApplicationCore.Extensions;
using AGL.Api.ApplicationCore.Models.Enum;
using SecondSampleApi.Enums;

namespace SecondSampleApi.Exceptions
{
    public class SecondSampleAPIException : Exception
    {
        public API_ResultCode ResultCode { get; }
        public ErrorCodeEnum ErrorCode { get; }

        public SecondSampleAPIException(API_ResultCode resultCode, ErrorCodeEnum errorCode)
            : base(errorCode.Description())
        {
            ResultCode = resultCode;
            ErrorCode = errorCode;
        }

        public SecondSampleAPIException(API_ResultCode resultCode, ErrorCodeEnum errorCode, string message)
            : base(message)
        {
            ResultCode = resultCode;
            ErrorCode = errorCode;
        }
    }
} 