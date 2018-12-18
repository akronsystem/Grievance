using Griveance.Models;
using Griveance.ParamModel;
using Griveance.ResultModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Griveance.BusinessLayer
{
    public class GetSingleStaffData
    {

        GRContext objcontext = new GRContext();
        public object GetSingleStaffValue(ParamGetSingleStaffInfo objstaff)
        {
            try
            {
                var StaffData = objcontext.ViewAllStaffInfoes.Where(r => r.UserId == objstaff.UserId).FirstOrDefault();
                if (StaffData== null)
                {
                    return new Error { IsError = true, Message = "Staff Data Not Found" };
                }
                else
                {
                    return new Result { IsSucess = true, ResultData = StaffData };
                }
                
            }
            catch (Exception ex)
            {
                return new Error() { IsError = true, Message = ex.Message };
            }
        }
    }
}