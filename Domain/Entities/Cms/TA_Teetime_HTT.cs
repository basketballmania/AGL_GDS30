using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AGL.Api.Domain.Entities
{
    public class TA_Teetime_HTT
    {
        [Required]
        [Key]
        public string ResNumber { get; set; }
        [Required]

        public string TimeId { get; set; }
        [Required]

        public string PlayDate { get; set; }
        [Required]

        public string StartTime { get; set; }
        
    }
}
