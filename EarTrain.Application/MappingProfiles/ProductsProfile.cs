using AutoMapper;
using EarTrain.Application.CommandsAndQueries.Products.GetProductInfo;
using EarTrain.Application.CommandsAndQueries.Products.GetProducts;
using EarTrain.Core.Models;

namespace EarTrain.Application.MappingProfiles
{
    public class ProductsProfile : Profile
    {
        public ProductsProfile()
        {
            CreateMap<Product, RetrievedProduct>()
                .ForMember(p => p.Id, opt => opt.MapFrom(p => p.Id))
                .ForMember(p => p.ProductName, opt => opt.MapFrom(p => p.Name))
                .ForMember(p => p.BrandName, opt => opt.MapFrom(p => p.Brand.Name))
                .ForMember(p => p.Price, opt => opt.MapFrom(p => p.Price));

            CreateMap<Product, GetProductInfoResponse>()
                .ForMember(p => p.ProductName, opt => opt.MapFrom(p => p.Name))
                .ForMember(p => p.ProductDescription, opt => opt.MapFrom(p => p.Description))
                .ForMember(p => p.BrandName, opt => opt.MapFrom(p => p.Brand.Name))
                .ForMember(p => p.Price, opt => opt.MapFrom(p => p.Price))
                .ForMember(p => p.Characteristics, opt => opt.MapFrom(p => p.Characteristics));
        }
    }
}
