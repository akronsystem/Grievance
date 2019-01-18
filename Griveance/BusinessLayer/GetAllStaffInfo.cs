using Griveance.Models;
using Griveance.ResultModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Griveance.BusinessLayer
{
    public class GetAllStaffInfo
    {
        GRContext gc = new GRContext();

        public object GetStaffInfo(string status)
        {
            try
            {
                List<Griveance.Models.ViewAllStaffInfo> StaffInfo = null;

                if (status=="Dective")
                {
                    StaffInfo = gc.ViewAllStaffInfoes.Where(r => r.Display != 1).ToList();
                   
                }
                else
                {
                    StaffInfo = gc.ViewAllStaffInfoes.Where(r => r.Display == 1).ToList();
                }
               
                if(StaffInfo==null)
                {
                    return new Error() { IsError = true, Message = "Staff Info Not Found" };

                }
                else
                {
                    return new Result()
                    {
                        IsSucess = true,
                        ResultData = StaffInfo

                    };
                }
            }
            catch(Exception ex)
            {
                return new Error() { IsError = true, Message = ex.Message };
            }
        }
    }
}