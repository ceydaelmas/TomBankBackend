using Domain.Entities;
using Domain.IRepositories;
using Domain.Settings;
using Infrastructure.Context;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Attribute = Domain.Entities.Attribute;

namespace Infrastructure.Repositories
{
    public class AttributeRepository : BaseRepository<Attribute>, IAttributeRepository
    {
        public AttributeRepository(IMongoContext mongoContext, IOptions<MongoDbSettings> mongoDbSettings) : base(mongoContext, mongoDbSettings)
        {
        }
    }
}
