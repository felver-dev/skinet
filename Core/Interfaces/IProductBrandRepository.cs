using back.Core.Entities;

namespace back.Core.Interfaces
{
	public interface IProductBrandRepository
	{
		Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync();
	}
}