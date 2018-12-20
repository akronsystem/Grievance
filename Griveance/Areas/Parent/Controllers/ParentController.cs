using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Griveance.Areas.Parent.Controllers
{
    public class ParentController : Controller
    {
        // GET: Parent/Parent
        public ActionResult Index()
        {
            return View();
        }
        //Parent Grievance
        public ActionResult ParentGrievance()
        {
            return View();
        }
        //Parent Post Grievance
        public ActionResult PostGrievance()
        {
            return View();
        }
    }
}