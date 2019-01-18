using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Griveance.ParamModel
{
    public class ClassParameter
    {
        
        public string UserId { get; set; }
        public string Password { get; set; }
        public string ClassName{ get; set; }
        public string CourseName { get; set; }

    }
}