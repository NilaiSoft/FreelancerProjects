using FreelancerProjects.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FreelancerProjects.Services
{
    public interface IProjectFreelancerServices
    {
        Task<IList<ProjectFreelancerMapping>> GetFreelancerProjectsAsync();
        Task<IList<ProjectFreelancerMapping>> GetFreelancerProjectsAsync
            (Expression<Func<ProjectFreelancerMapping, bool>> predicate);

        Task<ProjectFreelancerMapping> GetFreelancerProjectAsync
            (Expression<Func<ProjectFreelancerMapping, bool>> predicate);

        Task<bool> AnyFreelancerProjectAsync
            (Expression<Func<ProjectFreelancerMapping, bool>> predicate);

        Task<EntityEntry<ProjectFreelancerMapping>> AddAsync(ProjectFreelancerMapping item);

        Task<int> AddAndSaveChangesAsync(ProjectFreelancerMapping model);
        
        Task<int> DeleteMapping(ProjectFreelancerMapping projectMapping);
        Task<int> EditAsync(ProjectFreelancerMapping projectMapping);
    }
}
