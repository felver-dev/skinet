using AutoMapper;
using back.Core.Entities;
using back.DTO;

namespace back.Helpers
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<Product, ProductToReturnDto>()
			.ForMember(d => d.ProductBrand, o => o.MapFrom(s => s.ProductBrand.Name))
			.ForMember(d => d.ProductType, o => o.MapFrom(s => s.ProductType.Name))
			.ForMember(d => d.PictureUrl, o => o.MapFrom<ProductUrlResolver>())
			.ReverseMap();
		}
	}
}