using EarTrain.Application.OtherServices.JWT;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EarTrain.Application.CommandsAndQueries.Users.GetUserRole
{
    public class GetUserRoleQueryHandler : IRequestHandler<GetUserRoleQuery, string>
    {
        public Task<string> Handle(GetUserRoleQuery request, CancellationToken cancellationToken)
        {
            string role = JwtDataProviderService.GetUserRoleFromToken(request.HeaderData);

            if (role is null)
            {
                return Task.FromResult("norole");
            }

            return Task.FromResult(role);
        }
    }
}
