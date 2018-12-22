using Griveance.Models;
using Griveance.ParamModel;
using Griveance.ResultModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Griveance.BusinessLayer
{
    public class GetMyGrievanceBL
    {
        GRContext db = new GRContext();

        public object GetMyGrievance(ParamGetMyGrievance obj)
        {
            try
            {
                var MyGrievance = db.ViewGetMyGrievances.Where(r => r.CompID == obj.StudentCode).ToList();

                if (MyGrievance == null)
                {
                    return new Error() { IsError = true, Message = "My Grievance Not Found" };
                }
                else
                {
                    return new Result() { IsSucess = true, ResultData = MyGrievance };
                }
            }
            catch (Exception E)
            {
                return new Error() { IsError = true, Message = E.Message };
            }
        }
    }
}