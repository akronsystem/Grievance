using Griveance.BusinessLayer;
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
    public class CommonController : ApiController
    { 
        public object SetLiveUser([FromBody]StudentParameters objhome)
        {
            try
            {
                SetIsLiveForUser obj = new SetIsLiveForUser();
                var homemworkresult = obj.UserLive(objhome);
                return homemworkresult;
            }
            catch(Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };

            }

        }
        [HttpPost]
        public object GetMyGrievance([FromBody]ParamGetMyGrievance objmy)
        {
            try
            {
                GetMyGrievanceBL obj = new GetMyGrievanceBL();
                var mygrievance = obj.GetMyGrievance(objmy);
                return mygrievance;
            }
            catch(Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }
          
        }

        public object SumbitGrievance([FromBody]ParamSaveGriveance objparam)
        {
            try
            {
                PostGriveance obj = new PostGriveance();
                var result = obj.SaveGrievance(objparam);
                return result;
            }
            catch(Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }
           
         }
    }
}
