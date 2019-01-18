using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Griveance.ParamModel
{
    public class ReportCountParam
    {
        public int Total { get; set; }
        public int Pending { get; set; }
        public int Closed { get; set; }
    }
}