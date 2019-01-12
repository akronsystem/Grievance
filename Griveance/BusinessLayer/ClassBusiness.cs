using Griveance.Models;
using Griveance.ResultModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Griveance.ParamModel;

namespace Griveance.BusinessLayer
{
    public class ClassBusiness
    {
        public object CreateClass([FromBody]ClassParameter obj)
        {
            GRContext db = new GRContext();
            tbl_class objcls = new tbl_class();
            objcls.class_name = obj.ClassName.ToString();
            objcls.course_name = obj.CourseName.ToString();
            objcls.Display = 1;
            objcls.created_date = DateTime.Now;
            db.tbl_class.Add(objcls);
            db.SaveChanges();
            return new Result
            {

                IsSucess = true,
                ResultData = "Class Created!"
            };
        }
    }
}