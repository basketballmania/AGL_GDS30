using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AGL.Api.Domain.Entities
{
    public class TA_Holiday
    {
        /// <summary>
        /// 
        /// <summary>
        [Key]
        [Required]

        public string id { get; set; }
        /// <summary>
        /// 
        /// <summary>
        [Required]

        public string FieldId { get; set; }
        /// <summary>
        /// 
        /// <summary>
        [Required]

        public string TargetDate { get; set; }
        /// <summary>
        /// 0:국경일, 1:해당골프장만 휴일
        /// <summary>
        [Required]

        public int HolidayKind { get; set; }
        /// <summary>
        /// 
        /// <summary>
        public string? HolidayNameLocal { get; set; }
        /// <summary>
        /// 
        /// <summary>
        public string? HolidayNameEng { get; set; }
    }

}
