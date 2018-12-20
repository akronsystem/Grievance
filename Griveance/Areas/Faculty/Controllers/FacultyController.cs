using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Griveance.Areas.Faculty.Controllers
{
    public class FacultyController : Controller
    {
        // GET: Faculty/Faculty
        public ActionResult Index()
        {
            return View();
        }
        //Faculty Grievance
        public ActionResult FacultyGrievance()
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