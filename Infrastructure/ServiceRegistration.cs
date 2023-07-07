using Domain.IRepositories;
using Infrastructure.Context;
using Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            #endregion
        }
    }
}
