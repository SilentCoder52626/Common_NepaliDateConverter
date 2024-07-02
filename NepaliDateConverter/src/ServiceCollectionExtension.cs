

using Microsoft.Extensions.DependencyInjection;

namespace NepaliDateConverter
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDateServices(this IServiceCollection services)
        {
            services.AddSingleton<IDateConverterService, DateConverterService>();
            return services;
        }
    }
}
