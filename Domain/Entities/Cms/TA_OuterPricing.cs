using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AGL.Api.Domain.Entities
{
    public class TA_OuterPricing
    {
        /// <summary>
        /// 
        /// <summary>
        [Required]
        [Key]
        public long ID { get; set; }
        /// <summary>
        /// 
        /// <summary>
        [Required]

        public string FieldId { get; set; }
        /// <summary>
        /// 
        /// <summary>
        [Required]

        public string OuterPricingId { get; set; }
        /// <summary>
        /// 
        /// <summary>
        public string? PlayerType { get; set; }
        /// <summary>
        /// 
        /// <summary>
        [Required]

        public string Currency { get; set; }
        /// <summary>
        /// 
        /// <summary>
        [Required]

        public string PriceComponentId { get; set; }
        /// <summary>
        /// 
        /// <summary>
        public string? PriceName { get; set; }
        /// <summary>
        /// 
        /// <summary>
        public string? PriceType { get; set; }
        /// <summary>
        /// 
        /// <summary>
        [Required]

        public decimal PriceFor18Holes { get; set; }
        /// <summary>
        /// 
        /// <summary>
        public decimal? PriceFor9Holes { get; set; }
        /// <summary>
        /// 
        /// <summary>
        [Required]

        public int IsMandatory { get; set; } = 0;
        /// <summary>
        /// 금액 적용 단위, 1: 팀별, 0: 개인별
        /// <summary>
        public int? ApplicationUnit { get; set; }
        /// <summary>
        /// 
        /// <summary>
        [Required]

        public decimal TaxRate { get; set; } = 0;
        /// <summary>
        /// 
        /// <summary>
        [Required]

        public int IsDeleted { get; set; } = 0;
        /// <summary>
        /// 
        /// <summary>
        public DateTime? CreateDT { get; set; }
        /// <summary>
        /// 
        /// <summary>
        public DateTime? UpdateDT { get; set; }
    }
}
