using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Griveance.ParamModel
{
    public class ParamComplaintDetails
    {
       
        public int CompID { get; set; }

      
        public string GrievanceType { get; set; }

       
        public DateTime Date { get; set; }

      
        public string Subject { get; set; }

     
        public string Post { get; set; }

       
        public string GrievanceAction { get; set; }

       
        public string status { get; set; }

        public int GrievMemID { get; set; }

        
        public string StackholderID { get; set; }

       
        public string StackHolderType { get; set; }

        public int Display { get; set; }

        public DateTime created_date { get; set; }

        public DateTime modified_date { get; set; }

        public int UserId { get; set; }
    }
}