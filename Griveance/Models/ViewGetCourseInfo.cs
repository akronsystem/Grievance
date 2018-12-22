namespace Griveance.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ViewGetCourseInfo")]
    public partial class ViewGetCourseInfo
    {
        [StringLength(100)]
        public string course_name { get; set; }

        [Key]
        public int course_id { get; set; }
    }
}
