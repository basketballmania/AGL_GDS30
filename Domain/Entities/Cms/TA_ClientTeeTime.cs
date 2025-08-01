using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

public class TA_ClientTeeTime
{
    [Key]
    [Column(TypeName = "char(32)")]
    public string ClientTimeId { get; set; } = null!;

    [Required]
    [Column(TypeName = "char(32)")]
    public string TimeId { get; set; } = null!;

    [Required]
    [Column(TypeName = "char(32)")]
    public string CheckinId { get; set; } = null!;

    [Required]
    [Column(TypeName = "char(32)")]
    public string TransactionId { get; set; } = null!;

    [Required]
    [Description("1:선점, 2:확정, 3:확약(결제완료)")]
    public int OccupiedStatus { get; set; }

    [Required]
    [Column(TypeName = "char(14)")]
    public string SettleDuedateTime { get; set; } = null!;

    [Required]
    public decimal FieldPrice { get; set; }

    [Required]
    public decimal ExchangeRate { get; set; }

    [Required]
    [Column(TypeName = "char(3)")]
    public string CurrencyOrigin { get; set; } = null!;

    [Required]
    [Column(TypeName = "char(4)")]
    public string CurrencyDestination { get; set; } = null!;

    [Required]
    public decimal Commission { get; set; }

    [Required]
    public decimal ControlPrice { get; set; }

    [Required]
    [Column(TypeName = "char(32)")]
    public string ClientId { get; set; } = null!;

    [Required]
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime CreatedDate { get; set; }

    [Required]
    [DefaultValue(0)]
    public int Deleted { get; set; }

    [Required]
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime OccupiedDate { get; set; }

    public DateTime? ConfirmDate { get; set; }
    public DateTime? SettleDate { get; set; }

    [Required]
    public decimal TotalPrice { get; set; }

    [Required]
    [Column(TypeName = "char(6)")]
    public string FieldId { get; set; } = null!;

    public DateTime? RefundDate { get; set; }
    public string? CancelDueDate { get; set; }
    public string? SessionId { get; set; }

    [DefaultValue(0)]
    public decimal? OTAPrice { get; set; }

    public string? CancelDueDateHalf { get; set; }
}
