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
    public class ProjectFreelancerServices : IProjectFreelancerServices
    {
        private readonly IRepository<ProjectFreelancerMapping, ProjectFreelancerMappingModel> _projectRepository;

        public ProjectFreelancerServices(IRepository<ProjectFreelancerMapping, ProjectFreelancerMappingModel> projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<int> AddAndSaveChangesAsync(ProjectFreelancerMapping project)
        {
            project.CreateDateTime = DateTime.Now;
            project.Deleted = false;
            project.Visibled = true;
            var insertProject = await _projectRepository.AddAsync(project);
            return await _projectRepository.SaveChangesAsync();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _projectRepository.SaveChangesAsync();
        }

        public async Task<EntityEntry<ProjectFreelancerMapping>> AddAsync(ProjectFreelancerMapping item)
        {
            return await _projectRepository.AddAsync(item);
        }

        public async Task<IList<ProjectFreelancerMapping>> GetFreelancerProjectsAsync()
        {
            return await _projectRepository.GetsAsync();
        }

        public async Task<IList<ProjectFreelancerMapping>> GetFreelancerProjectsAsync
            (Expression<Func<ProjectFreelancerMapping, bool>> predicate)
        {
            return await _projectRepository.GetsAsync(predicate);
        }

        public async Task<ProjectFreelancerMapping> GetFreelancerProjectAsync
            (Expression<Func<ProjectFreelancerMapping, bool>> predicate)
        {
            return await _projectRepository.GetAsync(predicate);
        }

        public async Task<bool> AnyFreelancerProjectAsync
            (Expression<Func<ProjectFreelancerMapping, bool>> predicate)
        {
            return await _projectRepository.AnyAsync(predicate);
        }

        public async Task<int> DeleteMapping(ProjectFreelancerMapping projectMapping)
        {
            return await _projectRepository.DeleteAsync(x => x.Id == projectMapping.Id);
        }

        public async Task<int> EditAsync(ProjectFreelancerMapping projectMapping)
        {
            return await _projectRepository.EditAsync(projectMapping);
        }
    }
}
