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
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly IMongoCollection<T> _collection;

        public BaseRepository(IMongoContext mongoContext, IOptions<MongoDbSettings> mongoDbSettings)
        {
            var collectionName = mongoDbSettings.Value.CollectionNames[typeof(T).Name];
            _collection = mongoContext.GetCollection<T>(collectionName);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _collection.Find(x => x._id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _collection.Find(_ => true).ToListAsync();
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
            await _collection.DeleteOneAsync(x => x._id == id);
        }
    }
}
