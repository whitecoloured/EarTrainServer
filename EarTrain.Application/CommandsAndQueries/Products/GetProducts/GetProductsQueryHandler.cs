using AutoMapper;
using EarTrain.Core.Models;
using EarTrain.Infrastructure.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace EarTrain.Application.CommandsAndQueries.Products.GetProducts
{
    public class GetProductsQueryHandler(ETContext context, IMapper mapper) : IRequestHandler<GetProductsQuery, GetProductsResponse>
    {
        private readonly ETContext _context = context;
        private readonly IMapper _mapper = mapper;

        public async Task<GetProductsResponse> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var queryableData = _context.Products
                                .AsNoTracking()
                                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(request.SearchName))
            {
                queryableData = queryableData.Where(p => p.Name.Contains(request.SearchName));
            }
            if (request.Categories is not null)
            {
                if (request.Categories.Any())
                {
                    queryableData = queryableData.Where(p => request.Categories.Contains(p.Category));
                }
            }

            if (request.BrandIDs is not null)
            {
                if (request.BrandIDs.Any())
                {
                    queryableData = queryableData.Where(p => request.BrandIDs.Contains(p.BrandID));
                }
            }

            if (request.FirstPrice is not null && request.SecondPrice is not null)
            {
                queryableData=queryableData.Where(p => request.FirstPrice < p.Price && request.SecondPrice > p.Price);
            }

            if (!string.IsNullOrWhiteSpace(request.SortItem))
            {
                Expression<Func<Product, object>> orderKey = request.SortItem switch
                {
                    "price" => p => p.Price,
                    _ => p => p.Name
                };

                queryableData=request.OrderByAsc?
                    queryableData.OrderBy(orderKey):
                    queryableData.OrderByDescending(orderKey);
            }

            int allProductsAmount = queryableData.Count();

            queryableData = queryableData
                            .Skip(request.Page * 12 - 12)
                            .Take(12);
            
            var data= await queryableData
                            .Include(p=> p.Brand)
                            .ToListAsync(cancellationToken);

            var mappedData = _mapper.Map<List<RetrievedProduct>>(data);

            return new GetProductsResponse() { Products = mappedData, TotalProductsAmount=allProductsAmount };


        }
    }
}
