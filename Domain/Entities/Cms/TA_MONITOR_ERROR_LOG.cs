using System.ComponentModel.DataAnnotations;

namespace AGL.Api.Domain.Entities
{
    public class TA_MONITOR_ERROR_LOG
    {
        /// <summary>
        /// IDX
        /// <summary>
        [Required]
        public int IDX { get; set; }

        /// <summary>
        /// 오류 발생 날짜
        /// <summary>
        [Required]
        public string ERR_DATE { get; set; }

        /// <summary>
        /// 오류 코드 
        /// USER01 : 사용자오류, 
        /// PG01 : PG결제오류, PG02 : PG취소오류, 
        /// SYSTEM01 : 내부시스템오류, SYSTEM02 : GDS1.0 예약오류, SYSTEM03 : GDS1.0 취소오류 
        /// <summary>
        [Required]
        public string ERR_KIND{ get; set; }

        /// <summary>
        /// 오류 PG (EXIMBAY, KICC, STRIPE)
        /// <summary>
        [Required]
        public string ERR_PG { get; set; }

        /// <summary>
        /// 오류 주문 번호
        /// <summary>
        [Required]
        public string ERR_ORDERID { get; set; }

        /// <summary>
        /// 오류 사이트
        /// <summary>
        [Required]
        public string ERR_SITE { get; set; }

        /// <summary>
        /// 오류 유형 (예: "500 INTERNAL SERVER ERROR")
        /// <summary>
        [Required]
        public string ERR_TYPE { get; set; }

        /// <summary>
        /// 오류 메시지(디버깅을 위한 상세 내용)
        /// <summary>
        [Required]
        public string ERR_MESSAGE { get; set; }

        /// <summary>
        /// 오류 발생 위치 (예: 페이지, 모듈명)
        /// <summary>
        [Required]
        public string ERR_SOURCE { get; set; }

        /// <summary>
        /// 오류 심각도 (CRITICAL, HIGH, MEDIUM, LOW)
        /// <summary>
        [Required]
        public string ERR_SEVERITY { get; set; }

        /// <summary>
        /// 오류 발생 시간 (기본값 현재 시간)
        /// <summary>
        [Required]
        public DateTime CREATE_DATE { get; set; }

    }
}