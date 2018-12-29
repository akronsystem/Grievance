namespace Griveance.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class View_UsersGrievance
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Expr1 { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(100)]
        public string Expr2 { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(300)]
        public string Expr3 { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(300)]
        public string Expr4 { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(500)]
        public string Expr5 { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(30)]
        public string Expr6 { get; set; }

        [Key]
        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Expr7 { get; set; }

        [Key]
        [Column(Order = 7)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PostGrievId { get; set; }

        [Key]
        [Column(Order = 8)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int code { get; set; }

        [Key]
        [Column(Order = 9)]
        [StringLength(100)]
        public string email { get; set; }

        [Key]
        [Column(Order = 10)]
        [StringLength(300)]
        public string grivtype { get; set; }

        [Key]
        [Column(Order = 11)]
        [StringLength(300)]
        public string subject { get; set; }

        [Key]
        [Column(Order = 12)]
        [StringLength(500)]
        public string post { get; set; }

        [Key]
        [Column(Order = 13)]
        [StringLength(30)]
        public string status { get; set; }
    }
}
