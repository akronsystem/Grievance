namespace Griveance.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ViewUser")]
    public partial class ViewUser
    {
        [Key]
        [Column(Order = 0)]
        public int UserId { get; set; }

        public int? code { get; set; }

        [StringLength(100)]
        public string password { get; set; }

        public int? status { get; set; }

        public int? Islive { get; set; }

        [StringLength(100)]
        public string name { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(100)]
        public string type { get; set; }

        [StringLength(20)]
        public string gender { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(100)]
        public string email { get; set; }

        public long? contact { get; set; }
    }
}
