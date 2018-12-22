using Griveance.Models;
using Griveance.ParamModel;
using Griveance.ResultModel;
using Griveance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Griveance.BusinessLayer
{
    public class GetSingleStudentBL
    {
        GRContext db = new GRContext();

        public object GetSingleStudent(ParamGetSingleStudent obj)
        {
            try
            {
                var singlestudent = db.ViewGetStudentInfoes.Where(r => r.UserId == obj.UserId ).FirstOrDefault();

                if (singlestudent == null)
                {
                    return new Error() { IsError = true, Message = "Student Not Found" };
                }
                else
                {
                    return new Result() { IsSucess = true, ResultData = singlestudent };
                }
            }
            catch(Exception E)
            {
                return new Error() { IsError = true, Message = E.Message };
            }
        }
    }
}