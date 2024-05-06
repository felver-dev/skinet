
using back.Core.Entities;

namespace back.Core.Interfaces
{
	public interface IProductRepository
	{
		Task<Product> GetProductByIdAsync(int id);
		Task<IReadOnlyList<Product>> GetProductsAsync();
	}
}