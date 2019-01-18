namespace Griveance.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ViewGetFacultyInfo")]
    public partial class ViewGetFacultyInfo
    {
        public int? code { get; set; }

        [StringLength(100)]
        public string name { get; set; }

        [Key]
        [Column(Order = 0)]
        [StringLength(100)]
        public string type { get; set; }

        [StringLength(20)]
        public string gender { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(100)]
        public string email { get; set; }

        public long? contact { get; set; }

        [StringLength(100)]
        public string password { get; set; }

        public int? status { get; set; }

        public int? Islive { get; set; }

        [StringLength(100)]
        public string department { get; set; }

        [StringLength(100)]
        public string designation { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserId { get; set; }

        public int? Display { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(5)]
        public string stats { get; set; }
    }
}
