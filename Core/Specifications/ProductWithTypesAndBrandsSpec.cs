using back.Core.Entities;

namespace back.Core.Specifications
{
	public class ProductWithTypesAndBrandsSpec : BaseSpecification<Product>
	{
		public ProductWithTypesAndBrandsSpec()
		{
			AddInclude(x => x.ProductType);
			AddInclude(x => x.ProductBrand);
		}
		
		public ProductWithTypesAndBrandsSpec(int id) : base(x => x.Id == id)
		{
			AddInclude(x => x.ProductType);
			AddInclude(x => x.ProductBrand);
		}
	}
}