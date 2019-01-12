namespace Griveance.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_staff
    {
        [Key]
        public int StaffId { get; set; }

        public int code { get; set; }

        public int? UserId { get; set; }

        [Required]
        [StringLength(100)]
        public string department { get; set; }

        [Required]
        [StringLength(100)]
        public string designation { get; set; }

        public int? Display { get; set; }

        public DateTime? created_date { get; set; }

        public DateTime? modified_date { get; set; }
    }
}
