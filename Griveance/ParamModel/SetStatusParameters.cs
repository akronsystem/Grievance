using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Griveance.Models
{
    public class SetStatusParameters
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public int CompId { get; set; }
        public string GrievanceAction { get; set; }
        public string Status { get; set; }
    }
}