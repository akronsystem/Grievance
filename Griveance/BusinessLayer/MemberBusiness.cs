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
         public object GetMemberInfo()
        {
            GRContext context = new GRContext();
            try
            {
                var member = context.ViewGetMemberInfoes.ToList();
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
            tbl_member objmember = new tbl_member();
           
            objmember.id = Convert.ToInt32(obj.Id);
            objmember.code = Convert.ToInt32(obj.Code);
            objmember.designation = obj.Designation.ToString();
            objmember.griType = obj.GriType.ToString();         
            db.tbl_member.Add(objmember);           
            db.SaveChanges();

            tbl_user objuser = new tbl_user();
            objuser.name = obj.Name.ToString();
            objuser.code = obj.Code;
            objuser.type = obj.Type.ToString();
            objuser.gender = obj.Gender.ToString();
            objuser.email = obj.EmailId.ToString();
            objuser.contact = Convert.ToInt64(obj.MobileNo);
            objuser.password = CryptIt.Encrypt( obj.Password);
            objuser.status = 1;
            objuser.Islive = 0;

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

            return new Result
            {

                IsSucess = true,
                ResultData = "Member Created!"
            };



        }
     }
}