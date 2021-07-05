using ShopBridge.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridge.Repository
{
	public interface IProductRepository<T>
	{
		public Task<IEnumerable<T>> GetAllItem(int userId);

	public 	Task<bool> UpdateItem(int userID,T itemID);
	public	Task<bool> AddItem(int userID,T item);

	public	Task<bool> DeleteItem(int userID,int itemID);

  public Task<UserContext> GetUsrDetailsByUserName(string userName);
	}
}
