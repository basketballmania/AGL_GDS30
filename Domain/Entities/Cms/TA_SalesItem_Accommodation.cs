using System.ComponentModel.DataAnnotations;

namespace AGL.Api.Domain.Entities
{
    public class TA_SalesItem_Accommodation
    {
        [Key]
        [Required]
        public string CheckInId { get; set; }
        public string StoreSaleId { get; set; }
        public string PlayDate { get; set; }
        public int MemberCount { get; set; }
        public int IsSingleCharge { get; set; }
        public int IsDelete { get; set; }
    }
}
