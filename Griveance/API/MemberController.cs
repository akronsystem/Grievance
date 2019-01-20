 
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
using Griveance.ResultModel;

namespace Griveance.Controllers
{
    public class MemberController : ApiController
    {

        [HttpPost]
        public object GetMemberInfo([FromBody]MemberParameter objmem)
        {
            try
            {
                string status = objmem.DisplayStatus;
                MemberBusiness MBusiness = new MemberBusiness();
                var member = MBusiness.GetMemberInfo(status);
                return member;
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };

            }

        }

        [HttpPost]
        public object GetSingleGrievanace([FromBody]ParamMember obj)
        {
            //get single member info
            try
            {
                CheckUsernamePassword chkUserPassword = new CheckUsernamePassword();

                var chkUser = chkUserPassword.ValidateUsernamePassword(obj.UserId, obj.Password);
                if (chkUser)
                {
                    MemberBusiness MBusiness = new MemberBusiness();
                    var grievance = MBusiness.GetSingleGrievanace(obj);
                    return grievance;
                }
                else
                {
                    return new Result { IsSucess = false, ResultData = "Username or Password Is Invalid." };
                }
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }

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
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }
        }

        [HttpPost]
        public object MemberSave([FromBody]MemberParameter member_para)
        {
            try
            {
                MemberBusiness memberbus = new MemberBusiness();
                var result = memberbus.SaveMember(member_para);
                //  bhobj.StudentsMethod(hobj);

                return result;
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };

            }

        }



        [HttpPost]
        public object GriveanceStatus([FromBody]SetStatusParameters obj)
        {
            try
            {
                SetGriveanceStatus Statusobj = new SetGriveanceStatus();
                var Result = Statusobj.SetStatus(obj);
                return Result;
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };

            }

        }
        [HttpPost]
        public object MemberInfo()
        {
            try
            {
                MemberBusiness member = new MemberBusiness();
                var Result = member.MemberList();

                return Result;
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };

            }

        }
        [HttpPost]
        public object GetMemberGrievance([FromBody]ParamGetMyGrievance objmy)
        {
            
            try
            {
                GetMyGrievanceBL obj = new GetMyGrievanceBL();
                var mygrievance = obj.GetMember(objmy);
                return mygrievance;
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }

        }
        [HttpPost]
        public object GetComplaintInfo([FromBody]ParamComplaintDetails objMember)
        {
            try
            {
                MemberBusiness obj = new MemberBusiness();
                var Memberinfo = obj.GetMemberInfo(objMember);
                return Memberinfo;
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };

            }

        }
        [HttpPost]
        public object UpdateComplaints([FromBody] ParamComplaintDetails PR)
        {
            try
            {
                MemberBusiness OBJSAVE = new MemberBusiness();
                var result = OBJSAVE.UpdateComp(PR);
                return result;
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };

            }

        }
    }
 
}
