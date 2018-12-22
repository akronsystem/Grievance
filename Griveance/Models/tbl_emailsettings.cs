namespace Griveance.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_emailsettings
    {
        [Required]
        [StringLength(100)]
        public string fromid { get; set; }

        [Required]
        [StringLength(100)]
        public string host { get; set; }

        public int port { get; set; }

        [StringLength(50)]
        public string password { get; set; }

        [Key]
        public long emailsettingid { get; set; }
    }
}
