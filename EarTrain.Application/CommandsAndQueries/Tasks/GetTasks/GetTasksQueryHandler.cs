using AutoMapper;
using EarTrain.Infrastructure.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EarTrain.Application.CommandsAndQueries.Tasks.GetTasks
{
    public class GetTasksQueryHandler(ETContext context, IMapper mapper) : IRequestHandler<GetTasksQuery, List<GetTasksResponse>>
    {
        private readonly ETContext _context = context;
        private readonly IMapper _mapper = mapper;
        private static readonly Random rand = new();

        public async Task<List<GetTasksResponse>> Handle(GetTasksQuery request, CancellationToken cancellationToken)
        {
            var queryableData = _context.Tasks
                            .AsNoTracking()
                            .AsQueryable();

            int[] indexes = [..queryableData.Select(p=> p.Id)];

            int startIndex = 0;

            int endIndex = indexes.Length-1;

            int[] selectedIndexes = [
                indexes[rand.Next(startIndex, endIndex)], 
                indexes[rand.Next(startIndex, endIndex)], 
                indexes[rand.Next(startIndex, endIndex)]
                ];

            var data = await queryableData
                            .Include(p => p.OGSound)
                            .Include(p => p.ChangedSound)
                            .Where(p => (p.Category == request.TaskCategory
                                   && p.ChangedSound.Category == request.SoundCategory
                                   && p.OGSound.Category==request.SoundCategory)
                                   && selectedIndexes.Contains(p.Id))
                            .ToListAsync(cancellationToken);

            var mappedData = _mapper.Map<List<GetTasksResponse>>(data);

            return mappedData;

        }
    }
}
