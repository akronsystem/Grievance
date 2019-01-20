using Griveance.Models;
using Griveance.ParamModel;
using Griveance.ResultModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Griveance.BusinessLayer
{
    public class SaveGrievance
    {
        GRContext db = new GRContext();
        public object GrievanceSave(GrievanceParam PR)
        {
            try
            {
                //var usercode = db.tbl_user.Where(r => r.code == PR.Code).FirstOrDefault();
                if (PR.GrievanceName == null)
                {
                    return new Error() { IsError = true, Message = "Required Grievance Name" };
                }
                tbl_grievance_list objuser = new tbl_grievance_list();
                var result = db.tbl_grievance_list.Where(r => r.grivance_name == PR.GrievanceName);
                if (result != null)
                {
                    return new Error() { IsError = true, Message = "Duplicate Entry Not Allowd" };
                }

                objuser.grivance_name = PR.GrievanceName;
                objuser.grivance_description = PR.GrievanceDescription;
                objuser.Display = 1;
                objuser.created_date = DateTime.Now;
                
                objuser.Isalloted = 0;
                db.tbl_grievance_list.Add(objuser);
                db.SaveChanges();

               
                return new Result() { IsSucess = true, ResultData = "User Saved Successfully." };


            }
            catch (Exception ex)
            {
                return new Error() { IsError = true, Message = ex.Message };
            }
        }
        public object UpdateGrievance(GrievanceParam PR)
        {
            try
            {
                tbl_grievance_list obGR = db.tbl_grievance_list.Where(r => r.grivance_id == PR.GrievanceId).FirstOrDefault();

                obGR.grivance_name = PR.GrievanceName;
                obGR.grivance_description = PR.GrievanceDescription;              
                obGR.Isalloted = 0;
               
                //db.tbl_user.Add(objuser);
                db.SaveChanges();               

                return new Result() { IsSucess = true, ResultData = "Grievance Update Successfully." };
            }
            catch (Exception ex)
            {
                return new Error() { IsError = true, Message = ex.Message };
            }
        }


        public object UpdateGrievanceAllocation(GrievanceAllocationParam PR)
        {
            try
            {
                tbl_member obGR = db.tbl_member.Where(r => r.UserId == PR.UserId).FirstOrDefault();

                obGR.griType = PR.griType;
                obGR.designation = PR.designation;
                obGR.modified_date = DateTime.Now;
                //db.tbl_user.Add(objuser);
                db.SaveChanges();

                tbl_grievance_list objgrlist= db.tbl_grievance_list.Where(r => r.grivance_name == PR.griType).FirstOrDefault();
                objgrlist.Isalloted = 1;
                db.SaveChanges();

                tbl_user objuser = db.tbl_user.Where(r => r.UserId == PR.UserId).FirstOrDefault();
                objuser.name = PR.name;
                objuser.code = PR.code;
                objuser.email = PR.email;
                objuser.contact = PR.contact;
                db.SaveChanges();
                return new Result() { IsSucess = true, ResultData = "Grievance Update Successfully." };
            }
            catch (Exception ex)
            {
                return new Error() { IsError = true, Message = ex.Message };
            }
        }


        public object DeleteGrievanceAllocation(ParamRegistration PR)
        {
            try
            {
                tbl_member objmember = db.tbl_member.Where(r => r.UserId == PR.UserId).FirstOrDefault();

                if (objmember.Display == 1)
                {
                    objmember.Display = 0;
                }
                else
                {
                    objmember.Display = 1;
                }

                db.SaveChanges();

                return new Result() { IsSucess = true, ResultData = "Member Updated Successfully." };
            }
            catch (Exception ex)
            {
                return new Error() { IsError = true, Message = ex.Message };
            }
        }


        public object GetGrievanceData(GrievanceParam obj)
        {
            var GrievanceData = db.tbl_grievance_list.Where(r => r.grivance_id == obj.GrievanceId).SingleOrDefault();
            return GrievanceData;
        }
    }
}