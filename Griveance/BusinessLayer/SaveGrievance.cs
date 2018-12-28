﻿using Griveance.Models;
using Griveance.ParamModel;
using Griveance.ResultModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Griveance.BusinessLayer
{
    public class SaveGrievance
    {
        GRContext db = new GRContext();
        public object GrievanceSave(GrievanceParam PR)
        {
            try
            {
                //var usercode = db.tbl_user.Where(r => r.code == PR.Code).FirstOrDefault();
                //if (usercode != null)
                //{
                //    return new Error() { IsError = true, Message = "User Code Already Exists." };
                //}
                tbl_grievance_list objuser = new tbl_grievance_list();

                objuser.grivance_name = PR.GrievanceName;
                objuser.grivance_description = PR.GrievanceDescription;             
                objuser.Isalloted = 0;
                db.tbl_grievance_list.Add(objuser);
                db.SaveChanges();

               
                return new Result() { IsSucess = true, ResultData = "User Saved Successfully." };


            }
            catch (Exception ex)
            {
                return new Error() { IsError = true, Message = ex.Message };
            }
        }
        public object UpdateGrievance(GrievanceParam PR)
        {
            try
            {
                tbl_grievance_list obGR = db.tbl_grievance_list.Where(r => r.grivance_id == PR.GrievanceId).FirstOrDefault();

                obGR.grivance_name = PR.GrievanceName;
                obGR.grivance_description = PR.GrievanceDescription;              
                obGR.Isalloted = 0;
               
                //db.tbl_user.Add(objuser);
                db.SaveChanges();               

                return new Result() { IsSucess = true, ResultData = "Grievance Update Successfully." };
            }
            catch (Exception ex)
            {
                return new Error() { IsError = true, Message = ex.Message };
            }
        }
        public object GetGrievanceData(GrievanceParam obj)
        {
            var GrievanceData = db.tbl_grievance_list.Where(r => r.grivance_id == obj.GrievanceId).SingleOrDefault();
            return GrievanceData;
        }
    }
}