using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AGL.Api.Domain.Entities
{
	public class APS_Daemon_Field_Sync
    {
        [Required]
        public string Id { get; set; } = string.Empty;
        [Required]
        public string Status { get; set; } = string.Empty;
        [Required]
        public DateTime CreateDate { get; set; } 
        public DateTime? SendDate { get; set; } 

    }
}
