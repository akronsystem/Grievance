using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Griveance.ParamModel
{
    public class ParamSaveGriveance
    {

        public int UserId { get; set; }
        public string Password { get; set; }
      
        public string GriveanceType { get; set; }
        [Required]
        [Display(Name ="Please enter subject name")]
        public string Subject { get; set; }
        public string PostDetails { get; set; }
        public int Code { get; set; }
        public string Email { get; set; }
        public string Type { get; set; }
        
    }
}