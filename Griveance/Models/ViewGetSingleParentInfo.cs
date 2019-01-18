namespace Griveance.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ViewGetSingleParentInfo")]
    public partial class ViewGetSingleParentInfo
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserId { get; set; }

        [StringLength(100)]
        public string name { get; set; }

        public int? code { get; set; }

        [StringLength(100)]
        public string relationship { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(100)]
        public string email { get; set; }

        public long? contact { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(100)]
        public string type { get; set; }

        [StringLength(20)]
        public string gender { get; set; }

        public int? status { get; set; }

        public int? Islive { get; set; }

        [StringLength(100)]
        public string password { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(5)]
        public string parentstatus { get; set; }

        public int? Display { get; set; }

        public int? Expr1 { get; set; }
    }
}
