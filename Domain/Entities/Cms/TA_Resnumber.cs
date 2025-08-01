using System.ComponentModel.DataAnnotations;

namespace AGL.Api.Domain.Entities
{
    public class TA_Resnumber
    {
        [Required]
        [Key]
        public long ResId { get; set; }

        public string? CheckinId { get; set; }
        public string? FieldId { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
