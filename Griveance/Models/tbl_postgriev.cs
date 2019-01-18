namespace Griveance.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_postgriev
    {
        [Key]
        public int PostGrievId { get; set; }

        public int code { get; set; }

        [Required]
        [StringLength(100)]
        public string email { get; set; }

        [Required]
        [StringLength(300)]
        public string grivtype { get; set; }

        [Required]
        [StringLength(300)]
        public string subject { get; set; }

        [Required]
        [StringLength(500)]
        public string post { get; set; }

        [Required]
        [StringLength(30)]
        public string status { get; set; }

        public int? Display { get; set; }

        public DateTime? created_date { get; set; }

        public DateTime? modified_date { get; set; }

        public long? userid { get; set; }
    }
}
