namespace Griveance.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ViewGrievanceList")]
    public partial class ViewGrievanceList
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CompID { get; set; }

        [StringLength(500)]
        public string GrievanceType { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Date { get; set; }

        [StringLength(500)]
        public string Subject { get; set; }

        [StringLength(500)]
        public string Post { get; set; }

        [StringLength(500)]
        public string GrievanceAction { get; set; }

        [StringLength(100)]
        public string status { get; set; }

        public int? GrievMemID { get; set; }

        [StringLength(100)]
        public string name { get; set; }
    }
}
