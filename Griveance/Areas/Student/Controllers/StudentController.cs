using Griveance.Models;
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
        GRContext db = new GRContext();
        // GET: Student/Student
        public ActionResult Index()
        {
                      
            //tbl_user objuser = db.tbl_user.Where(r => r.UserId == information).FirstOrDefault();
            //ViewData["UserId"]=objuser.UserId;
            //ViewBag.Name=objuser.name;
            //ViewData["UserName"] = objuser.name;
            //ViewData["Email"] = objuser.email;
            //ViewData["contactno"] = objuser.contact;
            return View("Index");
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