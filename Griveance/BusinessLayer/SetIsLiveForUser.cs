using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Griveance.Models;
using System.Web.Http;
using Griveance.ResultModel;
using System.Data.Entity.Validation;
using Griveance.ParamModel;
namespace Griveance.BusinessLayer
{
    public class SetIsLiveForUser
    {
        GRContext db = new GRContext();
        public object UserLive(StudentParameters obj)
        {
            try
            {


                // var status = db.tbl_user.Where(r => r.code == obj.code && r.type == obj.type).OrderByDescending(r => r.code).ToList(); 


                tbl_user uobj = db.tbl_user.First(r => r.code == obj.Code && r.type == obj.Type);

                if (uobj.Islive == 0)
                {
                    uobj.Islive = 1;

                }
                else
                {
                    uobj.Islive = 0;
                }


                uobj.code = obj.Code;
                db.SaveChanges();
                return new Result
                {

                    IsSucess = true,
                    ResultData = "Status Updated!"
                };

            }
            catch (Exception E)
            {
                return new Error() { IsError = true, Message = E.Message };

            }
            
        }
    }
}