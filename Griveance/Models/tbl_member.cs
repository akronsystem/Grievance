namespace Griveance.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_member
    {
        public int id { get; set; }

        public int? UserId { get; set; }

        public int code { get; set; }

        [Required]
        [StringLength(100)]
        public string designation { get; set; }

        [Required]
        [StringLength(200)]
        public string griType { get; set; }
    }
}
