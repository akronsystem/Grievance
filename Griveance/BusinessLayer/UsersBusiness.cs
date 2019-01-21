using Griveance.Models;
using Griveance.ResultModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Griveance.ParamModel;

namespace Griveance.BusinessLayer
{
    public class UsersBusiness
    {
        GRContext context = new GRContext();
        public object GetSingleParentInfo(ParamUser obj)
        {
           
            try
            {
                var parent = context.ViewGetSingleParentInfoes.Where(r => r.UserId == obj.UserId).FirstOrDefault();
                if (parent == null)
                {
                    return new Result { IsSucess = false, ResultData = "Record Not Found" };
                }
                else
                {
                    // return new Result { IsSucess = true, ResultData = parent };
                    return parent;
                }
            }
            catch (Exception ex)
            {
                return new Error { IsError = true, Message = ex.Message};
            }
        }
        public object UpdateUser(ParamRegistration PR)
        {
            try
            {

                tbl_user obj = context.tbl_user.Where(r => r.UserId == PR.UserId).FirstOrDefault();
         

                if (PR.Password == null)
                {

                    obj.name = PR.Name;
                    obj.email = PR.Email;
                    obj.contact = PR.Contact;
                    //obj.password = PR.Password;
                }
                else
                {
                    var oldpassword = context.tbl_user.FirstOrDefault(r => r.UserId == PR.UserId);
                if(CryptIt.Decrypt(oldpassword.password) == PR.OldPassword)
                    {
                        obj.name = PR.Name;
                        obj.email = PR.Email;
                        obj.contact = PR.Contact;
                        obj.password = CryptIt.Encrypt(PR.Password);
                    }
                else
                    {
                        return new Error() { IsError = true, Message = "Please Check old password." };
                    }
                    
                }
                context.SaveChanges();
                return new Result() { IsSucess = true, ResultData = "User Updated Successfully." };

            }
            catch (Exception ex)
            {
                return new Error() { IsError = true, Message = ex.Message };
            }
        }

    }
}