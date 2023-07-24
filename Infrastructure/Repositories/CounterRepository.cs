using Domain.Entities;
using Domain.IRepositories;
using Infrastructure.Context;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class CounterRepository : ICounterRepository
    {
        private readonly IMongoContext _context;
        private readonly IMongoCollection<Counters> _counterCollection;

        public CounterRepository(IMongoContext context)
        {
            _context = context;
            _counterCollection = _context.GetCollection<Counters>("Counters");
        }

        public async Task<int> GetNextIdAsync(string counterId)
        {
            var filter = Builders<Counters>.Filter.Eq(c => c._id, counterId);
            var update = Builders<Counters>.Update.Inc(c => c.seq, 1);
            var options = new FindOneAndUpdateOptions<Counters> { ReturnDocument = ReturnDocument.After };
            var counter = await _counterCollection.FindOneAndUpdateAsync(filter, update, options);

            if (counter == null)
            {
                counter = new Counters
                {
                    _id = counterId,
                    seq = 1
                };

                await _counterCollection.InsertOneAsync(counter);
            }

            return counter.seq;
        }
    }
}
