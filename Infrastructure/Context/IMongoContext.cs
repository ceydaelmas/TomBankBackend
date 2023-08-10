using MongoDB.Driver;

namespace Infrastructure.Context;

public interface IMongoContext
{
    IMongoCollection<T> GetCollection<T>(String collectionName);
}