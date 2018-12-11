using Griveance.Models;
using Griveance.ResultModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Griveance.BusinessLayer
{
    public class UsersBusiness
    {
        public object GetSingleParentInfo(ParamUser obj)
        {
            GRContext context = new GRContext();
            try
            {
                var parent = context.ViewGetSingleParentInfoes.Where(r => r.code == obj.Code).FirstOrDefault();
                if (parent == null)
                {
                    return new Result { IsSucess = false, ResultData = "Parent Record Not Found" };
                }
                else
                {
                    return new Result { IsSucess = true, ResultData = parent };
                }
            }
            catch (Exception ex)
            {
                return new Error { IsError = true, Message = ex.Message};
            }
        }
    }
}