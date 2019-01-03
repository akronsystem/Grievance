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
            if (obj.UserId == null)
            {
                return new Result { IsSucess = false, ResultData = "Invalid User." };
            }
            int grievancetypeid = Convert.ToInt32(obj.GriveanceType);
           
            var grievancetypelist = objcontext.tbl_grievance_list.Where(r => r.grivance_id == grievancetypeid).First();
            tbl_postgriev objpost = new tbl_postgriev();
            if (obj.Code==null)
            {
                return new Result { IsSucess = false, ResultData = "Invalid User." };
            }
            else
            {
                objpost.code = obj.Code;
                objpost.email = obj.Email;
                objpost.grivtype = grievancetypelist.grivance_name;
                objpost.subject = obj.Subject;
                objpost.post = obj.PostDetails;
                objpost.status = "Pending";
                objcontext.tbl_postgriev.Add(objpost);
                //objcontext.SaveChanges();


                tbl_complaintdetails comp = new tbl_complaintdetails();
                comp.GrievanceType = grievancetypelist.grivance_name;
                comp.Date =DateTime.Now.Date;
                comp.Subject = objpost.subject;
                comp.Post = objpost.post;
                comp.status = objpost.status; 
                comp.GrievanceAction = "Pending";
                comp.GrievMemID = grievancetypeid;
                comp.StackHolderType = obj.Type;
                comp.StackholderID =Convert.ToString(objpost.code);
                objcontext.tbl_complaintdetails.Add(comp);
                objcontext.SaveChanges();


                return new Result { IsSucess = true, ResultData = "Griveance Posted Sucessfully." };
            }
           
         
        }
    }
}