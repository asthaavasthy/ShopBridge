using Dapper;
using Microsoft.EntityFrameworkCore;
using ShopBridge.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.SqlServer;
using ShopBridge.Helper;
using System.Data;

namespace ShopBridge.Repository
{
	public class Product : IProductRepository<Item>
	{
		 ProductContext _db;
	 public Product(ProductContext productContext)
		{
			_db = productContext;
		}
		public async Task<IEnumerable<Item>> GetAllItem(int userId)
		{

			List<Item> list = new List<Item>();
			string sql = "EXEC Product.dbo.GetAllItems @User_ID";
			List<SqlParameter> parms = new List<SqlParameter>
		{
        // Create parameter(s)    
        new SqlParameter { ParameterName = "@User_ID", Value = userId }
		};
			list = await _db.Items.FromSql<Item>(sql, parms.ToArray()).ToListAsync();
			return list;


		}

		public async Task<bool> UpdateItem(int userID,Item item)
		{
			int rowsAffected;

			string sql = "EXEC Product.dbo.pUpdateItem @User_ID,@Item_ID,@Name,@Description,@Price";
			List<SqlParameter> parms = new List<SqlParameter>
		{
        // Create parameter(s)    
        new SqlParameter { ParameterName = "@User_ID", Value = userID },
				new SqlParameter { ParameterName = "@Item_ID", Value = item.ID },
				new SqlParameter { ParameterName = "@Name", Value = item.Name },
				new SqlParameter { ParameterName = "@Description", Value = item.Description },
				new SqlParameter { ParameterName = "@Price", Value = item.Price },

		};
			rowsAffected = await  _db.ExecuteNonQueryAsync<int>(sql, parms.ToArray());
			
			if (rowsAffected > 0)
				return true;
			else
				return false;
		}
		public async Task<bool> AddItem(int userID,Item item)
		{
			int rowsAffected;

			string sql = "EXEC Product.dbo.pAddItem @User_ID,@Name,@Description,@Price";
			List<SqlParameter> parms = new List<SqlParameter>
		{
        // Create parameter(s)    
        new SqlParameter { ParameterName = "@User_ID", Value = userID },
				new SqlParameter { ParameterName = "@Name", Value = item.Name },
				new SqlParameter { ParameterName = "@Description", Value = item.Description },
				new SqlParameter { ParameterName = "@Price", Value = item.Price },
			
		};
			rowsAffected = await _db.ExecuteNonQueryAsync<int>(sql, parms.ToArray());

			if (rowsAffected > 0)
				return await Task.Run(()=>  true);
			else
				return await Task.Run(() => false);

		}

		public async Task<bool> DeleteItem(int userID,int itemID)
		{
			int rowsAffected;
			itemID = 4;
			string sql = "EXEC Product.dbo.pDeleteItem @User_ID , @Item_ID";
			
			List<SqlParameter> parms = new List<SqlParameter>
		{
        // Create parameter(s)    
        new SqlParameter { ParameterName = "@User_ID", Value = userID },
				new SqlParameter { ParameterName = "@Item_ID", Value = itemID }
		};
			rowsAffected = await _db.ExecuteNonQueryAsync<int>(sql, parms.ToArray());

			if (rowsAffected > 0)
				return true;
			else
				return false;
		}

		public async Task<UserContext> GetUsrDetailsByUserName(string userName)
		{
			userName = "aavsthy";
			UserContext user = new UserContext();
			string sql = "EXEC Product.dbo.pGetUserDetailsByUserName @UserName";
			var productCategory = new SqlParameter("UserName", userName);
			var parms = new SqlParameter("@UserName", userName);
		
			user = await Task.Run(() => _db.UserContext.FromSql<UserContext>(sql, parms).FirstOrDefault());
			return user;
		}

	}
}
