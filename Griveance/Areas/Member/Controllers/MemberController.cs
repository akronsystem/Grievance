using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Griveance.Areas.Member.Controllers
{
    public class MemberController : Controller
    {
        // GET: Member/Member
        public ActionResult Index()
        {
            return View();
        }
        //Member Grievance
        public ActionResult MemberGrievance()
        {
            return View();

        }
    }
}