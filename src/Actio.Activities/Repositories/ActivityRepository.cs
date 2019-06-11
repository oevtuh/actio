using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Actio.Activities.Domain.Models;
using Actio.Activities.Domain.Repositories;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Actio.Activities.Repositories
{
    public class ActivityRepository : IActivityRepository
    {
        private readonly IMongoDatabase _database;
        public ActivityRepository(IMongoDatabase database)
        {
            _database = database;
        }
        public async Task<Activity> GetAsync(Guid id) =>
            await Collection.AsQueryable().FirstOrDefaultAsync(x => x.Id == id);

        public async Task<IEnumerable<Activity>> BrowseAsync() => await Collection.AsQueryable().ToListAsync();

        public async Task AddAsync(Activity category) => await Collection.InsertOneAsync(category);

        private IMongoCollection<Activity> Collection => _database.GetCollection<Activity>("Activities");
    }
}
