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
            var id = Convert.ToString(obj.StudentCode);
            if(id=="0")
            {
                return new Error() { IsError = true, Message = "UserCode Not Found" };
            }
            try
            {
                var MyGrievance = db.ViewGetMyGrievances.Where(r => r.StackholderID ==id).ToList();

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
        public object GetMember(ParamGetMyGrievance obj)
        {
           

            var id = Convert.ToString(obj.StudentCode);
            var userid = Convert.ToInt32(obj.Userid);
            if (id == "0")
            {
                return new Error() { IsError = true, Message = "UserCode Not Found" };
            }
            try
            {
                tbl_member s = new tbl_member();
                var MyGrievance = db.tbl_member.Where(r => r.UserId == userid).SingleOrDefault();
                var type = MyGrievance.griType;
                var list = db.tbl_complaintdetails.Where(r => r.GrievanceType == type).ToList();
                if (MyGrievance == null)
                {
                    return new Error() { IsError = true, Message = "My Grievance Not Found" };
                }
                else
                {
                    return new Result() { IsSucess = true, ResultData = list };
                }
            }
            catch (Exception E)
            {
                return new Error() { IsError = true, Message = E.Message };
            }
        }
    }
}