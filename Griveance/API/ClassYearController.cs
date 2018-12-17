using Griveance.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Griveance.ParamModel;

namespace Griveance.Controllers
{
    public class ClassYearController : ApiController
    {
        [HttpGet]
        public object GetClassInfo()
        {
            GetClassInfoBL Objclass = new GetClassInfoBL();
            var GetClassVar = Objclass.ClassInfoBL();
            return GetClassVar;
        }
        [HttpPost]
        public object CreateClass([FromBody]ClassParameter obj)
        {
            ClassBusiness classB = new ClassBusiness();
            var Result = classB.CreateClass(obj);
            return Result;
        }
    }
}
