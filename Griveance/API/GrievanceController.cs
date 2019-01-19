using Griveance.Models;
using Griveance.BusinessLayer; 
using Griveance.ParamModel; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Griveance.Controllers
{

    public class GrievanceController : ApiController
     {
        [HttpPost]
        public object GetUnAssignedGrievanceType()
        {
            try
            {
                GetUnassignedGrievanceType GT = new GetUnassignedGrievanceType();
                var GrType = GT.GetUnassignedGrievance();
                return GrType;
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };

            }

        }


        [HttpPost]
        public object GetAllGrievanceList([FromBody] ParamGetGrievanceList objparam)
        {
            try
            {
                GetGrievanceListBL obj = new GetGrievanceListBL();
                var GetGrievance = obj.GetGrievanceList(objparam);
                return GetGrievance;
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };

            }

        }

        [HttpPost]
        public object GriveanceTypeInfo()
        {
            try
            {
                GetGriveanceInfo GetGriveanceTypeInfo = new GetGriveanceInfo();
                var Result = GetGriveanceTypeInfo.GetGriveanceTypeInfo();

                return Result;
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };

            }

        }
        [HttpPost]
        public object SaveGrievanceType([FromBody] GrievanceParam objparam)
        {
            try
            {
                SaveGrievance savegrieavance = new SaveGrievance();
                var Result = savegrieavance.GrievanceSave(objparam);

                return Result;
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };

            }
        }
        [HttpPost]
        public object UpdateGrievanceType([FromBody] GrievanceParam PR)
        {
            try
            {
                SaveGrievance OBJSAVE = new SaveGrievance();
                var result = OBJSAVE.UpdateGrievance(PR);
                return result;
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };

            }

        }

        [HttpPost]
        public object UpdateGrievanceAllocation([FromBody] GrievanceAllocationParam PR)
        {
            try
            {
                SaveGrievance OBJSAVE = new SaveGrievance();
                var result = OBJSAVE.UpdateGrievanceAllocation(PR);
                return result;
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }
        }

        [HttpPost]
        public object GetSingleGrievanceTypeInfo([FromBody]GrievanceParam objid)
        {
            try
            {
                SaveGrievance obj = new SaveGrievance();
                var EmailList = obj.GetGrievanceData(objid);
                return EmailList;
            }
            catch (Exception ex)
            {
                return new Error() { IsError = true, Message = ex.Message };
            }
        }
        [HttpPost]
        public object GrievanceAllocation([FromBody]ParamGetGrievanceList objid)
        {
            try
            {
                GetGrievanceListBL obj = new GetGrievanceListBL();
                var GRAllocation = obj.GetGrievanceAllocation(objid);
                return GRAllocation;
            }
            catch (Exception ex)
            {
                return new Error() { IsError = true, Message = ex.Message };
            }
        }

        [HttpPost]
        public object GetSingleGrievance([FromBody]ParamGetSingleGrievance OBJGR)
        {
            try
            {
                GetSingleGrievanceBL obj = new GetSingleGrievanceBL();
                var SingleGR = obj.GetSingleGrievance(OBJGR);
                return SingleGR;
            }
            catch (Exception ex)
            {
                return new Error() { IsError = true, Message = ex.Message };
            }
        }
      
        public object PostGrievance([FromBody]ParamSaveGriveance ob)
        {
            try
            {
                PostGriveance obj = new PostGriveance();
                var GRAllocation = obj.SaveGrievance(ob);
                return GRAllocation;
            }
            catch (Exception ex)
            {
                return new Error() { IsError = true, Message = ex.Message };
            }
        }

        [HttpGet]
        public object ShowGraph()
        {
            try
            {
                ShowGraphBL obj = new ShowGraphBL();
                var graph = obj.ShowGraphFunction();
                return graph;
            }
            catch (Exception ex)
            {
                return new Error() { IsError = true, Message = ex.Message };
            }
        }

        [HttpGet]
        public object GetUserList()
        {
            try
            {
                ShowGraphBL obj = new ShowGraphBL();
                var userlist = obj.GetUSersList();
                return userlist;
            }
            catch (Exception ex)
            {
                return new Error() { IsError = true, Message = ex.Message };
            }
        }

        [HttpPost]
        public object UpdateMemberInfo([FromBody]MemberParameter pm)
        {
            try
            {
                MemberBusiness mb = new MemberBusiness();
                var Result = mb.UpdateMemberDetail(pm);

                return Result;
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };

            }

        }
        [HttpPost]
        public object DeleteMemberInfo([FromBody]MemberParameter pm)
        {
            try
            {
                MemberBusiness mb = new MemberBusiness();
                var Result = mb.DeleteMember(pm);

                return Result;
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };

            }

        }
    }
}
