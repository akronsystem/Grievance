using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Griveance.Areas.Admin.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Admin/Dashboard
        public ActionResult Index()
        {
            return View();
        }
        //Logout 
        public ActionResult Logout()
        {
                FormsAuthentication.SignOut();
                Session.Abandon(); // it will clear the session at the end of request
            return View("/Views/Home/Index.cshtml");
           
        }
        public ActionResult AdminProfile()
        {
            return View();
        }
        public ActionResult NAdminProfile()
        {
            return View();
        }
    }
}