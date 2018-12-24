using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Griveance.Models
{
    public class CheckUsernamePassword
    {
        public bool ValidateUsernamePassword(Int32 USERID, string PASSWORD)
        {
            //SchoolMainContext objSC = new ConcreateContext().GetContext(USERID, PASSWORD);
            GRContext db = new GRContext();
            string pwd = CryptIt.Encrypt(PASSWORD);

            var usernamepwd = db.ViewUsers.Where(r => r.UserId == USERID && r.password == pwd && r.Islive == 1).ToList();
            if (usernamepwd.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}