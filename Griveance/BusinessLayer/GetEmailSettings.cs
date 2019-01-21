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
        public object GetEmailSettList(string status)
        {
            List<Griveance.Models.Vw_GetEmail> EmailList = null;
            if(status=="Deactive")
            {
                EmailList = obj.Vw_GetEmail.Where(r => r.Display != 1).ToList();
            }
            else
            {
                EmailList = obj.Vw_GetEmail.Where(r => r.Display == 1).ToList();
               
            }
           
            return new Result() { IsSucess = true, ResultData = EmailList };
           

        }

        public object GetEmailData(ParamEmailSettings objemail)
        {
            var EmailData = obj.tbl_emailsettings.Where(r => r.emailsettingid == objemail.emailsettingid && r.Display==1).SingleOrDefault();
            return EmailData;
        }

       
    }
}