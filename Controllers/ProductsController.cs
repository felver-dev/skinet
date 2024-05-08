
using AutoMapper;
using back.Core.Entities;
using back.Core.Interfaces;
using back.Core.Specifications;
using back.DTO;
using back.Errors;
using back.Helpers;
using Microsoft.AspNetCore.Mvc;


namespace back.Controllers 
{
	public class ProductsController : BaseApiController
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
		public async Task<ActionResult<Pagination<ProductToReturnDto>>> GetProducts([FromQuery]ProductSpecParams productParams)
		{
			var spec = new ProductWithTypesAndBrandsSpec(productParams);
			var countSpec = new ProductWithFiltersForCountSpec(productParams);
			
			var totalItems = await product.CountAsync(countSpec);
			
			var products = await product.ListAsync(spec);

			var data = mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDto>>(products);
			return Ok(new Pagination<ProductToReturnDto>(productParams.PageIndex, productParams.PageSize, totalItems, data));
		}
		
		[HttpGet("{id:int}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
		public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
		{
			var spec = new ProductWithTypesAndBrandsSpec(id);
			var pdt = await product.GetEntityWithSpec(spec);

			if (pdt == null) return NotFound(new ApiResponse(404));
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