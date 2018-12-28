using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Griveance.Areas.Student.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student/Student
        public ActionResult Index()
        {
       
            return View();
        }
        //Student Grievance
        public ActionResult StudentGrievance()
        {
            return View();
        }
        //Student Post Grievance
        public ActionResult PostGrievance()
        {
            return View();
        }
    }
}