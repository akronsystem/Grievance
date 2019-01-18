using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Griveance.ParamModel
{
    public class ParamSmsSetting
    {
        public string GatewayUserid { get; set; }
        public string GatewayPassword { get; set; }
        public string SmsSendApi { get; set; }
        public string CheckbalanceApi { get; set; }
        public Int64 SettingId { get; set; }
        public string DisplayStatus { get; set; }

    }
}