using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AGL.Api.Domain.Entities
{
    public class TA_FieldPlayDate
	{
        [Key]
		[Display(Name = "FieldId")]
		public string FieldId { get; set; }
		[Key]
		public string PlayDate { get; set; }
		public int? HolidayKind { get; set; }
		public string? HolidayNameLocal { get; set; }
		public string? HolidayNameEng { get; set; }

	}
}
