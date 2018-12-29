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
        public int UserId { get; set; }

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

        [Key]
        [Column(Order = 2)]
        [StringLength(100)]
        public string password { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int status { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Islive { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(100)]
        public string department { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(100)]
        public string designation { get; set; }
    }
}
