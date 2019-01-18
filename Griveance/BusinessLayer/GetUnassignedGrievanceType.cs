using Griveance.Models;
using Griveance.ResultModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Griveance.BusinessLayer
{
    public class GetUnassignedGrievanceType
    {
        GRContext obj = new GRContext();
        public object GetUnassignedGrievance()
        {
            try
            {
                var GrievanceType = obj.tbl_grievance_list.Where(R => R.Isalloted == 0).ToList();
                if (GrievanceType.Count() == 0)
                {
                    return new Error() { IsError = true, Message = "No Unassigned Grievance Type Found." };
                }
                else
                {
                    return new Result() { IsSucess = true, ResultData = GrievanceType };
                }
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };

            }

        }
    }
}