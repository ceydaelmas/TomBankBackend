using Domain.IRepositories;
using Infrastructure.Context;
using Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
        {
            #region LifeTime
            services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddTransient(typeof(IMongoContext), typeof(MongoContext));
            services.AddTransient<ITabRepository, TabRepository>();
            services.AddTransient<ICounterRepository, CounterRepository>();
            services.AddTransient<IComponentRepository, ComponentRepository>();
            services.AddTransient<IPropertyRepository, PropertyRepository>();
            //services.AddTransient<IValueRepository, ValueRepository>();
            services.AddTransient<IPageComponentRepository, PageComponentRepository>();
            #endregion
        }
    }
}
