using Griveance.BusinessLayer;
using Griveance.Models;
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
            try
            {
                UserCredentialModel userCredentialModel = new UserCredentialModel() { UserName = "pradip.chougule@jjmcoe.ac.in" };
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
      
    }
}
