using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AGL.Api.Domain.Entities
{
    public class TA_FieldCourse
    {
        /// <summary>
        /// 
        /// <summary>
        [Required]
        [Key]
        public string CourseID { get; set; }
        /// <summary>
        /// 
        /// <summary>
        [Required]

        public string FieldId { get; set; }
        /// <summary>
        /// 
        /// <summary>
        [Required]

        public string CourseName { get; set; }
        /// <summary>
        /// 
        /// <summary>
        public string? CourseNameEng { get; set; }
        /// <summary>
        /// 
        /// <summary>
        public string? Memo { get; set; }
        /// <summary>
        /// 
        /// <summary>
        [Required]

        public int Deleted { get; set; } = 0;
        /// <summary>
        /// 
        /// <summary>
        [Required]

        public int RoundingTime { get; set; } = 100;
        /// <summary>
        /// 
        /// <summary>
        public string? CourseSeq { get; set; } = "1";
        /// <summary>
        /// 
        /// <summary>
        [Required]

        public int HoleCount { get; set; } = 9;
        /// <summary>
        /// 코스 SortOrder
        /// <summary>
        [Required]

        public int SortOrder { get; set; } = 1;
        /// <summary>
        /// 
        /// <summary>
        public string? CourseAbb { get; set; }
        /// <summary>
        /// 
        /// <summary>
        public string? MemoEng { get; set; }
        /// <summary>
        /// *** 외부연동필수 : CourseId
        /// <summary>
        public string? FieldCourseId { get; set; }
    }
}
