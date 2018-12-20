using Griveance.Models;
using Griveance.ParamModel;
using Griveance.ResultModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Griveance.BusinessLayer
{
    public class SaveRegistrationBL
    {
        GRContext db = new GRContext();
        public object SaveRegistration(ParamRegistration PR)
        {
            try
            {
                var usercode = db.tbl_user.Where(r => r.code == PR.Code).FirstOrDefault();
                if (usercode !=null)
                {
                    return new Error() { IsError = true, Message = "User Code Already Exists." };
                }
                    tbl_user objuser = new tbl_user();
                    objuser.name = PR.Name;
                    objuser.code = PR.Code;
                    objuser.type = PR.Type;
                    objuser.gender = PR.Gender;
                    objuser.email = PR.Email;
                    objuser.contact = PR.Contact;
                    string EncryptedPassword = CryptIt.Encrypt(PR.Password);
                    objuser.password = EncryptedPassword;
                    objuser.status = 1;
                    objuser.Islive = 1;
                    db.tbl_user.Add(objuser);
                    db.SaveChanges();

                    if (PR.Type == "Student")
                    {
                        tbl_student objstudent = new tbl_student();
                        objstudent.code = PR.Code;
                        objstudent.course_name = PR.CourseName;
                        objstudent.class_name = PR.ClassName;
                        objstudent.IsParent = 0;
                        db.tbl_student.Add(objstudent);
                        db.SaveChanges();
                    }
                    else if (PR.Type == "Faculty")
                    {
                        tbl_faculty objfaculty = new tbl_faculty();
                        objfaculty.code = PR.Code;
                        objfaculty.department = PR.Department;
                        objfaculty.designation = PR.Designation;
                        db.tbl_faculty.Add(objfaculty);
                        db.SaveChanges();
                    }
                    else if (PR.Type == "Parent")
                    {
                        tbl_parent objparent = new tbl_parent();
                        objparent.code = PR.Code;
                        objparent.relationship = PR.Relationship;
                        db.tbl_parent.Add(objparent);
                        db.SaveChanges();

                        tbl_student objstudent = db.tbl_student.Where(r => r.code == PR.Code).FirstOrDefault();
                        objstudent.IsParent = 1;
                        db.SaveChanges();
                    }
                    else if (PR.Type == "Staff")
                    {
                        tbl_staff objstaff = new tbl_staff();
                        objstaff.code = PR.Code;
                        objstaff.department = PR.Department;
                        objstaff.designation = PR.Designation;
                        db.tbl_staff.Add(objstaff);
                        db.SaveChanges();
                    }
                    else
                    {
                        return new Error() { IsError = true, Message = "User Type Not Matched." };
                    }
                    return new Result() { IsSucess = true, ResultData = "User Saved Successfully." };
               

            }
            catch(Exception ex)
            {
                return new Error() { IsError = true, Message = ex.Message };
            }
        }
    }
}