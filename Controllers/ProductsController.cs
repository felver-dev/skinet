
using AutoMapper;
using back.Core.Entities;
using back.Core.Interfaces;
using back.Core.Specifications;
using back.DTO;
using Microsoft.AspNetCore.Mvc;


namespace back.Controllers
{
	[ApiController]
	[Route("api/products")]
	public class ProductsController : ControllerBase
	{

		private readonly IGenericRepository<Product> product;
		private readonly IGenericRepository<ProductBrand> brand;
		private readonly IGenericRepository<ProductType> type;
		private readonly IMapper mapper;
		public ProductsController(IGenericRepository<Product> product, IGenericRepository<ProductBrand> brand, IGenericRepository<ProductType> type, IMapper mapper)
		{
			this.product = product;
			this.brand = brand;
			this.type = type;
			this.mapper = mapper;
		}
		
		[HttpGet]
		public async Task<ActionResult<IReadOnlyList<ProductToReturnDto>>> GetProducts()
		{
			var spec = new ProductWithTypesAndBrandsSpec();
			var products = await product.ListAsync(spec);	
			return Ok(mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDto>>(products));
		}
		
		[HttpGet("{id:int}")]
		public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
		{
			var spec = new ProductWithTypesAndBrandsSpec(id);
			var pdt = await product.GetEntityWithSpec(spec);
			return Ok(mapper.Map<ProductToReturnDto>(pdt));
		}
		
		[HttpGet("brands")]
		public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
		{
			var brands = await brand.ListAllAsync();
			return Ok(brands);
		}
		
		[HttpGet("types")]
		public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
		{
			var types = await type.ListAllAsync();
			return Ok(types);
		}
	}
}