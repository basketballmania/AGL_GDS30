namespace AGL.Api.ApplicationCore.Models.Queries
{
    public record ClientQuery
    {
        public string ClientId { get; init; }
        public uint UserId { get; init; }
        public string Language { get; init; }
        public string Currency { get; init; }
        public string Device { get; init; }
		public string Nation { get; init; }
        public string UserEmail { get; init; }
    }
}
