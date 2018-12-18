using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Griveance.Areas.Staff.Controllers
{
    public class StaffController : Controller
    {
        // GET: Staff/Staff
        public ActionResult Index()
        {
            return View();
        }
        //Staff Grievance
        public ActionResult StaffGrievance()
        {
            return View();
        }
        //Post Grievance
        public ActionResult PostGrievance()
        {
            return View();
        }
    }
}