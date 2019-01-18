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
            if (obj.UserId == null)
            {
                return new Result { IsSucess = false, ResultData = "UserId Requird" };
            }
            GRContext db = new GRContext();
            tbl_class objcls = new tbl_class();
            var result = db.tbl_class.Where(r => r.class_name == obj.ClassName);
            if (result != null)
            {
                return new Error() { IsError = true, Message = "Duplicate Entry Not Allowd" };
            }
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