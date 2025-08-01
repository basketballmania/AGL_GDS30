namespace Code.DTOs.Response
{
    public class RegionsResponseDto
    {
        public string? CountryCode { get; set; }
        public string RegionCode { get; set; } = string.Empty;
        public RegionNameModel RegionName { get; set; } = new();
    }

    public class RegionNameModel
    {
        public string? en { get; set; }
        public string? ko { get; set; }
        public string? ja { get; set; }
        public string? zh { get; set; }
        public string? tw { get; set; }
        public string? es { get; set; }
    }
}
