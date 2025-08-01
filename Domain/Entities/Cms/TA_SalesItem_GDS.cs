using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AGL.Api.Domain.Entities
{
    public class TA_SalesItem_GDS
    {
        /// <summary>
        /// 

        /// <summary>
        [Key]
        [Required]

        public string SalesItemId { get; set; }
		/// <summary>
		/// 

		/// <summary>
		[Column(TypeName = "char(6)")]
		public string? FieldId { get; set; }
        /// <summary>
        /// H:Hole 추가, A : Accommodation 사용 , V:Vehicle, C:Combo 결합상품, R:Room

        /// <summary>
        public string? SalesItemCode { get; set; }

        

        /// <summary>
        /// 
        /// <summary>
        public int? UseMembers { get; set; } = 0;
        /// <summary>
        /// 

        /// <summary>
        public int? CountMaxSales { get; set; } = 0;
        /// <summary>
        /// 

        /// <summary>
        public decimal LocalPrice { get; set; } = 0;
        /// <summary>
        /// 

        /// <summary>
        public decimal AGLPrice { get; set; } = 0;
        /// <summary>
        /// 

        /// <summary>
        public decimal LimitPrice { get; set; } = 0;
        /// <summary>
        /// 

        /// <summary>
        public int? IsUse { get; set; } = 0;
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
        /// 0:Airport(Hotel)->GC,1:GC->Airport(Hotel),2:RoundTrip 

        /// <summary>
        public int? IsRoundTrip { get; set; } = 1;
        /// <summary>
        /// 

        /// <summary>
        public int? IsLuxury { get; set; } = 0;
        /// <summary>
        /// 

        /// <summary>
        public string? Remark { get; set; }
        /// <summary>
        /// 날짜와 매칭해야 되는 부분 예)호텔 + 골프티타임 인경우 2박 3일간 2번 라운딩 할때 어디서부터 진행되어야 하는지

        /// <summary>
        public int? IsMatchTeetimeDate { get; set; } = 0;
        /// <summary>
        /// H:Hole 라운딩 관련, A:Accommodation 호텔연계, V:Vehicle, C:Combo(결합상품) 실질적으로 호텔 or condo와 같이 패키지

        /// <summary>
        public string? OptionKind { get; set; }
        /// <summary>
        /// single player or 1인 침실 사용시 추가되는 요금 설정

        /// <summary>
        public decimal Singlecharge { get; set; }
        /// <summary>
        /// isDouble 이 0인 항목은 한개가 선택이 되면 다른 항목은 선택 할 수 없다. 18홀추가 & 18홀추가 불가

        /// <summary>
        public int? IsDouble { get; set; } = 0;
        /// <summary>
        /// 티타임 추가시 -1이면 이전의 시간에만 예약가능(18홀추가, 9홀추가), 1이면 이후의 시간에만 예약가능(Night 금액 표시)

        /// <summary>
        public int? BeforeAfter { get; set; } = 0;
        /// <summary>
        /// 기준시간 Teetime

        /// <summary>
        public string? TeetimeApply { get; set; } = "";

        /// <summary>
        /// Package 상품인 경우 포함항목 리스트

        /// <summary>
        public string ItemsInclude { get; set; } = string.Empty;

        /// <summary>
        /// Package 상품인 경우 불포함 항목 리스트

        /// <summary>
        public string ItemsNotInclude { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// <summary>
        public string? ItemNameKor { get; set; }
        /// <summary>
        /// 
        /// <summary>
        public int? MinimumStay { get; set; }
    }
}
