using back.Core.Entities;
using back.Core.Interfaces;
using back.Infrastructure.context;
using Microsoft.EntityFrameworkCore;

namespace back.Infrastructure.Data
{
	public class ProductRepository : IProductRepository
	{
		private readonly StoreContext context; 
		public ProductRepository(StoreContext context)
		{
			this.context = context;	
		}
		public async Task<Product> GetProductByIdAsync(int id)
		{
			return await context.Products
			.Include(p => p.ProductType)
			.Include(p => p.ProductBrand)
			.FirstOrDefaultAsync(p => p.Id == id);	
		}

		public async Task<IReadOnlyList<Product>> GetProductsAsync()
		{
			return await  context.Products
				.Include(p => p.ProductType)
				.Include(p => p.ProductBrand)
				.ToListAsync();
		}
	}
}