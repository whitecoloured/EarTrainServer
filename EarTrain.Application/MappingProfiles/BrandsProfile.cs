using AutoMapper;
using EarTrain.Application.CommandsAndQueries.Brands.GetBrands;
using EarTrain.Core.Models;


namespace EarTrain.Application.MappingProfiles
{
    public class BrandsProfile : Profile
    {
        public BrandsProfile()
        {
            CreateMap<ProductBrand, GetBrandsResponse>()
                .ForMember(p => p.Id, opt => opt.MapFrom(p => p.ID))
                .ForMember(p => p.BrandName, opt => opt.MapFrom(p => p.Name));
        }
    }
}
