using AGL.Api.ApplicationCore.Exceptions;
using AGL.Api.ApplicationCore.Extensions;
using AGL.Api.ApplicationCore.Models.Enum;
using Code.Enums;
using System.Net;

namespace Code.Exceptions
{
    public class CodeAPIException : Exception
    {
        public API_ResultCode ResultCode { get; }
        public ErrorCodeEnum ErrorCode { get; }

        public CodeAPIException(API_ResultCode resultCode, ErrorCodeEnum errorCode)
            : base(errorCode.Description())
        {
            ResultCode = resultCode;
            ErrorCode = errorCode;
        }
    }
}
