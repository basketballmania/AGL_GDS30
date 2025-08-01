using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AGL.Api.Domain.Entities
{
    public class TA_Daemon_Field
    {
        /// <summary>
        /// 
        /// <summary>
        [Required]
        [Key]
        public string FieldId { get; set; }
        /// <summary>
        /// ACC : Accordia, GDS:2.0,M2U:Malaysia,SWA:Sanwa
        /// <summary>
        [Required]

        public string DaemonId { get; set; }
        /// <summary>
        /// 외부연동ID
        /// <summary>
        [Required]

        public string DaemonFieldId { get; set; }
        /// <summary>
        /// 
        /// <summary>
        [Required]

        public string QueryType { get; set; }
        /// <summary>
        /// 
        /// <summary>
        [Required]

        public string StartQueryDate { get; set; } = "20230101";
        /// <summary>
        /// 
        /// <summary>
        [Required]

        public string EndQueryDate { get; set; } = "21000101";
        /// <summary>
        /// 
        /// <summary>
        [Required]

        public DateTime CreatedDate { get; set; } = DateTime.Now;
        /// <summary>
        /// 
        /// <summary>
        public DateTime? LastQueriedTime { get; set; }
        /// <summary>
        /// 
        /// <summary>
        [Required]

        public int RequestFieldInformation { get; set; }
        /// <summary>
        /// 0:가격을 TeetimePriceMaster사용, 1:Teetime의 OuterPrice요금 사용(2,3,4)
        /// <summary>
        [Required]

        public int Enabled { get; set; } = 1;
        /// <summary>
        /// 
        /// <summary>
        [Required]

        public int Minimuninterval { get; set; } = 3600;
        /// <summary>
        /// 
        /// <summary>
        [Required]
        public int QuickUpdate { get; set; } = 0;
        /// <summary>
        /// OuterPrice의 요금을 따를때 외부노출 Ratio를 임의로 설정해준다
        /// <summary>
        public decimal? Discountratio { get; set; }

        public string? LastUpdateTimeBinary { get; set; }

        /// <summary>
        /// true (즉시 확정)
        /// API 연동을 통한 실시간 확정 처리
        /// 
        /// false (수작업 확정)
        /// - 예약 요청 상품: CS를 통한 Outbound 콜 후 수기 결제 및 예약 진행
        /// - API 미연동 상품: 예약 수배를 통해 OP팀이 골프장과 직접 소통하여 처리
        /// </summary>
        public bool? IsDirectReserv { get; set; }

        public string? PartnerCode { get; set; }

        public int? Deleted { get; set; } = 0;
    }

}