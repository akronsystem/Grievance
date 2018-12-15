using Griveance.BusinessLayer;
using Griveance.Models;
using Griveance.ParamModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Griveance.Controllers
{
    public class RegisterController : ApiController
    {
        [HttpPost]
        public object SaveRegistration([FromBody] ParamRegistration PR)
        {
            try
            {
                SaveRegistrationBL OBJSAVE = new SaveRegistrationBL();
                var result = OBJSAVE.SaveRegistration(PR);
                return result;
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };

            }

        }
    }
}
