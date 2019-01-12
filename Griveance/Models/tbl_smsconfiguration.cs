namespace Griveance.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_smsconfiguration
    {
        [Key]
        public long SETTINGID { get; set; }

        [StringLength(100)]
        public string GATEWAYUSERID { get; set; }

        public string GATEWAYPASSWORD { get; set; }

        public string SMSSENDAPI { get; set; }

        public string CHECKBALANCEAPI { get; set; }

        public long? DISPLAY { get; set; }

        public DateTime? created_date { get; set; }

        public DateTime? modified_date { get; set; }
    }
}
