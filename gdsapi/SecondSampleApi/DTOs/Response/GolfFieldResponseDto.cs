namespace SecondSampleApi.DTOs.Response
{
    public class GolfFieldResponseDto
    {
        public string FieldId { get; set; }
        public string FieldName { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public string Source { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
} 