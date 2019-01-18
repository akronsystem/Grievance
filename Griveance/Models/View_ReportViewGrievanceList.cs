namespace Griveance.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class View_ReportViewGrievanceList
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CompID { get; set; }

        [StringLength(500)]
        public string GrievanceType { get; set; }

        [StringLength(500)]
        public string Subject { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Date { get; set; }

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

        public int? Display { get; set; }

        [StringLength(100)]
        public string name { get; set; }

        public int? Expr1 { get; set; }
    }
}
