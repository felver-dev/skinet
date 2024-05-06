using back.Core.Entities;
using back.Core.Interfaces;
using back.Infrastructure.context;
using Microsoft.EntityFrameworkCore;

namespace back.Infrastructure.Data
{
	public class ProductBrandRepository : IProductBrandRepository
	{
		private readonly StoreContext context;
		public ProductBrandRepository(StoreContext context)
		{
			this.context = context;	
		}
		public async Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync()
		{
			return await context.ProductBrands.ToListAsync();
		}
	}
}