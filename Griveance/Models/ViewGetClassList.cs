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
        [StringLength(100)]
        public string class_name { get; set; }
    }
}
