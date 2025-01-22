using EarTrain.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EarTrain.Infrastructure.DI
{
    public static class DBContextService
    {
        public static IServiceCollection AddDbContext(this IServiceCollection services, string stringConnection)
        {
            services.AddDbContext<ETContext>(options => 
                options.UseSqlServer(stringConnection));

            return services;
        }
    }
}
