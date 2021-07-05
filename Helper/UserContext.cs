using ShopBridge.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridge.Helper
{
	public class UserContext
	{
		[Required]
		[Key]
		public int UserId { get; set; }

		[Required]
		[MaxLength(50)]
		public string UserName { get; set; }

		[Required]

		
		public int RoleId { get; set; }

		[Required]

	
		public string RoleName { get; set; }
	
	}


}
