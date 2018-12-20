using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Griveance.ParamModel
{
    public class ParamSaveGriveance
    {

        public int UserId { get; set; }
        public string Password { get; set; }

        public string GriveanceType { get; set; }
        public string Subject { get; set; }
        public string PostDetails { get; set; }
    }
}