namespace Griveance.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_student
    {
        [Key]
        public int StudentId { get; set; }

        public int code { get; set; }

        public int? UserId { get; set; }

        [Required]
        [StringLength(100)]
        public string course_name { get; set; }

        [Required]
        [StringLength(100)]
        public string class_name { get; set; }

        public int? IsParent { get; set; }
    }
}
