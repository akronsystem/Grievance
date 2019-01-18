namespace Griveance.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class View_MemberAllocation
    {
        [StringLength(100)]
        public string name { get; set; }

        public int? code { get; set; }

        [Key]
        [Column(Order = 0)]
        [StringLength(100)]
        public string email { get; set; }

        public long? contact { get; set; }

        [StringLength(100)]
        public string designation { get; set; }

        [StringLength(200)]
        public string griType { get; set; }

        public int? status { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserId { get; set; }

        public int? Expr1 { get; set; }

        public int? Display { get; set; }

        public int? Expr2 { get; set; }
    }
}
