using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AGL.Api.Domain.Entities
{
    public class TA_FieldClient_Ratio
    {
        [Key]
        [Required]
        [StringLength(32)]
        public string RatioId { get; set; } = null!;

        [StringLength(8)]
        public string? DateFr { get; set; }

        [StringLength(8)]
        public string? DateTo { get; set; }

        [StringLength(6)]
        public string? FieldId { get; set; }

        [StringLength(32)]
        public string? ClientId { get; set; }

        [Column(TypeName = "numeric(7,4)")]
        public decimal? Ratio { get; set; }

        [Column(TypeName = "numeric(7,4)")]
        public decimal? EnduserRatio { get; set; } = 0.1m;
    }
}
