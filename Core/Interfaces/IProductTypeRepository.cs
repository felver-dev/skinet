using back.Core.Entities;

namespace back.Core.Interfaces
{
    public interface IProductTypeRepository
    {
		Task<IReadOnlyList<ProductType>> GetProductTypesAsync();
    }
}