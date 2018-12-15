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

        [HttpGet]
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
    }
}
