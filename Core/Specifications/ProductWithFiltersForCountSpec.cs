using back.Core.Entities;

namespace back.Core.Specifications
{
	public class ProductWithFiltersForCountSpec : BaseSpecification<Product>
	{
		public ProductWithFiltersForCountSpec(ProductSpecParams productSpecParams)
		: base(x => 
			(string.IsNullOrEmpty(productSpecParams.Search) || x.Name.ToLower().Contains(productSpecParams.Search)) &&
			(!productSpecParams.BrandId.HasValue || x.ProductBrandId == productSpecParams.BrandId) && 
			(!productSpecParams.TypeId.HasValue || x.ProductTypeId == productSpecParams.TypeId)
		)
		{
		}
	}
}