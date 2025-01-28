using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using FluentValidation;
using EarTrain.Application.OtherServices.JWT;

namespace EarTrain.Application.DI
{
    public static class ApplicationServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg=> cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddAutoMapper(cfg=> cfg.AddMaps(Assembly.GetExecutingAssembly()));

            services.AddSingleton<JwtTokenProviderService>();

            return services;

        }
    }
}
