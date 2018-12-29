using Griveance.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Griveance.ParamModel;
using Griveance.Models;

namespace Griveance.Controllers
{
    public class ClassYearController : ApiController
    {
        [HttpPost]
        public object GetClassInfo()
        {
            try
            {
                GetClassInfoBL Objclass = new GetClassInfoBL();
                var GetClassVar = Objclass.ClassInfoBL();
                return GetClassVar;
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }

        }
        [HttpPost]
        public object CreateClass([FromBody]ClassParameter obj)
        {
            try
            {
                ClassBusiness classB = new ClassBusiness();
                var Result = classB.CreateClass(obj);
                return Result;
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }

        }
        [HttpPost]
        public object GetAllClassInfo()
        {
            try
            {
                GetClassInfoBL Objclass = new GetClassInfoBL();
                var GetClassVar = Objclass.ClassInfo();
                return GetClassVar;
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }

        }
    }
}
