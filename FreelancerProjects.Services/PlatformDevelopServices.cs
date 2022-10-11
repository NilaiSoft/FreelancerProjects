using FreelancerProjects.Models;
using FreelancerProjects.Models.ViewModels;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FreelancerProjects.Services
{
    public class PlatformDevelopServices : IPlatformDevelopServices
    {
        private readonly IRepository<PlatformDevelop, PlatformDevelopModel> _platformDevelopRepository;

        public PlatformDevelopServices(IRepository<PlatformDevelop,
            PlatformDevelopModel> platformDevelopRepository)
        {
            _platformDevelopRepository = platformDevelopRepository;
        }

        public async Task<int> AddAndSaveChangesAsync(PlatformDevelop model)
        {
            return await _platformDevelopRepository.AddAndSaveChangesAsync(model);
        }

        public async Task<EntityEntry<PlatformDevelop>> AddAsync(PlatformDevelop item)
        {
            return await _platformDevelopRepository.AddAsync(item);
        }

        public async Task<PlatformDevelop> GetPlatformAsync(Expression<Func<PlatformDevelop, bool>> predicate)
        {
            return await _platformDevelopRepository.GetAsync(predicate);
        }

        public async Task<IList<PlatformDevelop>> GetPlatformsAsync()
        {
            return await _platformDevelopRepository.GetsAsync();
        }

        public async Task<IList<PlatformDevelop>> GetPlatformsByIdsAsync(int[] ids)
        {
            return await _platformDevelopRepository.GetsAsync(x => ids.Contains(x.Id));
        }

        public async Task<IList<PlatformDevelop>> GetPlatformsAsync(Expression<Func<PlatformDevelop, bool>> predicate)
        {
            return await _platformDevelopRepository.GetsAsync(predicate);
        }
    }
}
