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
                var usercode = db.tbl_user.Where(r => r.code == PR.code).FirstOrDefault();
                if (usercode != null)
                {
                    return new Error() { IsError = true, Message = "User Code Already Exists." };
                }
                tbl_user objuser = new tbl_user();
              
                objuser.name = PR.Name;
                objuser.UserId = PR.UserId;
                objuser.type = PR.Type;
                objuser.gender = PR.Gender;
                objuser.code = PR.code;
                objuser.email = PR.Email;
                objuser.contact = PR.Contact;
                string EncryptedPassword = CryptIt.Encrypt(PR.Password);
                objuser.password = EncryptedPassword;
                objuser.status = 1;
                objuser.Islive = 1;
                objuser.Display = 1;
                objuser.created_date = DateTime.Now;
                db.tbl_user.Add(objuser);
                db.SaveChanges();

                if (PR.Type == "Student")
                {
                    tbl_student objstudent = new tbl_student();
                    objstudent.UserId = PR.UserId;
                    tbl_user obstudent = db.tbl_user.Where(r => r.code == PR.code).FirstOrDefault();
                    objstudent.UserId = obstudent.UserId;
                    objstudent.code = PR.code;
                    objstudent.course_name = PR.CourseName;
                    objstudent.class_name = PR.ClassName;
                    objstudent.IsParent = 0;
                    objstudent.Display = 1;
                    objstudent.created_date = DateTime.Now;
                    db.tbl_student.Add(objstudent);
                    db.SaveChanges();
                }
                else if (PR.Type == "Faculty")
                {
                    tbl_faculty objfaculty = new tbl_faculty();
                    objfaculty.UserId = PR.UserId;
                    tbl_user obfaculty = db.tbl_user.Where(r => r.code == PR.code).FirstOrDefault();
                    objfaculty.UserId = obfaculty.UserId;
                    objfaculty.code = PR.code;
                    objfaculty.department = PR.CourseName;
                    objfaculty.designation = PR.Designation;
                    objfaculty.Display = 1;
                    objfaculty.created_date = DateTime.Now;
                    db.tbl_faculty.Add(objfaculty);
                    db.SaveChanges();
                }
                else if (PR.Type == "Parent")
                {
                    tbl_parent objparent = new tbl_parent();
                    objparent.UserId = PR.UserId;
                    objparent.relationship = PR.Relationship;
                    tbl_user obstudent = db.tbl_user.Where(r => r.code == PR.code).FirstOrDefault();
                    objparent.UserId = obstudent.UserId;
                    objparent.code = PR.code;
                    objparent.Display = 1;
                    objparent.created_date = DateTime.Now;
                    db.tbl_parent.Add(objparent);
                    db.SaveChanges(); 
                    //tbl_student objstudent = db.tbl_student.Where(r => r.UserId == PR.UserId).FirstOrDefault();
                    //objstudent.IsParent = 1;
                    //db.SaveChanges(); 
                }
                else if (PR.Type == "Staff")
                {
                    tbl_staff objstaff = new tbl_staff();
                    objstaff.UserId = objuser.UserId;
                    tbl_user obstaff = db.tbl_user.Where(r => r.code == PR.code).FirstOrDefault();
                    objstaff.UserId = objstaff.UserId;
                    objstaff.code = PR.code;
                    objstaff.department = PR.CourseName;
                    objstaff.designation = PR.Designation;
                    objstaff.Display = 1;
                    objstaff.created_date = DateTime.Now;
                    db.tbl_staff.Add(objstaff);
                    db.SaveChanges();
                }
                else
                {
                    return new Error() { IsError = true, Message = "User Type Not Matched." };
                }
                return new Result() { IsSucess = true, ResultData = "User Saved Successfully." };


            }
            catch (Exception ex)
            {
                return new Error() { IsError = true, Message = ex.Message };
            }
        }

        public object UpdateParent(ParamRegistration PR)
        {

            try
            {
                tbl_user objuser = db.tbl_user.Where(r => r.UserId == PR.UserId).FirstOrDefault();


                objuser.name = PR.Name;
            
                objuser.gender = PR.Gender;
                objuser.email = PR.Email;
                objuser.contact = PR.Contact;
                objuser.modified_date = DateTime.Now;
               
                objuser.status = 1;
                objuser.Islive = 1;
               
                db.SaveChanges();

                if (PR.Type == "Parent")
                {
                    tbl_parent objparent = db.tbl_parent.Where(r => r.UserId == PR.UserId).FirstOrDefault();
                   // objparent.UserId = PR.UserId;
                    objparent.relationship = PR.Relationship;
                    objparent.modified_date = DateTime.Now;
                    db.SaveChanges();

                   
                }

                return new Result() { IsSucess = true, ResultData = "User Updated Successfully." };
            }
            catch (Exception ex)
            {
                return new Error() { IsError = true, Message = ex.Message };
            }
        }
        public object DeleteParent(ParamRegistration PR)
        {
            try
            {
                tbl_user objuser = db.tbl_user.Where(r => r.UserId == PR.UserId).FirstOrDefault();


                if (objuser.Display == 1)
                {
                    objuser.Display = 0;
                }
                else
                {
                    objuser.Display = 1;
                }


                db.SaveChanges();

                if (PR.Type == "Parent")
                {
                    tbl_parent objparent = db.tbl_parent.Where(r => r.UserId == PR.UserId).FirstOrDefault();
                    // objparent.UserId = PR.UserId;
                   if(objparent.Display==1)
                    {
                        objparent.Display = 0;
                    }
                   else
                    {
                        objparent.Display = 1;
                    }
                    db.SaveChanges();


                }

                return new Result() { IsSucess = true, ResultData = "User Updated Successfully." };
            }
            catch (Exception ex)
            {
                return new Error() { IsError = true, Message = ex.Message };
            }
        }

        public object UpdateFaculty(ParamRegistration PR)
        {

            try
            {
                tbl_user objuser = db.tbl_user.Where(r => r.UserId == PR.UserId).FirstOrDefault();


                objuser.name = PR.Name;

                objuser.gender = PR.Gender;
                objuser.email = PR.Email;
                objuser.contact = PR.Contact;
                objuser.modified_date = DateTime.Now;
                objuser.status = 1;
                objuser.Islive = 1;

                db.SaveChanges();

                if (PR.Type == "Faculty")
                {
                    tbl_faculty objfaculty = db.tbl_faculty.Where(r => r.UserId == PR.UserId).FirstOrDefault();
                    // objparent.UserId = PR.UserId;
                    objfaculty.department = PR.Department;
                    objfaculty.designation = PR.Designation;
                    objfaculty.modified_date = DateTime.Now; 
                    db.SaveChanges();


                }

                return new Result() { IsSucess = true, ResultData = "User Updated Successfully." };
            }
            catch (Exception ex)
            {
                return new Error() { IsError = true, Message = ex.Message };
            }
        }

        public object DeleteFaculty(ParamRegistration PR)
        {

            try
            {
                tbl_user objuser = db.tbl_user.Where(r => r.UserId == PR.UserId).FirstOrDefault();


                if (objuser.Display == 1)
                {
                    objuser.Display = 0;
                }
                else
                {
                    objuser.Display = 1;
                }
                db.SaveChanges();

                

                if (PR.Type == "Faculty")
                {
                    tbl_faculty objfaculty = db.tbl_faculty.Where(r => r.UserId == PR.UserId).FirstOrDefault();
                    // objparent.UserId = PR.UserId;
                    if (objfaculty.Display == 1)
                    {
                        objfaculty.Display = 0;
                    }
                    else
                    {
                        objfaculty.Display = 1;
                    }
                    db.SaveChanges();


                }

                return new Result() { IsSucess = true, ResultData = "User Updated Successfully." };
            }
            catch (Exception ex)
            {
                return new Error() { IsError = true, Message = ex.Message };
            }
        }
        public object UpdateStudent(ParamRegistration PR)
        {
            try
            {
                tbl_user objuser = db.tbl_user.Where(r => r.UserId == PR.UserId).FirstOrDefault();
              

                objuser.name = PR.Name;
               
                objuser.type = PR.Type;
                objuser.gender = PR.Gender;
                objuser.email = PR.Email;
                objuser.contact = PR.Contact;
               objuser.modified_date = DateTime.Now;
                objuser.status = 1;
                objuser.Islive = 1;
              
                db.SaveChanges();

                if (PR.Type == "Student")
                {
                    tbl_student objstudent = db.tbl_student.Where(r => r.UserId == PR.UserId).FirstOrDefault();
                 
                    objstudent.IsParent = 0;
                    objstudent.modified_date = DateTime.Now;
                    db.SaveChanges();
                }

                return new Result() { IsSucess = true, ResultData = "User Saved Successfully." };
            }
            catch (Exception ex)
            {
                return new Error() { IsError = true, Message = ex.Message };
            }
        }
        public object UpdateStaff(ParamRegistration PR)
        {
            try
            {
                tbl_user objuser = db.tbl_user.Where(r => r.UserId == PR.UserId).FirstOrDefault();


                objuser.name = PR.Name;

                objuser.type = PR.Type;
                objuser.gender = PR.Gender;
                objuser.email = PR.Email;
                objuser.contact = PR.Contact;
                objuser.modified_date = DateTime.Now;
                objuser.status = 1;
                objuser.Islive = 1;

                db.SaveChanges();

                if (PR.Type == "Staff")
                {
                    tbl_staff objstaff = db.tbl_staff.Where(r => r.UserId == PR.UserId).FirstOrDefault();

                    objstaff.department = PR.Department;
                    objstaff.designation = PR.Designation;
                    objstaff.modified_date = DateTime.Now;
                    db.SaveChanges();
                }

                return new Result() { IsSucess = true, ResultData = "User Saved Successfully." };
            }
            catch (Exception ex)
            {
                return new Error() { IsError = true, Message = ex.Message };
            }
        }
        public object DeleteStaff(ParamRegistration PR)
        {
            try
            {
                tbl_user objuser = db.tbl_user.Where(r => r.UserId == PR.UserId).FirstOrDefault();


                if (objuser.Display == 1)
                {
                    objuser.Display = 0;
                }
                else
                {
                    objuser.Display = 1;
                }

                db.SaveChanges();

                if (PR.Type == "Staff")
                {
                    tbl_staff objstaff = db.tbl_staff.Where(r => r.UserId == PR.UserId).FirstOrDefault();

                    if (objstaff.Display == 1)
                    {
                        objstaff.Display = 0;
                    }
                    else
                    {
                        objstaff.Display = 1;
                    }

                    db.SaveChanges();
                }

                return new Result() { IsSucess = true, ResultData = "User Deleted Successfully." };
            }
            catch (Exception ex)
            {
                return new Error() { IsError = true, Message = ex.Message };
            }
        }
        public object DeleteSingleStudent(ParamRegistration PR)
        {
            try
            {
                tbl_user objuser = db.tbl_user.Where(r => r.UserId == PR.UserId).FirstOrDefault();

                if (objuser.Display == 1)
                {
                    objuser.Display = 0;
                }
                else
                {
                    objuser.Display = 1;
                }

             

                db.SaveChanges();

                if (PR.Type == "Student")
                {
                    tbl_student objstudent = db.tbl_student.Where(r => r.UserId == PR.UserId).FirstOrDefault();
                    if (objstudent.Display == 1)
                    {
                        objstudent.Display = 0;
                    }
                    else
                    {
                        objstudent.Display = 1;
                    }

                    db.SaveChanges();
                }

                return new Result() { IsSucess = true, ResultData = "User Deleted Successfully." };
            }
            catch (Exception ex)
            {
                return new Error() { IsError = true, Message = ex.Message };
            }
        }
    }
}