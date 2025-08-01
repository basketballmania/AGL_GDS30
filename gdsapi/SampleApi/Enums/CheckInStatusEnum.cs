namespace SampleApi.Enums
{
    /// <summary>
    /// Hold, StanBy, Complete 미사용
    /// </summary>
    public enum CheckInStatusEnum
    {
        Cancelled = -1,
        Request = 0,
        Confirmed = 1,
        Hold = 2,
        StanBy = 3,
        Complete
    }
}
