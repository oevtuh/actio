using System;
using System.Threading.Tasks;
using Actio.Activities.Domain.Models;

namespace Actio.Activities.Domain.Repositories
{
    public interface IActivityRepository
    {
        Task<Activity> GetAsync(Guid id);
        Task AddAsync(Activity activity);
    }
}