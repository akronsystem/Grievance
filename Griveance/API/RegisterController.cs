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



        [HttpPost]
        public object UpdateStudents([FromBody] ParamRegistration PR)
        {
            try
            {
                SaveRegistrationBL OBJSAVE = new SaveRegistrationBL();
                var result = OBJSAVE.UpdateStudent(PR);
                return result;
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };

            }

        }
        [HttpPost]
        public object UpdateParentInfo([FromBody] ParamRegistration PR)
        {
            try
            {
                SaveRegistrationBL OBJSAVE = new SaveRegistrationBL();
                var result = OBJSAVE.UpdateParent(PR);
                return result;
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };

            }

        }
        public object UpdateFacultyInfo([FromBody] ParamRegistration PR)
        {
            try
            {
                SaveRegistrationBL OBJSAVE = new SaveRegistrationBL();
                var result = OBJSAVE.UpdateFaculty(PR);
                return result;
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };

            }

        }
        public object UpdateStaffInfo([FromBody] ParamRegistration PR)
        {
            try
            {
                SaveRegistrationBL OBJSAVE = new SaveRegistrationBL();
                var result = OBJSAVE.UpdateStaff(PR);
                return result;
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };

            }

        }


    }
}
