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
        public string StackholderID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(100)]
        public string StackHolderType { get; set; }
    }
}
