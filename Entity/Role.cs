using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridge.Entity
{
	public class Role
	{
		[Key]
		public int RoleId { get; set; }

		[Required]
		[MaxLength(50)]
		public string RoleName { get; set; }

		
}
}
