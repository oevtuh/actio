using System.Collections.Generic;
using System.Threading.Tasks;
using Actio.Activities.Domain.Models;

namespace Actio.Activities.Domain.Repositories
{
    public interface ICategoryRepository
    {
        Task<Category> GetAsync(string name);
        Task<IEnumerable<Category>> BrowseAsync();
        Task AddAsync(Category category);
    }
}