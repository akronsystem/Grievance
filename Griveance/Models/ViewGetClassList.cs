namespace Griveance.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ViewGetClassList")]
    public partial class ViewGetClassList
    {
        [Key]
        [Column(Order = 0)]
        public int class_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(100)]
        public string class_name { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(100)]
        public string course_name { get; set; }
    }
}
