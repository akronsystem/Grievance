using Griveance.Models;
using Griveance.ResultModel;
using Griveance.ParamModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Griveance.ParamModel;

namespace Griveance.BusinessLayer
{
    public class ReportBusiness
    {
        GRContext db = new GRContext();
        public object ReportInfo()
        {
            try
            {
                var getlist = db.tbl_rpt.Where(r => r.Display == 1).ToList();

                if (getlist == null)
                    return new Error() { IsError = true, Message = "Report Type Not Found." };
                else
                    return new Result() { IsSucess = true, ResultData = getlist };

            }
            catch (Exception ex)
            {
                return new Error { IsError = true, Message = ex.Message };
            }
        }
        public object GetGrievanceList(string fromdate, string todate)
        {
            var date1 =Convert.ToDateTime(fromdate);
            var date2 = Convert.ToDateTime(todate);
            try
            {
                var Grievancelist = db.View_ReportViewGrievanceList.Where(r => r.status == "Pending" && r.Date >= date1 && r.Date <= date2).ToList();

                if (Grievancelist == null)
                {
                    return new Error() { IsError = true, Message = "Grievance List Not Found" };
                }
                else
                {
                    return Grievancelist;
                }
            }
            catch (Exception E)
            {
                return new Error() { IsError = true, Message = E.Message };
            }
        }
        public object ShowGraphFunction()
        {
            ReportCountParam rp = new ReportCountParam();
            try
            {
                rp.Total = db.tbl_complaintdetails.Where(r=>r.Display==1).Count();
                rp.Pending= db.tbl_complaintdetails.Where(r => r.status == "Pending" &&r.Display==1).Count();
                rp.Closed = db.tbl_complaintdetails.Where(r => r.status == "Closed" && r.Display == 1).Count();

                return rp;
                
            }
            catch (Exception ex)
            {
                return new Error() { IsError = true, Message = ex.Message };
            }
        }
        public object ClosedGrievance(string fromdate, string todate)
        {
            var date1 = Convert.ToDateTime(fromdate);
            var date2 = Convert.ToDateTime(todate);
            try
            {
                var Grievancelist = db.View_ReportViewGrievanceList.Where(r => r.status == "Closed" && r.Date >= date1 && r.Date <= date2).ToList();

                if (Grievancelist == null)
                {
                    return new Error() { IsError = true, Message = "Grievance List Not Found" };
                }
                else
                {
                    return Grievancelist;
                }
            }
            catch (Exception E)
            {
                return new Error() { IsError = true, Message = E.Message };
            }
        }
        public object GRDetailedReport(string fromdate, string todate,string Grname)
        {
            var date1 = Convert.ToDateTime(fromdate);
            var date2 = Convert.ToDateTime(todate);
            try
            {
                var Grievancelist = db.View_ReportViewGrievanceList.Where(r => r.GrievanceType == Grname && r.Date >= date1 && r.Date <= date2).ToList();

                if (Grievancelist == null)
                {
                    return new Error() { IsError = true, Message = "Grievance List Not Found" };
                }
                else
                {
                    return Grievancelist;
                }
            }
            catch (Exception E)
            {
                return new Error() { IsError = true, Message = E.Message };
            }
        }
        public object GRDetailedClosedReport(string fromdate, string todate, string Grname)
        {
            var date1 = Convert.ToDateTime(fromdate);
            var date2 = Convert.ToDateTime(todate);
            try
            {
                var Grievancelist = db.View_ReportViewGrievanceList.Where(r => r.GrievanceType == Grname && r.status=="Closed" && r.Date >= date1 && r.Date <= date2).ToList();

                if (Grievancelist == null)
                {
                    return new Error() { IsError = true, Message = "Grievance List Not Found" };
                }
                else
                {
                    return Grievancelist;
                }
            }
            catch (Exception E)
            {
                return new Error() { IsError = true, Message = E.Message };
            }
        }
        public object GRDetailedPendingReport(string fromdate, string todate, string Grname)
        {
            var date1 = Convert.ToDateTime(fromdate);
            var date2 = Convert.ToDateTime(todate);
            try
            {
                var Grievancelist = db.View_ReportViewGrievanceList.Where(r => r.GrievanceType == Grname && r.status == "Pending" && r.Date >= date1 && r.Date <= date2).ToList();

                if (Grievancelist == null)
                {
                    return new Error() { IsError = true, Message = "Grievance List Not Found" };
                }
                else
                {
                    return Grievancelist;
                }
            }
            catch (Exception E)
            {
                return new Error() { IsError = true, Message = E.Message };
            }
        }
        public object DetailedReport(string fromdate, string todate)
        {
            var date1 = Convert.ToDateTime(fromdate);
            var date2 = Convert.ToDateTime(todate);
            try
            {
                var Grievancelist = db.View_DetailedReport.Where(r => r.Date >= date1 && r.Date <= date2).ToList();

                if (Grievancelist == null)
                {
                    return new Error() { IsError = true, Message = "Grievance List Not Found" };
                }
                else
                {
                    return Grievancelist;
                }
            }
            catch (Exception E)
            {
                return new Error() { IsError = true, Message = E.Message };
            }
        }
        public object GrievanceMemberPendingRpt(string fromdate, string todate, int userid)
        {
           
            var id = Convert.ToInt32(userid);
            try
            {
                tbl_member s = new tbl_member();
                var MyGrievance = db.tbl_member.Where(r => r.UserId == id).SingleOrDefault();
                var type = MyGrievance.griType;
                var list = db.View_ReportViewGrievanceList.Where(r => r.GrievanceType == type && r.status=="Pending").ToList();
                if (MyGrievance == null)
                {
                    return new Error() { IsError = true, Message = "My Grievance Not Found" };
                }
                else
                {
                    return  list;
                }
            }
            catch (Exception E)
            {
                return new Error() { IsError = true, Message = E.Message };
            }

        }
        public object GrievanceMemberClosedRpt(string fromdate, string todate, int userid)
        {

            var id = Convert.ToInt32(userid);
            try
            {
                tbl_member s = new tbl_member();
                var MyGrievance = db.tbl_member.Where(r => r.UserId == id).SingleOrDefault();
                var type = MyGrievance.griType;
                var list = db.View_ReportViewGrievanceList.Where(r => r.GrievanceType == type && r.status == "Closed").ToList();
                if (MyGrievance == null)
                {
                    return new Error() { IsError = true, Message = "My Grievance Not Found" };
                }
                else
                {
                    return list;
                }
            }
            catch (Exception E)
            {
                return new Error() { IsError = true, Message = E.Message };
            }

        }
    }
}