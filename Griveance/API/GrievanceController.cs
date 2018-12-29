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
        [HttpGet]
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
        public object SaveGrievance([FromBody] GrievanceParam objparam)
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
        public object UpdateGrievance([FromBody] GrievanceParam PR)
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
        public object GetSingleGrievanceInfo([FromBody]GrievanceParam objid)
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
    }
}
