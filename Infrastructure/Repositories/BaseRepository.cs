using Domain.Entities;
using Domain.Entities.SoftDelete.Abstraction;
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
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity, ISoftDelete
    {
        protected readonly IMongoCollection<T> _collection;

        public BaseRepository(IMongoContext mongoContext, IOptions<MongoDbSettings> mongoDbSettings)
        {
            var collectionName = mongoDbSettings.Value.CollectionNames[typeof(T).Name];
            _collection = mongoContext.GetCollection<T>(collectionName);
        }

        public async Task<T> GetByIdAsync(int? id)
        {
            var filter = Builders<T>.Filter.And(
                            Builders<T>.Filter.Eq(x => x._id, id),
                            Builders<T>.Filter.Eq(x => x.IsDeleted, false));
            return await _collection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var filter = Builders<T>.Filter.Eq(x => x.IsDeleted, false);
            return await _collection.Find(filter).ToListAsync();
        }

        public async Task<T> CreateAsync(T entity)
        {
            await _collection.InsertOneAsync(entity);
            return entity;
        }

        public async Task UpdateAsync(int id, T entity)
        {
            await _collection.ReplaceOneAsync(x => x._id == id, entity);
        }

        public async Task DeleteAsync(int id)
        {
            var filter = Builders<T>.Filter.Eq(x => x._id, id);
            var update = Builders<T>.Update.Set(x => x.IsDeleted, true)
                                          .Set(x => x.DeletedAt, DateTimeOffset.Now);
            await _collection.UpdateOneAsync(filter, update);
        }
    }
}
