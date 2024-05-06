using back.Core.Entities;
using back.Core.Interfaces;
using back.Infrastructure.context;
using Microsoft.EntityFrameworkCore;

namespace back.Infrastructure.Data
{
	public class ProductTypeRepository : IProductTypeRepository
	{
		private readonly StoreContext context;
		public ProductTypeRepository(StoreContext context)
		{
			this.context = context;	
		}
		public async Task<IReadOnlyList<ProductType>> GetProductTypesAsync()
		{
			return await context.ProductTypes.ToListAsync();
		}
	}
}