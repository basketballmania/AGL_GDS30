using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AGL.Api.Domain.Entities
{
    public class TA_SalesItem
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
        public string? ShopItemBarcode { get; set; }
        /// <summary>
        /// 
        /// <summary>
        [Required]

        public string ItemName { get; set; }
        /// <summary>
        /// 
        /// <summary>
        public string? ItemNameEng { get; set; }
        /// <summary>
        /// 
        /// <summary>
        public decimal? ItemPriceInUSD { get; set; }
        /// <summary>
        /// 판매금액
        /// <summary>
        [Required]

        public decimal ItemPriceLocal { get; set; }
        /// <summary>
        /// 
        /// <summary>
        [Required]

        public string ItemCurrency { get; set; }
        /// <summary>
        /// TA_SalesItemKind
        /// <summary>
        [Required]

        public string ItemKind { get; set; }
        /// <summary>
        /// 10: Single Item , 11: Single Item Sub, 21:Set Item, 22:Set Item Sub
        /// <summary>
        public string? OrderKind { get; set; } = "10";
        /// <summary>
        /// 
        /// <summary>
        [Required]

        public DateTime CreatedDate { get; set; }
        /// <summary>
        /// 
        /// <summary>
        public string? CreatedMember { get; set; }
        /// <summary>
        /// 
        /// <summary>
        [Required]

        public string FieldId { get; set; }
        /// <summary>
        /// 
        /// <summary>
        [Required]

        public int Deleted { get; set; } = 0;
        /// <summary>
        /// 
        /// <summary>
        public string? OldCode { get; set; }
        /// <summary>
        /// 판매금액(VAT)
        /// <summary>
        public decimal? ItemPriceVAT { get; set; }
        /// <summary>
        /// 계산식 : ItemPriceLocal - ItemPriceVat
        /// <summary>
        //public decimal? ItemPriceUnit { get; set; }
        /// <summary>
        /// 
        /// <summary>
        [Required]

        public decimal ItemPriceStaff { get; set; } = -1;
        /// <summary>
        /// 
        /// <summary>
        [Required]

        public decimal ItemPriceCaddie { get; set; } = -1;
        /// <summary>
        /// 
        /// <summary>
        [Required]

        public decimal VatRate { get; set; } = 0;
        /// <summary>
        /// 
        /// <summary>
        public decimal? ItemPriceSpecialDiscount { get; set; } = 0;
        /// <summary>
        /// 
        /// <summary>
        [Required]

        public int ToKitchen { get; set; } = 0;
    }
}
