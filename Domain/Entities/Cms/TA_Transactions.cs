using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AGL.Api.Domain.Entities
{
    public class TA_Transactions
    {
        [Key]
        [Column(TypeName = "char(32)")]
        public string TransactionID { get; set; } = null!;

        [Required]
        [Column(TypeName = "datetime")]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [Required]
        public int Location { get; set; }

        [Required]
        public int Client { get; set; }

        [Required]
        public int SettleFrom { get; set; }

        [Required]
        public int Status { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? SettleDate { get; set; }

        [Column(TypeName = "varchar(32)")]
        public string? PNR { get; set; }

        [Column(TypeName = "char(8)")]
        public string? PNRDate { get; set; }

        [Column(TypeName = "char(32)")]
        public string? ShopId { get; set; }

        [Required]
        public int Position { get; set; } = 0;

        [Column(TypeName = "char(44)")]
        public string? WidevineID { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string? GNR { get; set; }

        [Column(TypeName = "varchar(32)")]
        public string? ExternalReservationNumber { get; set; }
    }
}
