using EarTrain.Core.Enums;
using MediatR;
using System;
using System.Collections.Generic;

namespace EarTrain.Application.CommandsAndQueries.Products.GetProducts
{
    public record GetProductsQuery(string SearchName, IEnumerable<ProductsCategory> Categories, IEnumerable<Guid?> BrandIDs, int? FirstPrice, int? SecondPrice, string SortItem, bool OrderByAsc, int Page=1) : IRequest<GetProductsResponse>;
}
