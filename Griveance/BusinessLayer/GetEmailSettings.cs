using Griveance.Models;
using Griveance.ParamModel;
using Griveance.ResultModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Griveance.BusinessLayer
{
    public class GetEmailSettings
    {
        GRContext obj = new GRContext();
        public object GetEmailSettList()
        {
            var EmailList = obj.tbl_emailsettings.ToList();
            return new Result() { IsSucess = true, ResultData = EmailList };
           

        }

        public object GetEmailData(ParamEmailSettings objemail)
        {
            var EmailData = obj.tbl_emailsettings.Where(r => r.emailsettingid == objemail.emailsettingid).SingleOrDefault();
            return EmailData;
        }
    }
}