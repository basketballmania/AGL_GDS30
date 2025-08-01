using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AGL.Api.Domain.Entities
{
    public class TA_SalesItem_GDS_Plan
    {
        /// <summary>
        /// 
        /// <summary>
        [Key]
        [Required]
		[Column(TypeName = "char(32)")]
		public string PlanId { get; set; }
        /// <summary>
        /// 
        /// <summary>
        [Required]
		[Column(TypeName = "char(6)")]
		public string FieldId { get; set; }
        /// <summary>
        /// 
        /// <summary>
        [Required]
		[Column(TypeName = "char(8)")]
		public string PlayDate { get; set; }
        /// <summary>
        /// 
        /// <summary>
        [Required]
		[Column(TypeName = "char(32)")]
		public string SalesItemId { get; set; }
        /// <summary>
        /// 
        /// <summary>
        [Required]

        public int CountMaxSales { get; set; }
        /// <summary>
        /// 
        /// <summary>
        public DateTime? CreateDt { get; set; }
        /// <summary>
        /// 
        /// <summary>
        public string? CreateBy { get; set; }
        /// <summary>
        /// 
        /// <summary>
        public DateTime? UpdateDt { get; set; }
        /// <summary>
        /// 
        /// <summary>
        public string? UpdateBy { get; set; }

        /// <summary>
        /// 
        /// <summary>
        public decimal LocalPrice { get; set; } = Decimal.Zero;

        /// <summary>
        /// 
        /// <summary>
        public decimal AGLPrice { get; set; } = Decimal.Zero;
        /// <summary>
        /// 
        /// <summary>
        public decimal LimitPrice { get; set; } = Decimal.Zero;
        /// <summary>
        /// 
        /// <summary>
        public string? MPlanId { get; set; }
        /// <summary>
        /// 
        /// <summary>
        public string? Currency { get; set; } = "USD";
        /// <summary>
        /// 
        /// <summary>
        public decimal SingleCharge { get; set; } = Decimal.Zero;

        [JsonIgnore]
        [ForeignKey("SalesItemId")]
        public virtual TA_SalesItem_GDS Master { get; set; }
    }
}
