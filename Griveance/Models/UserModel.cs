using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Griveance.Models
{
	using System.ComponentModel.DataAnnotations;

	public class UserCredentialModel
	{
		[Required]
		public string UserName { get; set; }
		[Required]
		public string Password { get; set; } 
        public string Type { get; set; }

		 
	}
}