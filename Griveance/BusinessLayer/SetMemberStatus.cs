using Griveance.Models;
using Griveance.ParamModel;
using Griveance.ResultModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Griveance.BusinessLayer
{
    public class SetMemberStatus
    {
        GRContext gc = new GRContext();
        public object SetIsLiveStatusMember(ParamMember PM)
        {
            try
            {
                tbl_user objTBLUSER = gc.tbl_user.Where(r => r.UserId == PM.UserId && r.type == "Member").FirstOrDefault();

                if (objTBLUSER == null)
                { 
             
                    return new Error() { IsError = true, Message = "Incorrect Code !" };
                   

                }
                else
                {
                    if (objTBLUSER.Islive==1)
                    {
                       
                        objTBLUSER.Islive = 0;
                        
                        
                    }
                    else
                    {
                        objTBLUSER.Islive = 1;
                    }
                    //objTBLUSER.code = PM.Code;
                    gc.SaveChanges();
                    return new Result() { IsSucess = true, ResultData = "Status Updated Sucessfully!" };
                }
            }
            catch(Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }
        }
    }
}