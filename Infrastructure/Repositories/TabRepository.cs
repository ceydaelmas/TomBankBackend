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
        public async Task<int> GetIdByNameAsync(string tabName)
        {
            var filter = Builders<Tab>.Filter.Eq(t => t.name, tabName);
            var tab = await _collection.Find(filter).FirstOrDefaultAsync();
            if (tab is null)
            {
                return -1;

            }
            return tab._id;
        }
        public async Task<bool> ExistsAsync(string tabName)
        {
            var filter = Builders<Tab>.Filter.Eq(t => t.name, tabName);
            var result = await _collection.Find(filter).FirstOrDefaultAsync();
            return result != null;
        }
        public string GetNameById(int? id)
        {
         
            var filter = Builders<Tab>.Filter.Eq(t => t._id, id);
            var tab =  _collection.Find(filter).FirstOrDefault();
            if (tab is null)
            {
                return null;

            }
            return tab.name;
        }

        public async Task<List<Tab>> GetSelectableParentTabs(int id)
        {
            var filter = Builders<Tab>.Filter.Where(t =>(t._id!= id) && (t.parentId!=id) && (t.IsDeleted!=true));

            var selectedTabs = await _collection.Find(filter).ToListAsync();
            return selectedTabs;
            /*
             1 -> kendisi gelmicek,parametre yollanacak
             2->kendsiinin childlari gelmeyecek 
             */
        }
        public async Task<List<Tab>> GetByParentIdAsync(int parentId)
        {
            var filter = Builders<Tab>.Filter.Where(t => (t.parentId==parentId) && (t.IsDeleted!=true));
            var childTabs = await _collection.Find(filter).ToListAsync();
            return childTabs;
        }
    }
}
