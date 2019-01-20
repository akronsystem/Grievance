using Griveance.Models;
using Griveance.ResultModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Griveance.Models;
using System.Web.Http;
using Griveance.ResultModel;
using System.Data.Entity.Validation;
using Griveance.ParamModel;

namespace Griveance.BusinessLayer
{
    public class MemberBusiness
    {
         public object GetMemberInfo(string status)
        {
            GRContext context = new GRContext();
            try
            {
               List<Griveance.Models.ViewGetMemberInfo> member = null;
           
                if (status=="Deactive")
                {
                    
                    member = context.ViewGetMemberInfoes.Where(r => r.Display == 0).ToList();
                }
               else
                {
                    member = context.ViewGetMemberInfoes.Where(r => r.Display == 1).ToList();
                }
                if (member == null)
                {
                    return new Result { IsSucess = false, ResultData = "Member Record Not Found" };
                }
                else
                {
                    return new Result { IsSucess = true, ResultData = member };
                }
            }
            catch (Exception ex)
            {
                return new Error { IsError = true, Message = ex.Message };
            }

        }
        public object GetSingleGrievanace(ParamMember obj)
        {

            GRContext context = new GRContext();
            try
            {
                var grievance = context.ViewGetMemberInfoes.Where(r => r.UserId == obj.UserId).FirstOrDefault();
                if (grievance == null)
                {
                    return new Result { IsSucess = false, ResultData = "Record Not Found" };
                }
                else
                {
                    return new Result { IsSucess = true, ResultData = grievance };
                }
            }
            catch (Exception ex)
            {
                return new Error { IsError = true, Message = ex.Message };
            }
        }

		public object SaveMember([FromBody]MemberParameter obj)
		{

			GRContext db = new GRContext();
			var usercode = db.tbl_member.Where(r => r.code == obj.Code).FirstOrDefault();
			if (usercode != null)
			{
				return new Error() { IsError = true, Message = "User Code Already Exists." };
			}


			tbl_user objuser = new tbl_user();
			objuser.name = obj.Name.ToString();
			objuser.UserId = Convert.ToInt32(obj.UserId);
			objuser.code = obj.Code;
			objuser.type = "Member";
			objuser.gender = obj.Gender.ToString();
			objuser.email = obj.EmailId.ToString();
			objuser.contact = Convert.ToInt64(obj.MobileNo);
			objuser.password = CryptIt.Encrypt(obj.Password);
			objuser.status = 1;
			objuser.Islive = 0;
			objuser.Display = 1;
			objuser.created_date = DateTime.Now;

			db.tbl_user.Add(objuser);

			try
			{
				db.SaveChanges();
			}
			catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
			{
				Exception raise = dbEx;
				foreach (var validationErrors in dbEx.EntityValidationErrors)
				{
					foreach (var validationError in validationErrors.ValidationErrors)
					{
						string message = string.Format("{0}:{1}",
							validationErrors.Entry.Entity.ToString(),
							validationError.ErrorMessage);
						// raise a new exception nesting  
						// the current instance as InnerException  
						raise = new InvalidOperationException(message, raise);
					}
				}
				throw raise;
			}
			tbl_member objmember = new tbl_member();
			tbl_user omember = db.tbl_user.Where(r => r.code == obj.Code).FirstOrDefault();
			objmember.UserId = omember.UserId;
			objmember.code = Convert.ToInt32(obj.Code);
			objmember.designation = obj.Designation.ToString();
            if (obj.GriType != null)
            {
                objmember.griType = obj.GriType.ToString();
            }

            objmember.Display = 1;
            objmember.created_date = DateTime.Now;
            db.tbl_member.Add(objmember);          
            db.SaveChanges();
            if (obj.GriType != null)
            {
                tbl_grievance_list list = db.tbl_grievance_list.Where(r => r.grivance_name == objmember.griType).FirstOrDefault();
                list.Isalloted = 1;
                db.SaveChanges();
            }
            return new Result
			{

				IsSucess = true,
				ResultData = "Member Created!"
			};
           
            



		}
		public object MemberList()
        {
            GRContext db = new GRContext();
            try
            {
                var member = db.View_ForMemberName.ToList();
                if (member == null)
                {
                    return new Result { IsSucess = false, ResultData = "Member Record Not Found" };
                }
                else
                {
                    return new Result { IsSucess = true, ResultData = member };
                }
            }
            catch (Exception ex)
            {
                return new Error { IsError = true, Message = ex.Message };
            }

        }
        public object GetMemberInfo(ParamComplaintDetails objmember)
        {
            GRContext db = new GRContext();
            try
            {
                var getfacultyinfo = db.tbl_complaintdetails.Where(r=>r.CompID==objmember.CompID).ToList();
                if (getfacultyinfo == null)
                {
                    return new Error() { IsError = true, Message = "Faculty Info Not Found" };
                }
                else
                {
                    return new Result() { IsSucess = true, ResultData = getfacultyinfo };
                }
            }
            catch (Exception ex)
            {
                return new Error { IsError = true, Message = ex.Message };
            }
        }

        public object UpdateMemberDetail(MemberParameter PR)
        {
            GRContext db = new GRContext();
            try
            {
                tbl_member objmember = db.tbl_member.Where(r => r.UserId == PR.UserId).FirstOrDefault();

                objmember.griType = PR.GriType;
                objmember.designation = PR.Designation;
                objmember.modified_date = DateTime.Now;
                if (PR.GriType != null)
                {
                    objmember.griType = PR.GriType;
                }
                db.SaveChanges();

                tbl_user objuser = db.tbl_user.Where(r => r.UserId == PR.UserId).FirstOrDefault();
                objuser.name = PR.Name;
                objuser.gender = PR.Gender;
                objuser.email = PR.EmailId;
                objuser.contact = PR.MobileNo; 
               
                db.SaveChanges();


                return new Result() { IsSucess = true, ResultData = "Member Updated Successfully." };
            }
            catch (Exception ex)
            {
                return new Error() { IsError = true, Message = ex.Message };
            }
        }

        public object DeleteMember(MemberParameter PR)
        {
            GRContext db = new GRContext();
            try
            {
                tbl_member objmember = db.tbl_member.Where(r => r.UserId == PR.UserId).FirstOrDefault();
               if( objmember.Display==1)
                {
                    objmember.Display = 0;

                }
                else
                {
                    objmember.Display = 1;

                }
               
               
                db.SaveChanges();

                tbl_user objuser = db.tbl_user.Where(r => r.UserId == PR.UserId).FirstOrDefault();
                if (objuser.Display == 1)
                {
                    objuser.Display = 0;

                }
                else
                {
                    objuser.Display = 1;

                }

                db.SaveChanges();


                return new Result() { IsSucess = true, ResultData = "Member Updated Successfully." };
            }
            catch (Exception ex)
            {
                return new Error() { IsError = true, Message = ex.Message };
            }
        }
        public object UpdateComp(ParamComplaintDetails PR)
        {
            GRContext db = new GRContext();
            try
            {
                tbl_complaintdetails objuser = db.tbl_complaintdetails.Where(r => r.CompID == PR.CompID).FirstOrDefault();
                objuser.GrievanceAction = PR.GrievanceAction;
                objuser.status = PR.status;
                db.SaveChanges();


                return new Result() { IsSucess = true, ResultData = "User Saved Successfully." };
            }
            catch (Exception ex)
            {
                return new Error() { IsError = true, Message = ex.Message };
            }
        }
    }
}