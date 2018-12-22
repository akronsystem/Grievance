namespace Griveance.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_user
    {
        [Key]
        public int UserId { get; set; }

        [StringLength(100)]
        public string name { get; set; }

        public int? code { get; set; }

        [Required]
        [StringLength(100)]
        public string type { get; set; }

        [StringLength(20)]
        public string gender { get; set; }

        [Required]
        [StringLength(100)]
        public string email { get; set; }

        public long? contact { get; set; }

        [StringLength(100)]
        public string password { get; set; }

        public int? status { get; set; }

        public int? Islive { get; set; }
    }
}
