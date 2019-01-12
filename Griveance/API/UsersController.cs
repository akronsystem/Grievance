using Griveance.BusinessLayer;
using Griveance.Models;
using Griveance.BusinessLayer;
using Griveance.Models;
using Griveance.ParamModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Griveance.ResultModel;

namespace Griveance.Controllers
{
    public class UsersController : ApiController
 
    { 
         [HttpPost]
 
        public object GetSingleParentInfo([FromBody]ParamUser Obj)
        {
            try
            {
                CheckUsernamePassword chkUserPassword = new CheckUsernamePassword();

                //var chkUser = chkUserPassword.ValidateUsernamePassword(Obj.UserId, Obj.Password);
                //if (chkUser)
                //{
                    UsersBusiness UbObj = new UsersBusiness();
                    var parent = UbObj.GetSingleParentInfo(Obj);
                    return parent;
                //}
                //else
                //{
                //    return new Result { IsSucess = false, ResultData = "Username or Password Is Invalid." };
                //}
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }

        }
        [HttpPost]
        public object GetStaffInfo()
        {
            try
            {
                GetAllStaffInfo obj = new GetAllStaffInfo();
                var StaffInfo = obj.GetStaffInfo();
                return StaffInfo;
            }
            catch (Exception ex)
            {
                return new Error() { IsError = true, Message = ex.Message };
            }
        }


        [HttpPost]
        public object GetSingleStudentInfo([FromBody]ParamGetSingleStudent objstudent)
        {

            try
            {
                CheckUsernamePassword chkUserPassword = new CheckUsernamePassword();

                //var chkUser = chkUserPassword.ValidateUsernamePassword(objstudent.UserId, objstudent.Password);
                //if (chkUser)
                //{
                    GetSingleStudentBL obj = new GetSingleStudentBL();
                    var singlestudentresult = obj.GetSingleStudent(objstudent);
                    return singlestudentresult;
                //}
                //else
                //{
                //    return new Result { IsSucess = false, ResultData = "Username or Password Is Invalid." };
                //}
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };

            }

        }


        [HttpPost]
        public object GetFacultyInfo([FromBody]ParamGetFacultyInfo objfaculty)
        {
            try
            {
                GetFacultyInfoBL obj = new GetFacultyInfoBL();
                var facultyinfo = obj.GetFacultyInfo(objfaculty);
                return facultyinfo;
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };

            }

        }

        [HttpPost]
        public object GetStudentInfo([FromBody]ParamUserLogin obj)
        {
            try
            {
                GetStudentData objStudent = new GetStudentData();
                var result = objStudent.GetStudentList();
                return result;
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };

            }


        }
        [HttpPost]
        public object GetParentInfo([FromBody]ParamUserLogin obj)
        {
            try
            {
                GetParentData objParent = new GetParentData();
                var result = objParent.GetParentList();
                return result;
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };

            }


        }

        [HttpPost]
        public object GetSingleStaff([FromBody]ParamGetSingleStaffInfo obj)
        {
            try
            {
                GetSingleStaffData objstaff = new GetSingleStaffData();
                var result = objstaff.GetSingleStaffValue(obj);
                return result;
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };

            }


        }


        [HttpPost]
        public object GetSingleFaculty([FromBody] FacultyParameters obj)
        {
            try
            {
                GetSingleFaculty ObjFaculty = new GetSingleFaculty();
                var result = ObjFaculty.GetFaculty(obj);
                return result;
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };

            }


        }

    }
}
