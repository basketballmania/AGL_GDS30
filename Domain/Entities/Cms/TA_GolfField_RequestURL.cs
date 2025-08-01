using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AGL.Api.Domain.Entities
{
    public class TA_GolfField_RequestURL
    {
        [Key]
        [Display(Name = "FieldId")]
        public string FieldId { get; set; }

        [Display(Name = "locale"), Required]
        public string locale { get; set; }
        [Display(Name = "RequestURL")]
        public string? RequestURL { get; set; }
    }
}
