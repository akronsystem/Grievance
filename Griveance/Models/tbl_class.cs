namespace Griveance.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_class
    {
        [Key]
        public int class_id { get; set; }

        [Required]
        [StringLength(100)]
        public string class_name { get; set; }

        [Required]
        [StringLength(100)]
        public string course_name { get; set; }

        public int? Display { get; set; }

        public DateTime? created_date { get; set; }

        public DateTime? modified_date { get; set; }
    }
}
