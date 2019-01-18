using Griveance.Models;
using Griveance.Models;
using Griveance.ParamModel;
using Griveance.ResultModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Griveance.BusinessLayer
{
    public class GetFacultyInfoBL
    {
        GRContext db = new GRContext();

        public object GetFacultyInfo(ParamGetFacultyInfo objfaculty)
        {
            try
            {
                List<Griveance.Models.ViewGetFacultyInfo> getfacultyinfo = null;

                if (objfaculty.DisplayStatus=="Dective")
                {
                    getfacultyinfo = db.ViewGetFacultyInfoes.Where(r => r.Display != 1).ToList();
                }
                else
                {
                    getfacultyinfo = db.ViewGetFacultyInfoes.Where(r => r.Display == 1).ToList();
                   
                }
                
                if (getfacultyinfo == null)
                {
                    return new Error() { IsError = true, Message = "Faculty Info Not Found" };
                }
                else
                {
                    return new Result() { IsSucess = true, ResultData = getfacultyinfo };
                }
            }
            catch(Exception ex)
            {
                return new Error { IsError = true, Message = ex.Message };
            }
        }
    }
}