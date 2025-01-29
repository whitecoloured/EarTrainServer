using AutoMapper;
using EarTrain.Core.Exceptions;
using EarTrain.Infrastructure.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace EarTrain.Application.CommandsAndQueries.Products.GetProductInfo
{
    public class GetProductInfoQueryHandler(ETContext context, IMapper mapper) : IRequestHandler<GetProductInfoQuery, GetProductInfoResponse>
    {
        private readonly ETContext _context = context;
        private readonly IMapper _mapper = mapper;

        public async Task<GetProductInfoResponse> Handle(GetProductInfoQuery request, CancellationToken cancellationToken)
        {
            var product = await _context.Products
                                    .AsNoTracking()
                                    .Include(p => p.Brand)
                                    .FirstOrDefaultAsync(p => p.Id == request.ProductID, cancellationToken) ?? throw new NotFoundException("Продукт был не найден!");

            var mappedProduct = _mapper.Map<GetProductInfoResponse>(product);

            return mappedProduct;
        }
    }
}
