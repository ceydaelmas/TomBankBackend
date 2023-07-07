using Domain.Entities;
using Domain.IRepositories;
using Domain.Settings;
using Infrastructure.Context;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class TabRepository : BaseRepository<Tab>, ITabRepository
    {
        public TabRepository(IMongoContext mongoContext, IOptions<MongoDbSettings> mongoDbSettings) : base(mongoContext, mongoDbSettings)
        {
        }

        public async Task<List<Tab>> GetAllTab()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }
    }
}
