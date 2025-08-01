using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AGL.Api.Domain.Entities
{
 
    public class APS_PAYMENT_ALARMN
    {
    
        /// <summary>
        /// PK
        /// <summary>
        [Key]
        [Required]
        public long Idx {get;set;}
        /// <summary>
        /// TA_MONITOR_ERROR_LOG.IDX
        /// <summary>
        [Required]
        public int MonitorIdx {get;set;}
        /// <summary>
        /// 전송여부
        /// <summary>
        [Required]
        public bool IsSend {get;set;}
        /// <summary>
        /// 전송일시
        /// <summary>
        public DateTime? SendDate {get;set;}
        /// <summary>
        /// 생성일시
        /// <summary>
        [Required]
        public DateTime CreateDate {get;set;}


		[JsonIgnore]
		[ForeignKey("MonitorIdx")]
		public virtual TA_MONITOR_ERROR_LOG Log { get; set; }


	}
    
}