using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Griveance.Areas.Admin.Controllers
{
    public class SettingController : Controller
    {
        // GET: Admin/EmailSetting
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SmsSetting()
        {
            return View();
        }
    }
}