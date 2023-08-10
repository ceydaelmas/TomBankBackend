using Domain.Entities;
using Domain.IRepositories;
using Domain.Settings;
using Infrastructure.Context;
using Microsoft.Extensions.Options;
using MongoDB.Driver;


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
        public async Task<IEnumerable<PageComponent>> GetComponentsByPageNameAsync(int pageId)
        {
            var filter = Builders<PageComponent>.Filter.Eq(x => x.pageId, pageId);
            return await _collection.Find(filter).ToListAsync();
        }

    }
}
