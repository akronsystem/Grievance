using Griveance.Models;
using Griveance.ParamModel;
using Griveance.ResultModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Griveance.BusinessLayer
{
    public class GetSingleGrievanceBL
    {
        GRContext db = new GRContext();

        public object GetSingleGrievance(ParamGetSingleGrievance objgr)
        {
            try
            {
                var SingleGrievancelist = db.View_MemberAllocation.Where(r => r.UserId == objgr.UserId).FirstOrDefault();
                return SingleGrievancelist;
                //if (SingleGrievancelist == null)
                //{
                //    return new Error() { IsError = true, Message = "Grievance Not Found" };
                //}
                //else
                //{
                //    return new Result() { IsSucess = true, ResultData = SingleGrievancelist };
                //}
            }
            catch (Exception E)
            {
                return new Error() { IsError = true, Message = E.Message };
            }
        }
    }
}