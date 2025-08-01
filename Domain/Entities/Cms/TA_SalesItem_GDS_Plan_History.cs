using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AGL.Api.Domain.Entities
{
    public class TA_SalesItem_GDS_Plan_History
    {
        /// <summary>
        /// 
        /// <summary>
        [Key]
        [Required]

        public string MPlanId { get; set; }
        /// <summary>
        /// 
        /// <summary>
        public string? FieldId { get; set; }
        /// <summary>
        /// 
        /// <summary>
        public string? DateFr { get; set; }
        /// <summary>
        /// 
        /// <summary>
        public string? DateTo { get; set; }
        /// <summary>
        /// 
        /// <summary>
        public string? SalesItemId { get; set; }
        /// <summary>
        /// 
        /// <summary>
        public int? CountMaxSales { get; set; }
        /// <summary>
        /// 
        /// <summary>
        public decimal? LocalPrice_H { get; set; }
        /// <summary>
        /// 
        /// <summary>
        public decimal? AGLPrice_H { get; set; }
        /// <summary>
        /// 
        /// <summary>
        public decimal? LimitPrice_H { get; set; }
        /// <summary>
        /// 
        /// <summary>
        public int? DayGroup_W { get; set; }
        /// <summary>
        /// 
        /// <summary>
        public decimal? LocalPrice_W { get; set; }
        /// <summary>
        /// 
        /// <summary>
        public decimal? AGLPrice_W { get; set; }
        /// <summary>
        /// 
        /// <summary>
        public decimal? LimitPrice_W { get; set; }
        /// <summary>
        /// 
        /// <summary>
        public int? DayGroup_E { get; set; }
        /// <summary>
        /// 
        /// <summary>
        public decimal? LocalPrice_E { get; set; }
        /// <summary>
        /// 
        /// <summary>
        public decimal? AGLPrice_E { get; set; }
        /// <summary>
        /// 
        /// <summary>
        public decimal? LimitPrice_E { get; set; }
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
        public decimal? SingleCharge_H { get; set; }
        /// <summary>
        /// 
        /// <summary>
        public decimal? SingleCharge_W { get; set; }
        /// <summary>
        /// 
        /// <summary>
        public decimal? SingleCharge_E { get; set; }
    }
}
