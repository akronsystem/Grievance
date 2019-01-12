using Griveance.Models;
using Griveance.ResultModel;
using Griveance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Griveance.BusinessLayer
{
    public class ReportBusiness
    {
        GRContext db = new GRContext();
        public object ReportInfo()
        {
            try
            {
                var getlist = db.tbl_rpt.ToList();

                if (getlist == null)
                    return new Error() { IsError = true, Message = "Class List Not Found." };
                else
                    return new Result() { IsSucess = true, ResultData = getlist };

            }
            catch (Exception ex)
            {
                return new Error { IsError = true, Message = ex.Message };
            }
        }
    }
}