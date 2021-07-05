using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShopBridge.Entity;
using ShopBridge.Helper;
using ShopBridge.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridge.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class ProductController : ControllerBase
	{
     private readonly ILogger<ProductController> _logger;
		private readonly IProductRepository<Item> _productManager;

		public ProductController(ILogger<ProductController> logger, IProductRepository<Item> productManager)
		{
			_logger = logger;
			_productManager = productManager;
			
		}

		[HttpPost("AddItem")]
		public async Task<ActionResult<string>> AddItem([FromBody]Request request)
		{
			
			try
			{
				bool isItemAdded = false;
				UserContext userContext = await _productManager.GetUsrDetailsByUserName(request.UserName);
				if (userContext != null)
				{
					Item item = new Item()
					{
						Name = request.Name,
						Description = request.Description,
						Price = request.Price
};
					if (userContext.RoleName.Equals("Admin"))
					{
						isItemAdded = await _productManager.AddItem(userContext.UserId, item);
						if (isItemAdded)
						{
							_logger.LogInformation("item added");
							return Ok("item added successfully");
						}
						else
						{
							_logger.LogInformation("item has not been added");
							return Ok("item has not been added due to some error");
						}
					}
					else
					{
						_logger.LogInformation("permission denied for user" + userContext.UserName + "to add item");
						return Ok("You do not have permission to add an item");

					}
				}
				else
				{
					_logger.LogInformation("user context is not present for user" + userContext.UserName + "to add item");
					return Ok("this user is not present ,please use another user");
				}
				

			}
			catch(Exception ex)
			{
				_logger.LogError("an error occured while adding an item,error details are:" +ex.Message);
				return Ok(ex);
			}
		}

		[HttpPost("UpdateItem")]
		public async Task<ActionResult<string>> UpdateItem([FromBody]Request request)
		{
			
			try
			{
				bool isItemUpdated = false;
				UserContext userContext = await _productManager.GetUsrDetailsByUserName(request.UserName);
				if (userContext != null)
				{
					Item item = new Item()
					{
						Name = request.Name,
						Description = request.Description,
						Price = request.Price,
						ID = request.id
					};
					

					if (userContext.RoleName.Equals("Admin"))
					{
						isItemUpdated = await _productManager.UpdateItem(userContext.UserId, item);
						if (isItemUpdated)
						{
							_logger.LogInformation("item updated");
							return Ok("item updated successfully");
							
						}
						else
						{
							_logger.LogInformation("item has not been updated");
							return Ok("item is not prsent in database to update");
						}
					}
					else
					{
						_logger.LogInformation("permission denied for user" + userContext.UserName + "to update item");
						return Ok("you do not have permission to update item details");
					}
				}
				else
				{
					_logger.LogInformation("user context is not present for user" + userContext.UserName + "to update item");
					return Ok("this user is not present ,please use another user");
				}
			}
			
			catch(Exception ex)
			{
				_logger.LogError("an error occured while updating an item,error details are:" + ex.Message);
				return Ok(ex);
			}
		}

		[HttpGet("DeleteItem")]
		public async Task<ActionResult<string>> DeleteItem(int itemID,string userName)
		{
     try
			{
				bool isItemDeleted = false;
				UserContext userContext = await _productManager.GetUsrDetailsByUserName(userName);

				if (userContext != null)
				{
					if (userContext.RoleName.Equals("Admin"))
					{
						isItemDeleted = await _productManager.DeleteItem(userContext.UserId, itemID);
						if (isItemDeleted)
						{
							_logger.LogInformation("item deleted");
							return Ok("item deleted successfully");

						}
						else
						{
							_logger.LogInformation("item has not been deleted");
							return Ok("item has not been presented in database to delete");
						}
					
					}
					else
					{
						_logger.LogInformation("permission denied for user" + userContext.UserName + "to delete item");
						return Ok("You do not have permission to delete item");
					}
				}
				else
				{
					_logger.LogInformation("user context is not present for user" + userContext.UserName + "to delete item");
					return Ok("this user is not present ,please use another user");
				}
		
			}
			catch (Exception ex)
			{
				_logger.LogError("an error occured while deleting an item,error details are:" + ex.Message);
				return Ok(ex);
			}
		}

		[HttpGet("GetItem")]
		public async Task<ActionResult<IEnumerable<Item>>> GetItem(string userName)
		{
			
			try
			{
				IEnumerable<Item> products = new List<Item>();
				UserContext userContext =  await _productManager.GetUsrDetailsByUserName(userName);
				if (userContext != null)
				{
					if (userContext.RoleName.Equals("Admin"))
					{
						products = await _productManager.GetAllItem(userContext.UserId);
						return Ok(products);
					}
					else
					{
						_logger.LogInformation("permission denied for user" + userContext.UserName + "to get items");
						return Ok("You do not have permission to get item details");
					}
				}
				else
				{
					_logger.LogInformation("user context is not present for user" + userContext.UserName + "to get items");
					return Ok("this user is not present ,please use another user");
				}
				
			}
			catch (Exception ex)
			{
				_logger.LogError("an error occured while getting items,error details are:" + ex.Message);
				return Ok(ex);
			}
		}
	}
}

