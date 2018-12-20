using Griveance.Models;
using Griveance.ParamModel;
using Griveance.ResultModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Griveance.BusinessLayer
{
    public class GetGrievanceListBL
    {
        GRContext db = new GRContext();

        public object GetGrievanceList(ParamGetGrievanceList objparam)
        {
            try
            {
                var Grievancelist = db.ViewGrievanceLists.ToList();

                if (Grievancelist == null)
                {
                    return new Error() { IsError = true, Message = "Grievance List Not Found" };
                }
                else
                {
                    return new Result() { IsSucess = true, ResultData = Grievancelist };
                }
            }
            catch (Exception E)
            {
                return new Error() { IsError = true, Message = E.Message };
            }
        }
        public object GetGrievanceAllocation(ParamGetGrievanceList objparam)
        {
            try
            {
                var Grievancelist = db.View_MemberAllocation.ToList();

                if (Grievancelist == null)
                {
                    return new Error() { IsError = true, Message = "Grievance List Not Found" };
                }
                else
                {
                    return new Result() { IsSucess = true, ResultData = Grievancelist };
                }
            }
            catch (Exception E)
            {
                return new Error() { IsError = true, Message = E.Message };
            }
        }
    }
}