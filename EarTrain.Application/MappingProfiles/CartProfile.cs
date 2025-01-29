using AutoMapper;
using EarTrain.Application.CommandsAndQueries.Cart.GetUsersCart;
using EarTrain.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EarTrain.Application.MappingProfiles
{
    public class CartProfile : Profile
    {
        public CartProfile()
        {
            CreateMap<CartItem, GetUsersCartResponse>()
                .ForMember(p => p.ID, opt => opt.MapFrom(p => p.Id))
                .ForMember(p => p.ProductName, opt => opt.MapFrom(p => p.Product.Name))
                .ForMember(p => p.Price, opt => opt.MapFrom(p => p.Product.Price));
        }
    }
}
