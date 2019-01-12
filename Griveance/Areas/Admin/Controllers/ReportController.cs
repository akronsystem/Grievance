using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;  
using Griveance.Models;

namespace Griveance.Areas.Admin.Controllers
{
    public class ReportController : Controller
    {
        // GET: Admin/Report
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ReportDwonload(int id,string fromdate,string todate)
        {
            ViewData["Fromdate"] = fromdate;
            ViewData["Todate"] = todate;

            switch (id)
            {
                case 1:id = 1;
                    return View("ConsolidatedGrievance");
                   
                case 2:id = 2;
                    return View("DetailedGrievance");
                   
                case 3:id = 3;
                     return View("PendingGrievance");
                case 4:id = 4;
                    return View("ClosedGrievance");
           
                case 5:id = 5;
                    return View("DetailedRGriType");
                case 6:id = 6;
                    return View("PendingRGriType");
                case 7:id = 7;
                    return View("ClosedRGriType");
                case 8:id = 8;
                    return View("PendingRCellMember");
                case 9:id = 9;
                    return View("ClosedRCellMember");
                   

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