using EarTrain.Core.Options;

namespace EarTrain.API.DI
{
    public static class OptionsConfiguration
    {
        public static IServiceCollection ConfigureCustomOptions(this IServiceCollection services, IConfiguration config)
        {
            services.Configure<JWTOptions>(config.GetSection(nameof(JWTOptions)));
            services.Configure<EmailOptions>(config.GetSection(nameof(EmailOptions)));

            return services;
        }
    }
}
