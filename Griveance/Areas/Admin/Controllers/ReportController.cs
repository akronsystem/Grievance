using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;  
using Griveance.Models;
using Griveance.BusinessLayer;

namespace Griveance.Areas.Admin.Controllers
{
    public class ReportController : Controller
    {
        // GET: Admin/Report
        ReportBusiness rpt = new ReportBusiness();
        GRContext db = new GRContext();
        string GrievanceNm;
        public ActionResult Index()
        {
            return View();
        }

        public object ReportDwonload(int id,string fromdate,string todate,int GriveanceType,int CellMember)
        {
            ViewData["Fromdate"] = fromdate;
            ViewData["Todate"] = todate;
            if (CellMember != -1)
            {
                tbl_user user = db.tbl_user.Where(r => r.UserId == CellMember).FirstOrDefault();
                var membername = user.name;
                ViewData["MemberName"] = membername;
                switch (id)
                {
                    case 8:
                        id = 8;
                        var result9 = rpt.GrievanceMemberPendingRpt(fromdate, todate, CellMember);
                        return View("PendingRCellMember",result9);
                    case 9:
                        id = 9;
                        var result10 = rpt.GrievanceMemberClosedRpt(fromdate, todate, CellMember);
                        return View("ClosedRCellMember",result10);

                }
            }
            if (GriveanceType != -1)
            {
                tbl_grievance_list obGR = db.tbl_grievance_list.Where(r => r.grivance_id == GriveanceType).FirstOrDefault();
                GrievanceNm = obGR.grivance_name;
                switch (id)
                {

                    case 5:
                        id = 5;
                        var resul5 = rpt.GRDetailedReport(fromdate, todate, GrievanceNm);
                        return View("DetailedRGriType", resul5);
                    case 6:
                        id = 6;
                        var result7 = rpt.GRDetailedClosedReport(fromdate, todate, GrievanceNm);
                        return View("ClosedRGriType", result7);
                    case 7:
                        id = 7;
                        var result6 = rpt.GRDetailedPendingReport(fromdate, todate, GrievanceNm);
                        return View("PendingRGriType",result6);

                }

            }
            switch (id)
            {
                case 1:
                    id = 1;
                    var result1 = rpt.ShowGraphFunction();
                    return View("ConsolidatedGrievance", result1);

                case 2:
                    id = 2;
                    var result7 = rpt.DetailedReport(fromdate, todate);
                    return View("DetailedGrievance",result7);

                case 3:
                    id = 3;

                    var result = rpt.GetGrievanceList(fromdate, todate);
                    ViewData["resultData"] = result;
                    return View("PendingGrievance", result);
                case 4:
                    id = 4;
                    var result4 = rpt.ClosedGrievance(fromdate, todate);
                    return View("ClosedGrievance", result4);               

            }
           
            return null;
        }

        public ActionResult Report1()
        {
            return View("Report1");
        }
        //ConsolidatedGrievance Report
        public ActionResult ConsolidatedGrievance()
        {
            return View("ConsolidatedGrievance");
        }
        //DetailedGrievance Report
        public ActionResult DetailedGrievance()
        {
            return View("DetailedGrievance");
        }
        //PendingGrievance Report
        public ActionResult PendingGrievance()
        {
           
            return View("PendingGrievance");
        }
        //ClosedGrievance Report
        public ActionResult ClosedGrievance()
        {
            return View("ClosedGrievance");
        }
        //DetailedReportGriType Report
        public ActionResult DetailedRGriType()
        {
            return View("DetailedRGriType");
        }
        //PendingReportGriType Report
        public ActionResult PendingRGriType()
        {
            return View("PendingRGriType");
        }
       // ClosedReportGriType Report
       public ActionResult ClosedRGriType()
        {
            return View("ClosedRGriType");
        }
        //PendingReportCellMember Report
        public ActionResult PendingRCellMember()
        {
            return View("PendingRCellMember");

        }
        //ClosedReportCellMember Report
        public ActionResult ClosedRCellMember()
        {
            return View("ClosedRCellMember");
        } 
    }
}