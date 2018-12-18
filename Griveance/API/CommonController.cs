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
             SetIsLiveForUser obj = new SetIsLiveForUser();
            var homemworkresult = obj.UserLive(objhome);
            return homemworkresult; 
        }
        [HttpPost]
        public object GetMyGrievance([FromBody]ParamGetMyGrievance objmy)
        {
            GetMyGrievanceBL obj = new GetMyGrievanceBL();
            var mygrievance = obj.GetMyGrievance(objmy);
            return mygrievance;
        }

        public object SubmitGrievance([FromBody]ParamSaveGriveance objparam)
        {
            PostGriveance obj = new PostGriveance();
            var result = obj.SaveGrievance(objparam);
            return result; 
         }
    }
}
