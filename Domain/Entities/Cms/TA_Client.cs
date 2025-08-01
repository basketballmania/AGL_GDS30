using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AGL.Api.Domain.Entities
{
    public class TA_Client
    {
        [Key]
        [Required]
        [StringLength(32)]
        public string ClientID { get; set; } = null!;

        [Required]
        [StringLength(1024)]
        public string ClientName { get; set; } = null!;

        [StringLength(64)]
        public string? Account { get; set; }

        [StringLength(2048)]
        public string? AccountDetail { get; set; }

        [StringLength(2048)]
        public string? PaymentAddress { get; set; }

        [StringLength(10)]
        public string? PostNum { get; set; }

        [StringLength(256)]
        public string? President { get; set; }

        [StringLength(32)]
        public string? City { get; set; }

        [StringLength(2)]
        public string? Country { get; set; }

        [Required]
        public int SettlePeroid { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        [Required]
        [Column(TypeName = "numeric(5,3)")]
        public decimal BaseRatio { get; set; }

        [Required]
        public int ClientType { get; set; }

        [Required]
        public int Valid { get; set; }

        [Required]
        [StringLength(32)]
        public string ClientKey { get; set; } = null!;

        [StringLength(32)]
        public string? Phone { get; set; }

        [StringLength(256)]
        public string? Email { get; set; }

        [Required]
        public int Deleted { get; set; } = 0;

        [Required]
        public int ClientFlag { get; set; } = 0;

        [StringLength(32)]
        public string? BusinessNumber { get; set; }

        [Required]
        public int SettleTypeCode { get; set; } = 0;

        [StringLength(32)]
        public string? ManagerName { get; set; }

        [Required]
        [StringLength(3)]
        public string Currency { get; set; } = "KRW";

        public int? TimeZone { get; set; }

        public int? SummerTime { get; set; }

        [StringLength(256)]
        public string? ClientNameEng { get; set; }

        [StringLength(256)]
        public string? ClientNameKor { get; set; }

        [Required]
        [Column(TypeName = "numeric(5,3)")]
        public decimal SettleFee { get; set; } = 0.03m;

        [Required]
        [Column(TypeName = "numeric(5,2)")]
        public decimal BaseEndUserRatio { get; set; } = 0.10m;

        [Column(TypeName = "money")]
        public decimal? B2CRatio { get; set; } = 0m;

        [StringLength(512)]
        public string? BrandName { get; set; }
    }
}
