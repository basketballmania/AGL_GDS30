using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AGL.Api.Domain.Entities
{
    public class TA_ACCORDIA_MINMEMBERS
    {
        /// <summary>
        /// 
        /// <summary>
        [Key]
        [Required]

        public string MinMembersId { get; set; }
        /// <summary>
        /// 
        /// <summary>
        public string? FieldId { get; set; }
        /// <summary>
        /// 해당월
        /// <summary>
        public string? PlayMonth { get; set; }
        /// <summary>
        /// 주중MinMember
        /// <summary>
        public string? WeekMin { get; set; }
        /// <summary>
        /// 주말(공휴일)MinMember
        /// <summary>
        public string? WeekEndMin { get; set; }
        /// <summary>
        /// 주중2인 Surcharge
        /// <summary>
        public decimal? Week2Surcharge { get; set; }
        /// <summary>
        /// 주중3인 Surcharge
        /// <summary>
        public decimal? Week3Surcharge { get; set; }
        /// <summary>
        /// 주말(공휴일)2인 Surcharge
        /// <summary>
        public decimal? Weekend2Surcharge { get; set; }
        /// <summary>
        /// 주말(공휴일)3인 Surcharge
        /// <summary>
        public decimal? Weekend3surcharge { get; set; }
        /// <summary>
        /// 
        /// <summary>
        public DateTime? CreatedDate { get; set; }
        /// <summary>
        /// 
        /// <summary>
        public DateTime? UpdateDate { get; set; }
    }
}
