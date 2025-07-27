using Invoice.Business.Interfaces;
using Invoice.Business.Notificacoes;
using Invoice.Business.Services;
using Invoice.Data.Repository;

namespace Invoice.Api.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            //Repositories
            services.AddScoped<IFaturaRepository, FaturaRepository>();
            services.AddScoped<IFaturaItemRepository, FaturaItemRepository>();

            //Services
            services.AddScoped<INotificador, Notificador>();
            services.AddScoped<IFaturaService, FaturaService>();

            return services;
        }
    }
}
