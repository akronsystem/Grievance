namespace Griveance.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ViewGetAllPostGrievanceList")]
    public partial class ViewGetAllPostGrievanceList
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CompID { get; set; }

        [StringLength(500)]
        public string GrievanceType { get; set; }

        [StringLength(10)]
        public string Date { get; set; }

        public long? contact { get; set; }

        [StringLength(500)]
        public string Subject { get; set; }

        [StringLength(500)]
        public string Post { get; set; }

        [StringLength(500)]
        public string GrievanceAction { get; set; }

        [StringLength(100)]
        public string status { get; set; }
    }
}
