namespace Griveance.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_parent
    {
        [Key] 
        public int ParentId { get; set; }

        public int code { get; set; } 
        public int? UserId { get; set; }

        [StringLength(100)]
        public string relationship { get; set; }
    }
}
