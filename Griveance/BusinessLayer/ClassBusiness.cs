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
            tbl_class tbl_member = new tbl_class();
            tbl_member.class_name = obj.ClassName.ToString();
            tbl_member.course_name = obj.CourseName.ToString();
            db.tbl_class.Add(tbl_member);
            db.SaveChanges();
            return new Result
            {

                IsSucess = true,
                ResultData = "Class Created!"
            };
        }
    }
}