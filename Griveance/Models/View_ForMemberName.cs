namespace Griveance.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class View_ForMemberName
    {
        [Key]
        [Column(Order = 0)]
        public int UserId { get; set; }

        [StringLength(100)]
        public string name { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(100)]
        public string type { get; set; }
    }
}
