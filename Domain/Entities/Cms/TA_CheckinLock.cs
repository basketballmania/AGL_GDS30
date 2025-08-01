using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AGL.Api.Domain.Entities
{
    public class TA_CheckinLock
    {
        /// <summary>
        /// CheckinId
        /// <summary>
        [Key]
        [Required]
        [Column(TypeName = "char(32)")]
        public string CheckinId { get; set; }
    }
}