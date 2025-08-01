namespace Code.DTOs.Response
{
    public class CountryResponseDto
    {
        public string? ContinentCode { get; set; }
        public string CountryCode { get; set; } = string.Empty;
        public CountryNameModel CountryName { get; set; } = new();
    }

    public class CountryNameModel
    {
        public string? en { get; set; }
        public string? ko { get; set; }
        public string? ja { get; set; }
        public string? zh { get; set; }
        public string? tw { get; set; }
        public string? es { get; set; }
    }
}
