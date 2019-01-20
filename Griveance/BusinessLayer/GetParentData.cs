using Griveance.Models;
using Griveance.ResultModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Griveance.BusinessLayer
{
    public class GetParentData
    {
        GRContext objcontext = new GRContext();
        public object GetParentList( string status)
        {
            try
            {
                List<Griveance.Models.ViewGetSingleParentInfo> GetParent = null;


                if (status=="Deactive")
                {
                    GetParent = objcontext.ViewGetSingleParentInfoes.Where(r => r.Display != 1).ToList();
                }
                else

                {
                    GetParent = objcontext.ViewGetSingleParentInfoes.Where(r => r.Display == 1).ToList();
                   
                }
               
                if (GetParent == null)
                {
                    return new Error { IsError = true, Message = "Parent List Not Found." };
                }
                else
                {
                    return new Result { IsSucess = true, ResultData = GetParent };
                }
               

            }
            catch (Exception ex)
            {
                return new Error() { IsError = true, Message = ex.Message };
            }
        }
    }
}