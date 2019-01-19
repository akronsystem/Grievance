using Griveance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Griveance.ResultModel;


namespace Griveance.BusinessLayer
{
    public class GetStudentData
    {

        GRContext objcontext = new GRContext();
        public object GetStudentList(string status)
        {
            try
            {
                List<Griveance.Models.ViewGetStudentInfo> StudentData = null;
                if(status=="Deactive" )
                {
                    StudentData = objcontext.ViewGetStudentInfoes.Where(r => r.Display == 0).ToList();
                   
                   
                }
                else
                {

                    StudentData = objcontext.ViewGetStudentInfoes.Where(r => r.Display == 1).ToList();
                }
               
                if (StudentData == null)
                {
                    return new Error { IsError = true, Message = "Student List Not Found." };
                }
                else
                {
                    return new Result { IsSucess = true, ResultData = StudentData };
                }
            }
            catch (Exception ex)
            {
                return new Error() { IsError = true, Message = ex.Message };
            }
        }
    }
}