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
    public class CourseBusiness
    {
      
        public object GetCourseInfo()
        {
            GRContext context = new GRContext();
            try
            {
                var courses = context.ViewGetCourseInfoes.ToList();

                if (courses == null)
                    return new Result { IsSucess = false, ResultData = "Record Not Found" };
                else
                return new Result { IsSucess = true, ResultData = courses };
            }
            catch (Exception ex)
            {
                return new Error { IsError = true, Message = ex.Message };
            }
        }
        public object NewCourse([FromBody]CourseParameter obje)
        {
            GRContext db = new GRContext();
            tbl_courses objcourse = new tbl_courses();
           // objcourse.course_id = obje.Course_id;
            objcourse.course_name = obje.CourseName.ToString();
            db.tbl_courses.Add(objcourse);
            db.SaveChanges();
            return new Result
            {

                IsSucess = true,
                ResultData = "Course Created!"
            };

        }
    }
}