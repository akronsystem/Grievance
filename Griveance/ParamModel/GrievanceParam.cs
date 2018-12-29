using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Griveance.ParamModel
{
    public class GrievanceParam
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int GrievanceId { get; set; }
        public string GrievanceName { get; set; }
        public string GrievanceDescription { get; set; }

    }
}