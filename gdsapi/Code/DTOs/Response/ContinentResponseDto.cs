namespace Code.DTOs.Response
{
    public class ContinentResponseDto
    {
        public string? ContinentCode { get; set; }
        public ContinentNameModel ContinentName { get; set; } = new();
    }

    public class ContinentNameModel
    {
        public string? en { get; set; }
        public string? ko { get; set; }
        public string? ja { get; set; }
        public string? zh { get; set; }
        public string? tw { get; set; }
        public string? es { get; set; }
    }
}
