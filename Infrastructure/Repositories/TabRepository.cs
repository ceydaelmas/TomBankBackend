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
        public async Task<Tab> GetByNameAsync(string name)
        {
            return await _collection.Find(x => x.name == name).FirstOrDefaultAsync();
        }
        public async Task<int?> GetIdByNameAsync(string tabName)
        {
            var filter = Builders<Tab>.Filter.Eq(t => t.name, tabName);
            var tab = await _collection.Find(filter).FirstOrDefaultAsync();
            return tab?._id;
        }
        public async Task<bool> ExistsAsync(string tabName)
        {
            var filter = Builders<Tab>.Filter.Eq(t => t.name, tabName);
            var result = await _collection.Find(filter).FirstOrDefaultAsync();
            return result != null;
        }
    }
}
