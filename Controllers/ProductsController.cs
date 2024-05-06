

using back.Core.Entities;
using back.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

 
namespace back.Controllers
{
	[ApiController]
	[Route("api/products")]
	public class ProductsController : ControllerBase
	{
		private readonly IProductRepository repo;
		private readonly IProductBrandRepository brand;
		private readonly IProductTypeRepository type;
		public ProductsController(IProductRepository repo, IProductBrandRepository brand, IProductTypeRepository type)
		{
			this.repo = repo;
			this.brand = brand;
			this.type = type;
		}
		[HttpGet]
		
		public async Task<ActionResult<IReadOnlyList<Product>>> GetProducts()
		{
			var products = await repo.GetProductsAsync();	
			return Ok(products);
		}
		
		[HttpGet("id:int")]
		public async Task<ActionResult<Product>> GetProduct(int id)
		{ 
			var product = await repo.GetProductByIdAsync(id);
			return Ok(product);
		}
		
		[HttpGet("brands")]
		public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
		{
			var brands = await brand.GetProductBrandsAsync();
			return Ok(brands);
		}
		
		[HttpGet("types")]
		public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
		{
			var types = await type.GetProductTypesAsync();
			return Ok(types);
		}
	}
}