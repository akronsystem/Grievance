using Griveance.Models;
using Griveance.ParamModel;
using Griveance.ResultModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Griveance.BusinessLayer
{
    public class GetSingleFaculty
    {
        GRContext db = new GRContext();
        public object GetFaculty(FacultyParameters obj)
        {

            var ResultGetFaculty = db.Vw_GetSingleFaculty.Where(r => r.UserId == obj.UserId ).ToList();
            if(ResultGetFaculty.Count ==0)
            {
                return new Error() { IsError = true, Message = "Faculty Is Not Found" };
            }
            else
            {
                return new Result() { IsSucess = true, ResultData = ResultGetFaculty };
            }
                  
           
        }

    }
}