using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AGL.Api.Domain.Entities
{
    public class TA_SalesItem_GDS_Master
    {
        /// <summary>
        /// 
        /// <summary>

        [Key]
        [Required]
        public string SalesMasterId { get; set; }
        /// <summary>
        /// 
        /// <summary>
        [Required]
        public string SalesItemId { get; set; }
        /// <summary>
        /// 
        /// <summary>
        [Required]
        public string FieldId { get; set; }
        /// <summary>
        /// 
        /// <summary>
        [Required]
        public string LanguageCode { get; set; }
        /// <summary>
        /// 
        /// <summary>
        public string? ItemNameEng { get; set; }
        /// <summary>
        /// 
        /// <summary>
        public string? ItemName { get; set; }
        /// <summary>
        /// 
        /// <summary>
        public string? Remark { get; set; }
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
        public string? ItemsIncludeMulti { get; set; }
        /// <summary>
        /// 
        /// <summary>
        public string? ItemsNotIncludeMulti { get; set; }
    }
}
