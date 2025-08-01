using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AGL.Api.Domain.Entities
{
    public class TA_Sales
	{
		/// <summary>
		/// 
		/// <summary>
		[Required]
		[Key]
		public string StoreSaleId { get; set; }
		/// <summary>
		/// 메뉴ID
		/// <summary>
		[Required]
		[Column(TypeName = "char(32)")]
		public string SalesItemId { get; set; }
		/// <summary>
		/// 
		/// <summary>
		[Required]
		[Column(TypeName = "char(6)")]
		public string FieldId { get; set; }
		/// <summary>
		/// 판매일자
		/// <summary>
		[Required]
		[Column(TypeName = "char(8)")]
		public string SaleDate { get; set; }
		/// <summary>
		/// 
		/// <summary>
		[Required]

		public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
		/// <summary>
		/// 
		/// <summary>
		[Required]

		public string OpId { get; set; }
		/// <summary>
		/// 판매수량
		/// <summary>
		[Required]

		public int ItemCount { get; set; } = 1;
		/// <summary>
		/// 금액
		/// <summary>
		[Required]

		public decimal Price { get; set; }
		/// <summary>
		/// 
		/// <summary>
		[Required]

		public string Currency { get; set; }
		/// <summary>
		/// 0삭제, 1 판매, 3 판매 후 환불 
		/// <summary>
		[Required]

		public int Status { get; set; } = 0;
		/// <summary>
		/// 1개의 할인가로 적용된다.
		/// <summary>
		public decimal? Discount { get; set; } = 0;
		/// <summary>
		/// 
		/// <summary>
		public string? DiscountReason { get; set; }
		/// <summary>
		/// 
		/// <summary>
		public string? CheckinMemberId { get; set; }
		/// <summary>
		/// 
		/// <summary>
		[Required]

		public int PrePaid { get; set; } = 0;
		/// <summary>
		/// 
		/// <summary>
		[Required]

		public int Point { get; set; } = 0;
		/// <summary>
		/// 
		/// <summary>
		[Required]

		public string TransactionId { get; set; }
		/// <summary>
		/// 
		/// <summary>
		public string? SeatId { get; set; }
		/// <summary>
		/// 
		/// <summary>
		public string? ShopId { get; set; }
		/// <summary>
		/// 
		/// <summary>
		[Required]

		public int Checked { get; set; } = 0;
		/// <summary>
		/// 
		/// <summary>
		public string? OrderId { get; set; }
		/// <summary>
		/// 
		/// <summary>
		[Required]

		public int Paid { get; set; } = 0;
		/// <summary>
		/// 
		/// <summary>
		public string? SamePaymentId { get; set; }
		/// <summary>
		/// 
		/// <summary>
		public string? CheckinShopId { get; set; }
		/// <summary>
		/// 
		/// <summary>
		public string? CheckinId { get; set; }
		/// <summary>
		/// 
		/// <summary>
		[Required]

		public decimal Tax { get; set; } = 0;
		/// <summary>
		/// 
		/// <summary>
		[Required]

		public DateTime LastUpdate { get; set; } = DateTime.UtcNow;
		/// <summary>
		/// 
		/// <summary>
		public string? Memo { get; set; }
		/// <summary>
		/// 1: 일반
		/// 2: 캐디
		/// 3: 행사가
		/// 4: 할인가
		/// 5: 자가소비
		/// 6: 할인율
		/// <summary>
		[Required]

		public int DiscountCode { get; set; } = 0;
		/// <summary>
		/// 
		/// <summary>
		public string? OriginalTransactionId { get; set; }
		/// <summary>
		/// 
		/// <summary>
		public string? OriginalShopId { get; set; }
		/// <summary>
		/// 
		/// <summary>
		[Required]

		public int splited { get; set; } = 0;
		/// <summary>
		/// 
		/// <summary>
		[Required]

		public int DiscountPercent { get; set; } = 0;
		/// <summary>
		/// 
		/// <summary>
		public string? PlayDate { get; set; }
		/// <summary>
		/// 
		/// <summary>
		public string? ClientId { get; set; }
		/// <summary>
		/// 
		/// <summary>
		public decimal? PriceClient { get; set; }
		/// <summary>
		/// 
		/// <summary>
		public decimal? PriceOTA { get; set; }


		[JsonIgnore]
		[ForeignKey("SalesItemId")]
		public virtual TA_SalesItem SalesItem { get; set; }


	}
}
