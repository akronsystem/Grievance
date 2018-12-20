namespace Griveance.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ViewGetMyGrievance")]
    public partial class ViewGetMyGrievance
    {
        [Key]
        [Column(Order = 0)]
        public int PostGrievId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int code { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(100)]
        public string email { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(300)]
        public string grivtype { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(300)]
        public string subject { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(500)]
        public string post { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(30)]
        public string status { get; set; }
    }
}
