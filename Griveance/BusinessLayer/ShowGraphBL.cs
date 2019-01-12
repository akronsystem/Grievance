using Griveance.Models;
using Griveance.ParamModel;
using Griveance.ResultModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Griveance.BusinessLayer
{
   
    public class ShowGraphBL
    {
        GRContext db = new GRContext();

        public object ShowGraphFunction()
        {
            try
            {
                var totalgri = db.tbl_complaintdetails.ToList();
                var pendinggri = db.tbl_complaintdetails.Where(r => r.status == "Pending").ToList();
                var closedgri = db.tbl_complaintdetails.Where(r => r.status == "Closed").ToList();


                object[,] str = new object[2, 2];
                str[0, 0] = "Pending";
                double pendingper = Convert.ToDouble(pendinggri.Count) / Convert.ToDouble(totalgri.Count) * 100;
                str[0, 1] = string.Format("{0:0.00}", pendingper) ;

                str[1, 0] = "Closed";
                double closedper = Convert.ToDouble(closedgri.Count) / Convert.ToDouble(totalgri.Count) * 100;
                str[1, 1] = string.Format("{0:0.00}", closedper);

                return str;
            }
            catch(Exception ex)
            {
                return new Error() { IsError = true, Message = ex.Message };
            }
        }
    }
}