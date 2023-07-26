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
    public class PageComponentRepository : BaseRepository<PageComponent>, IPageComponentRepository
    {
        public PageComponentRepository(IMongoContext mongoContext, IOptions<MongoDbSettings> mongoDbSettings) : base(mongoContext, mongoDbSettings)
        {
        }

        public async Task<PageComponent> GetByNameAsync(string name)
        {
            var filter = Builders<PageComponent>.Filter.Eq(x => x.name, name);
            return await _collection.Find(filter).FirstOrDefaultAsync();
        }
    }
}
