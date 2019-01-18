namespace Griveance.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Vw_GetEmail
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(100)]
        public string fromid { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(100)]
        public string host { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int port { get; set; }

        [StringLength(50)]
        public string password { get; set; }

        [Key]
        [Column(Order = 3)]
        public long emailsettingid { get; set; }

        public DateTime? created_date { get; set; }

        public DateTime? modified_date { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(5)]
        public string status { get; set; }

        public int? Display { get; set; }
    }
}
