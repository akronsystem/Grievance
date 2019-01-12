using Griveance.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Griveance.ParamModel;
using Griveance.Models;

namespace Griveance.API
{
    public class ReportController : ApiController
    {
        [HttpPost]
        public object GetReportType()
        {
            try
            {
                ReportBusiness Objclass = new ReportBusiness();
                var GetReport = Objclass.ReportInfo();
                return GetReport;
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }

        }
    }
}
