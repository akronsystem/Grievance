 
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
using Griveance.Models;
using Griveance.BusinessLayer;

namespace Griveance.Controllers
{
    public class MemberController : ApiController
    {
 
        [HttpGet]
        public object GetMemberInfo()
        {
            MemberBusiness MBusiness = new MemberBusiness();
            var member = MBusiness.GetMemberInfo();
            return member;
        }

        [HttpPost]
        public object GetSingleGrievanace([FromBody]ParamMember obj)
        {
            MemberBusiness MBusiness = new MemberBusiness();
            var grievance = MBusiness.GetSingleGrievanace(obj);
            return grievance;
        }
    
         [HttpPost]
        public object SetIsLiveForMember([FromBody]ParamMember PM)
        {
            try
            {
                SetMemberStatus SM = new SetMemberStatus();
                var Status = SM.SetIsLiveStatusMember(PM);
                return Status;

            }
            catch(Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }
        }
   
        [HttpPost]
        public object MemberSave([FromBody]Member_parameter member_para)
        {

            MemberBusiness memberbus = new MemberBusiness();
            var result = memberbus.SaveMember(member_para);
            //  bhobj.StudentsMethod(hobj);

            return result;
        }


 
      [HttpPost]
        public object GriveanceStatus([FromBody]SetStatusParameters obj)
        {
            SetGriveanceStatus Statusobj = new SetGriveanceStatus();
             var Result = Statusobj.SetStatus(obj);
            return Result;
         }
     }
 
}
