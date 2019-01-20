using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Griveance.ParamModel
{
    public class GrievanceAllocationParam
    {
        public int id { get; set; }
        public int UserId { get; set; }
        public string griType { get; set; }
        public string name { get; set;}
        public int code { get; set; }
        public string designation { get; set; }
        public string email { get; set; }
        public long contact { get; set; }

    }
}