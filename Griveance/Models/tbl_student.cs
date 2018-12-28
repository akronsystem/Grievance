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
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int code { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(100)]
        public string course_name { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(100)]
        public string class_name { get; set; }

        
        public int IsParent { get; set; }
        public int UserId { get; set; }
    }
}
