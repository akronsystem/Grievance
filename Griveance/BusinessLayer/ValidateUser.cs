using Griveance.Models;
using Griveance.ResultModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Griveance.BusinessLayer
{
    public class ValidateUser
    {
        GRContext db = new GRContext();
        public object IsValidUser(UserCredentialModel userCredentialModel)
        {
            var password = CryptIt.Encrypt(userCredentialModel.Password);
            var user = db.tbl_user.FirstOrDefault(r => r.email == userCredentialModel.UserName
                      && r.password == password) ;

            if (user == null)
            {
                return new Error() { IsError = true, Message = "Incorrect User Or Password.." };
            }
            else
            {
                return new Result() { IsSucess = true, ResultData = user };
            }

           
           
        }
    }
}