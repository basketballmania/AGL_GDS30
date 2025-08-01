using System.ComponentModel;

namespace SecondSampleApi.Enums
{
    public enum ErrorCodeEnum
    {
        #region common
        [Description("Undefined error occurred.")]
        UndefinedError,

        [Description("An internal server error occurred.")]
        InternalServerError,

        [Description("The request failed due to an error from an external system.")]
        ExternalServerError,

        [Description("Failed to write the OTA log to the database.")]
        DbLoggingFail,

        [Description("The client is not authorized to access this resource.")]
        UnauthorizedClient,

        [Description("Invalid rest client options check appsettings.json.")]
        InvalidRestClientOptions,

        [Description("External Api Request fail.")]
        ExternalApiRequestFail,

        [Description("The api response is invalid.")]
        InvalidApiResponse,

        [Description("The specified date is not valid.")]
        InvalidDate,

        [Description("The specified currency is not valid.")]
        InvalidCurrency,

        [Description("The Warm up hosted service fail.")]
        WarmUpError,

        [Description("Invalid value.")]
        InvalidValue,
        #endregion

        [Description("The reservation could not be found.")]
        ReservationNotFound,

        [Description("The product could not be found.")]
        ProductNotFound,

        [Description("The tee time could not be found.")]
        TeeTimeNotFound,

        [Description("The currency rate could not be found.")]
        CurrencyRateNotFound,

        [Description("The refund policy type is invalid or not supported.")]
        InvalidRefundPolicy,

        [Description("The request has already been processed and cannot be submitted again.")]
        DuplicateRequest,

        [Description("The payment information could not be found.")]
        PaymentNotFound,

        [Description("The client information could not be found.")]
        ClientNotFound,

        [Description("The reservation number in the request has already been confirmed.")]
        AlreadyConfirmed,

        [Description("Tee time already booked.")]
        AlreadyBooked,

        [Description("Full penalty policy not supported. Reservation cancellation is not allowed.")]
        CancellationPolicyNotSupported,

        [Description("The requested number of players is not allowed.")]
        InvalidPlayerCount,

        [Description("The number of golfer entries does not match the requested number of players.")]
        MismatchedGolferInformation,

        [Description("Reservation cannot be cancelled before confirmation.")]
        ReservationNotConfirmed,

        [Description("The reservation type is invalid or not supported.")]
        InvalidReservationType,

        [Description("The StaticPackageProductPayid could not be found.")]
        StaticPackageProductPayidNotFound,

        [Description("The StaticPackageProductPayidDetail could not be found.")]
        StaticPackageProductPayidDetailNotFound,

        [Description("Cancellation is not allowed while the reservation is still in the requested state.")]
        ReservationCancellationNotAllowedInRequestedState,

        [Description("Reservations that have already been used cannot be cancelled.")]
        ReservationAlreadyUsed,

        [Description("The cancellation period has passed.")]
        CancelPeriodExpired,

        [Description("Please check plan information.")]
        PlanInformationCheck,

        [Description("payment.amountLines[].reservationId is missing or does not exist.")]
        PaymentInvalidReservationId,

        [Description("The package plan is out of stock and cannot be reserved.")]
        OutOfStock,

        [Description("The reservation confirmation period has expired. The reservation cannot be confirmed.")]
        ConfirmPeriodExpired,
    }
}
