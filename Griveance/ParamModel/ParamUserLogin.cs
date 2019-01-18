using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Griveance.ParamModel
{
    public class ParamUserLogin
    {
        public int UserId { get; set; }
        public string Password { get; set; }
        public string DisplayStatus { get; set; }
    }
}