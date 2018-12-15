using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Griveance.Areas.Admin.Controllers
{
    public class GriveanceController : Controller
    {
        // GET: Admin/Griveance
        public ActionResult Index()
        {
            return View();
        }
        //Grievance Type
        public ActionResult GrievanceType()
        {
            return View();
        }
        //Grievance Cell Member
        public ActionResult GrievanceAllocation()
        {
            return View();
        }
        //All Grievances
        public ActionResult AllGrievances()
        {
            return View();
        }
    }
}