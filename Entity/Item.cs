using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridge.Entity
{
	[Table("Item", Schema = "dbo")]
	public class Item
	{
		[Key]
		public int ID { get; set; }

		[Required]

		public string Name { get; set; }

		public string Description { get; set; }

		public string Price { get; set; }

		[ForeignKey("UserId")]
		public User User { get; set; }
	}
}
