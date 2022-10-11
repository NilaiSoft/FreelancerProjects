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
    public class ProjectLogServices : IProjectLogServices
    {
        private readonly IRepository<ProjectLog, ProjectLogModel> _platformDevelopRepository;

        public ProjectLogServices(IRepository<ProjectLog,
            ProjectLogModel> platformDevelopRepository)
        {
            _platformDevelopRepository = platformDevelopRepository;
        }

        public async Task<int> AddAndSaveChangesAsync(ProjectLog model)
        {
            return await _platformDevelopRepository.AddAndSaveChangesAsync(model);
        }

        public async Task<EntityEntry<ProjectLog>> AddAsync(ProjectLog item)
        {
            return await _platformDevelopRepository.AddAsync(item);
        }

        public async Task<ProjectLog> GetProjectLogAsync(Expression<Func<ProjectLog, bool>> predicate)
        {
            return await _platformDevelopRepository.GetAsync(predicate);
        }

        public async Task<IList<ProjectLog>> GetProjectLogsAsync()
        {
            return await _platformDevelopRepository.GetsAsync();
        }

        public async Task<IList<ProjectLog>> GetProjectLogsByIdsAsync(int[] ids)
        {
            return await _platformDevelopRepository.GetsAsync(x => ids.Contains(x.Id));
        }

        public async Task<IList<ProjectLog>> GetProjectLogsAsync(Expression<Func<ProjectLog, bool>> predicate)
        {
            return await _platformDevelopRepository.GetsAsync(predicate);
        }

        public async Task<int> EditAsync(ProjectLog entity)
        {
            return await _platformDevelopRepository.EditAsync(entity);
        }

        public async Task<int> DeleteAsync(Expression<Func<ProjectLog, bool>> _pridicate)
        {
            return await _platformDevelopRepository.DeleteAsync(_pridicate);
        }
    }
}
