using System.ComponentModel;

namespace Code.Enums
{
    public enum ErrorCodeEnum
    {
        [Description("Undefined error occurred.")]
        UndefinedError,

        [Description("An internal server error occurred.")]
        InternalServerError,

        [Description("Failed to write the OTA log to the database.")]
        DbLoggingFail,

        [Description("The client is not authorized to access this resource.")]
        UnauthorizedClient,

        [Description("The Warm up hosted service fail.")]
        WarmUpError,
    }
}
