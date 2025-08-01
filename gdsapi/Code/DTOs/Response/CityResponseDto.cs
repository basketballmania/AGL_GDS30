namespace Code.DTOs.Response
{
    public class CityResponseDto
    {
        public string? CountryCode { get; set; }
        public string CityCode { get; set; } = string.Empty;
        public CityNameModel CityName { get; set; } = new();
    }

    public class CityNameModel
    {
        public string? en { get; set; }
        public string? ko { get; set; }
        public string? ja { get; set; }
        public string? zh { get; set; }
        public string? tw { get; set; }
        public string? es { get; set; }
    }
}
