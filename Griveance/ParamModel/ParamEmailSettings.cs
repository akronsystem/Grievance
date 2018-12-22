using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Griveance.ParamModel
{
    public class ParamEmailSettings
    {
        public string fromid { get; set; }
        public string host { get; set; }
        public int port { get; set; }
        public string password{get;set;}

        public Int64 emailsettingid { get; set; }
    }
}