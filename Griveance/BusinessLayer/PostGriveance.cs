using Griveance.Models;
using Griveance.ParamModel;
using Griveance.ResultModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Griveance.BusinessLayer
{
    public class PostGriveance
    {
        GRContext objcontext = new GRContext();
        public object SaveGrievance(ParamSaveGriveance obj)
        {

            var Getcode =
               (from a in objcontext.tbl_user
                where a.UserId == obj.UserId && a.password == obj.Password
                select new { a.code }).FirstOrDefault();

            var Getemail =
              (from a in objcontext.tbl_user
               where a.UserId == obj.UserId && a.password == obj.Password
               select new { a.email }).FirstOrDefault();

            tbl_postgriev objpost = new tbl_postgriev();
            if (Getcode==null)
            {
                return new Result { IsSucess = false, ResultData = "Invalid User." };
            }
            else
            {
                objpost.code =Convert.ToInt32(Getcode.code);
                objpost.email = Getemail.email.ToString();
                objpost.grivtype = obj.GriveanceType;
                objpost.subject = obj.Subject;
                objpost.post = obj.PostDetails;
                objpost.status = "Pending";
                objcontext.tbl_postgriev.Add(objpost);
                objcontext.SaveChanges();
                return new Result { IsSucess = true, ResultData = "Griveance Posted Sucessfully." };
            }
           
         
        }
    }
}