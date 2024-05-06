

using back.Core.Entities;
using back.Infrastructure.context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace back.Controllers
{
	[ApiController]
	[Route("api/products")]
	public class ProductsController : ControllerBase
	{
		private readonly StoreContext context;
		public ProductsController(StoreContext context)
		{
			this.context = context;
		}
		[HttpGet]
		
		public async Task<ActionResult<List<Product>>> GetProducts()
		{
			var products = await context.Products.ToListAsync();	
			return products;
		}
		
		[HttpGet("id:int")]
		public async Task<ActionResult<Product>> GetProduct(int id)
		{
			var product = await context.Products.FindAsync(id);
			return product;
		}
	}
}