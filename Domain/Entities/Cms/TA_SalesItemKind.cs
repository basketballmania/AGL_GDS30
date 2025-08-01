using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AGL.Api.Domain.Entities
{
    public class TA_SalesItemKind
    {
        /// <summary>
        /// 
        /// <summary>


        [Key]
        [Required]

        public string ItemKind { get; set; }
        /// <summary>
        /// 
        /// <summary>
        [Required]

        public string FieldId { get; set; }
        /// <summary>
        /// 
        /// <summary>
        [Required]

        public string ItemKindName { get; set; }
        /// <summary>
        /// 
        /// <summary>
        [Required]

        public string ItemKindNameEng { get; set; }
        /// <summary>
        /// 
        /// <summary>
        public string? ItemKindId { get; set; }
        /// <summary>
        /// 
        /// <summary>
        public string? UpperItemKindId { get; set; }
        /// <summary>
        /// 
        /// <summary>
        public string? DisplayYN { get; set; } = "Y";
        /// <summary>
        /// 
        /// <summary>
        public string? UseYN { get; set; } = "Y";
        /// <summary>
        /// 
        /// <summary>
        public string? AccountCode { get; set; }
        /// <summary>
        /// TA_CommonGroup ItemGroupCode
        /// <summary>
        public string? ItemGroupCode { get; set; }
        /// <summary>
        /// 
        /// <summary>
        public string? ItemGroupName { get; set; }
        /// <summary>
        /// 
        /// <summary>
        public string? ItemGroupNameEng { get; set; }
        /// <summary>
        /// 
        /// <summary>
        public string? ItemClassCode { get; set; }
        /// <summary>
        /// 
        /// <summary>
        public string? ItemClassName { get; set; }
        /// <summary>
        /// 
        /// <summary>
        public string? ItemClassNameEng { get; set; }
        /// <summary>
        /// 
        /// <summary>
        public string? Remarks { get; set; }
        /// <summary>
        /// 
        /// <summary>
        public string? Tmp01 { get; set; }
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
        public string? Updateby { get; set; }
    }
}
