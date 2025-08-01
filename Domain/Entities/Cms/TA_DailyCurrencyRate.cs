using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AGL.Api.Domain.Entities
{
    public class TA_DailyCurrencyRate
    {
        /// <summary>
        /// ratio
        /// <summary>
        [Key]
        [Required]

        public int RateId { get; set; }
        /// <summary>
        /// 원래 : Currency
        /// <summary>
        [Required]

        public string CurrencyOrigin { get; set; }
        /// <summary>
        /// 변경 : Currency
        /// <summary>
        [Required]

        public string CurrencyDestination { get; set; }
        /// <summary>
        /// 
        /// <summary>
        [Required]

        public decimal CurrencyRate { get; set; }
        /// <summary>
        /// 일자
        /// <summary>
        [Required]

        public string TargetDateInGMT { get; set; }
        /// <summary>
        /// 
        /// <summary>
        [Required]

        public string Operator { get; set; }

    }
}
