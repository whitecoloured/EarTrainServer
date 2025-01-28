using EarTrain.Application.OtherServices.JWT;
using EarTrain.Core.Models;
using EarTrain.Core.Exceptions;
using EarTrain.Infrastructure.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace EarTrain.Application.CommandsAndQueries.Users.UpdateUsersCredits
{
    public class UpdateUsersCreditsCommandHandler(ETContext context) : IRequestHandler<UpdateUsersCreditsCommand, Unit>
    {
        private readonly ETContext _context = context;

        public async Task<Unit> Handle(UpdateUsersCreditsCommand request, CancellationToken cancellationToken)
        {
            Guid UserID = JwtDataProviderService.GetUserIDFromToken(request.HeaderData);

            if (UserID == Guid.Empty)
                throw new NotFoundException("Ваши данные не были найдены!");

            Expression<Func<SetPropertyCalls<User>, SetPropertyCalls<User>>> propertyCalls = opt => request.IsSuccesfullyCompleted ?

                opt
                .SetProperty(p => p.ETCoinsAmount, p => p.ETCoinsAmount + 10)
                .SetProperty(p => p.SuccessfullyCompletedTrainingsAmount, p => p.SuccessfullyCompletedTrainingsAmount + 1)
                .SetProperty(p => p.TrainingsCompletedAmount, p => p.TrainingsCompletedAmount + 1) :

                opt
                .SetProperty(p => p.TrainingsCompletedAmount, p => p.TrainingsCompletedAmount + 1);

            await _context.Users
                    .Where(p => p.Id == UserID)
                    .ExecuteUpdateAsync(propertyCalls, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
