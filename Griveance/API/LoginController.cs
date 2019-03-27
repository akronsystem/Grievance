﻿using Griveance.BusinessLayer;
using Griveance.Models;
using Griveance.ParamModel;
using Griveance.ResultModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Griveance.Controllers
{
    public class LoginController : ApiController
    {
		
		[HttpGet]
		public object Test()
		{
			return "test";
		}

        [HttpGet]
        public object GetUser()
        {
            var name=CryptIt.Decrypt("vPelNrzLabeGOYF6LMYvZA==");
            try
            {
                UserCredentialModel userCredentialModel = new UserCredentialModel() { UserName = "Admin" };
                return userCredentialModel;
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };

            }


        }

        [HttpPost]
        public object ValidateUserLogin(UserCredentialModel userCredentialModel)
        {
            try
            {
                ValidateUser Validuser = new ValidateUser();
                var result = Validuser.IsValidUser(userCredentialModel);
                return result;
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };

            }
           


        }
        [HttpPost]
        public object ForgetPassword(ForgetPassword obj)
        {
            if(obj.ContactNumber==null)
            {
                return new Error() { IsError = true, Message = "Contact Number Required" };
            }
            GRContext db = new GRContext();
            string res = "";
            var user = db.tbl_user.Where(r => r.contact == obj.ContactNumber).FirstOrDefault();
            if(user==null)
            {
                return new Error() { IsError = true, Message = "Contact Number Not Found" };
            }
            if(user.name.Length>0)
            {
                res = "Dear <b>" + user.name + "</b> your User Name is <b>" + user.name + "</b> and Password is <b>" + CryptIt.Decrypt(user.password) + "</b>.";
                
            }
            else
            {
                res = "Sorry we didn't find you in our system.";
                return res;
            }
            try
            {
                Email objemail = new Email();
                bool IsDelete;
                if (user.email.Length > 0)
                {
                    //IsDelete = objSMS.SMSSend(MobNo, res);
                    IsDelete = objemail.SendEmail(user.email, res, "Forgot Password", "", "", "", "");
                    res = "User Name and Password Is Send On Your Registred Email ID. ";
                    return new Result() { IsSucess = true, ResultData =res };
                }
                else
                {
                    res = "Sorry we didn't find your Email ID in our system.";
                    //return new Error() { IsError = true, Message = res };
                }
                return res;
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };

            }


        }

    }
}
