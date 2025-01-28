using AutoMapper;
using EarTrain.Infrastructure.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EarTrain.Application.CommandsAndQueries.Brands.GetBrands
{
    public class GetBrandsQueryHandler(ETContext context, IMapper mapper) : IRequestHandler<GetBrandsQuery, List<GetBrandsResponse>>
    {
        private readonly ETContext _context = context;
        private readonly IMapper _mapper = mapper;

        public async Task<List<GetBrandsResponse>> Handle(GetBrandsQuery request, CancellationToken cancellationToken)
        {
            var data= await _context.ProductBrands
                                .ToListAsync(cancellationToken);

            var mappedData = _mapper.Map<List<GetBrandsResponse>>(data);

            return mappedData;
        }
    }
}
