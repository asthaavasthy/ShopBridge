using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity.Core;
using Microsoft.EntityFrameworkCore.SqlServer;
using ShopBridge.Helper;

namespace ShopBridge.Entity
{
	public class ProductContext : DbContext
	{
		public ProductContext(DbContextOptions<ProductContext> options) : base(options)
		{
			Database.Migrate();
		}
		public DbSet<Item> Items { get; set; }
		public DbSet<User> Users { get; set; }

		public DbSet<Role> Roles { get; set; }

		public DbSet<UserContext> UserContext { get; set; }

		public async Task<int> ExecuteNonQueryAsync<T>(string rawSql, params object[] parameters)
		{
			var conn = Database.GetDbConnection();
			using (var command = conn.CreateCommand())
			{
				command.CommandText = rawSql;
				if (parameters != null)
					foreach (var p in parameters)
						command.Parameters.Add(p);
				await conn.OpenAsync();
				return (int)await command.ExecuteNonQueryAsync();
			}
		}
	}
}
