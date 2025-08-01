using System.Net;
using AGL.Api.ApplicationCore.Models.Enum;

namespace AGL.Api.ApplicationCore.Exceptions
{
    public class API_BaseException : Exception
    {
        public API_ResultCode ResultCode { get; } = API_ResultCode.SystemError;
        public HttpStatusCode StatusCode { get; } = HttpStatusCode.BadRequest;

        public API_BaseException(string message)
            : base(message) { }

        public API_BaseException(API_ResultCode resultCode, string message)
            : base(message)
        {
            ResultCode = resultCode;

            if (resultCode == API_ResultCode.SystemError)
                StatusCode = HttpStatusCode.InternalServerError;
        }

        public API_BaseException(API_ResultCode resultCode, string message, HttpStatusCode statusCode)
            : base(message)
        {
            ResultCode = resultCode;
            StatusCode = statusCode;
        }
    }

    public class UnAuthorizedAPIException : API_BaseException
    {
        public UnAuthorizedAPIException(string message)
            : base(message) { }

        public UnAuthorizedAPIException(API_ResultCode resultCode, string message)
            : base(resultCode, message) { }

        public UnAuthorizedAPIException(API_ResultCode resultCode, string message, HttpStatusCode statusCode)
            : base(resultCode, message, statusCode) { }
    }
}
