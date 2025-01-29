using AutoMapper;
using EarTrain.Application.CommandsAndQueries.Orders.GetUsersOrders;
using EarTrain.Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace EarTrain.Application.MappingProfiles
{
    public class OrdersProfile : Profile
    {
        public OrdersProfile()
        {
            CreateMap<Order, GetUsersOrdersResponse>()
                .ForMember(p => p.ID, opt => opt.MapFrom(p => p.Id))
                .ForMember(p => p.OrderedProducts, opt => opt.MapFrom((src, _, _, context) => context.Mapper.Map<List<OrderedProduct>>(src.Products)))
                .ForMember(p=> p.TotalPrice, opt=> opt.MapFrom(p=> p.Products.Select(p=> p.Price).Aggregate((f,n)=> f+n)))
                .ForMember(p => p.OrderDate, opt => opt.MapFrom(p => p.OrderDate))
                .ForMember(p => p.OrderReceived, opt => opt.MapFrom(p => p.OrderReceived));

            CreateMap<Product, OrderedProduct>()
                .ForMember(p => p.ProductName, opt => opt.MapFrom(p => p.Name))
                .ForMember(p => p.Price, opt => opt.MapFrom(p => p.Price));
        }
    }
}
