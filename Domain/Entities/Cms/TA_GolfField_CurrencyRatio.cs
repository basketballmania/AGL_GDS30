using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AGL.Api.Domain.Entities
{
    public class TA_GolfField_CurrencyRatio
    {
        /// <summary>
        /// 
        /// <summary>
        [Key]
        [Display(Name = "FieldId"), Required]
        [Column(TypeName = "char(6)")]
        public string FieldId { get; set; } = string.Empty;

        /// <summary>
        /// 적용할 Ratio 현재 미사용
        /// <summary>
        public decimal? Ratio { get; set; } = 0;

    }
}