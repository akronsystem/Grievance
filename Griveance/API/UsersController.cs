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

namespace Griveance.Controllers
{
    public class UsersController : ApiController
 
    {
         [HttpPost]
        public object GetSingleParentInfo([FromBody]ParamUser code)
        {
            UsersBusiness UbObj = new UsersBusiness();
            var parent = UbObj.GetSingleParentInfo(code);
            return parent;
        }
         [HttpGet]
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
            GetSingleStudentBL obj = new GetSingleStudentBL();
            var singlestudentresult = obj.GetSingleStudent(objstudent);
            return singlestudentresult;
        }


        [HttpPost]
        public object GetFacultyInfo([FromBody]ParamGetFacultyInfo objfaculty)
        {
            GetFacultyInfoBL obj = new GetFacultyInfoBL();
            var facultyinfo = obj.GetFacultyInfo(objfaculty);
            return facultyinfo;
        } 

        [HttpPost]
        public object GetStudentInfo([FromBody]ParamUserLogin obj)
        {
            GetStudentData objStudent = new GetStudentData();
            var result = objStudent.GetStudentList();
            return result;

        }
        [HttpPost]
        public object GetParentInfo([FromBody]ParamUserLogin obj)
        {
            GetParentData objParent = new GetParentData();
            var result = objParent.GetParentList();
            return result;

        }

        [HttpPost]
        public object GetSingleStaff([FromBody]ParamGetSingleStaffInfo obj)
        {
            GetSingleStaffData objstaff = new GetSingleStaffData();
            var result = objstaff.GetSingleStaffValue(obj);
            return result;

        } 
 
     }
}
