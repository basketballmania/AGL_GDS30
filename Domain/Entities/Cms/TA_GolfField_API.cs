using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AGL.Api.Domain.Entities
{
    public class TA_GolfField_API
	{
		/// <summary>
		/// 골프장명
		/// <summary>
		[Required]
		[Key]
		[Column(TypeName = "nvarchar(256)")]
		public string FieldName { get; set; } = string.Empty;

		/// <summary>
		/// 골프장ID
		/// <summary>
		[Column(TypeName = "char(6)")]
		public string? FieldId { get; set; }

		/// <summary>
		/// 위치
		/// <summary>
		[Column(TypeName = "varchar(6)")]
		public string? DataSource { get; set; }
        
    }
}
