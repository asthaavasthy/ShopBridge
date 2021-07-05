using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridge.Entity
{
	public class ProductDbContextFactory : IDesignTimeDbContextFactory<ProductContext>
	{
		public ProductContext CreateDbContext(string[] args)
		{
			var optionsBuilder = new DbContextOptionsBuilder<ProductContext>();
			optionsBuilder.UseSqlServer("server=IXC1-LT324W3X2; database = Product; persist security info = True; Integrated Security = SSPI;");
			return new ProductContext(optionsBuilder.Options);
		}
	}
}
