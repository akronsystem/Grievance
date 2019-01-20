﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Griveance.ParamModel
{
    public class MemberParameter
    {
      
        public int Code { get; set; }
        public string Designation { get; set; }
        public string GriType { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Gender { get; set; }
        public string EmailId { get; set; }
        public long MobileNo { get; set; }
        public string Password { get; set; }
        public string ConPassword { get; set; }
        public Int64 UserId { get; set; }

        public string DisplayStatus { get; set; }


    }
}