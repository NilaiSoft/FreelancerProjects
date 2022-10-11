using Microsoft.EntityFrameworkCore.ChangeTracking;
using FreelancerProjects.Models;
using FreelancerProjects.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FreelancerProjects.Services
{
    public class ProjectServices : IProjectServices
    {
        private readonly IRepository<Project, ProjectModel> _projectRepository;
        private readonly IRepository<ProjectFreelancerMapping, ProjectFreelancerMappingModel> _projectMappingRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="projectRepository"></param>
        public ProjectServices(IRepository<Project, ProjectModel> projectRepository, IRepository<ProjectFreelancerMapping, ProjectFreelancerMappingModel> projectMappingService)
        {
            _projectRepository = projectRepository;
            _projectMappingRepository = projectMappingService;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="project"></param>
        /// <returns></returns>
        public async Task<int> AddAndSaveChangesProjectAsync(Project project)
        {
            var insertProject = await _projectRepository.AddAsync(project);
            return await _projectRepository.SaveChangesAsync();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<int> SaveChangesProjectAsync()
        {
            return await _projectRepository.SaveChangesAsync();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public async Task<EntityEntry<Project>> AddProjectAsync(Project item)
        {
            return await _projectRepository.AddAsync(item);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public async Task<bool> AnyProjectAsync(Expression<Func<Project, bool>> expression)
        {
            return await _projectRepository.AnyAsync(expression);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<bool> AnyProjectAsync()
        {
            return await _projectRepository.AnyAsync();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="_pridicate"></param>
        /// <returns></returns>
        public async Task<int> DeleteProjectAsync(Expression<Func<Project, bool>> _pridicate)
        {
            return await _projectRepository.DeleteAsync(_pridicate);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task<Project> FindProjectAsync(Expression<Func<Project, bool>> predicate)
        {
            return await _projectRepository.FindAsync(predicate);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="_pridicate"></param>
        /// <returns></returns>
        public async Task<Project> GetProjectAsync(Expression<Func<Project, bool>> _pridicate)
        {
            return await _projectRepository.GetAsync(_pridicate, x => new Project
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                PlatformDevelop = x.PlatformDevelop,
                CustomerId = x.CustomerId,
                ProjectFreelancerMappings = x.ProjectFreelancerMappings,
                CreateDateTime = x.CreateDateTime,
                Deleted = x.Deleted
            });
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="_pridicate"></param>
        /// <returns></returns>
        public async Task<IList<Project>> GetProjectsAsync(Expression<Func<Project, bool>> _pridicate)
        {
            return await _projectRepository.GetsAsync(_pridicate);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IList<Project>> GetProjectsAsync()
        {
            return await _projectRepository.GetsAsync(x => new Project
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                PlatformDevelop = x.PlatformDevelop,
                CustomerId = x.CustomerId,
                ProjectFreelancerMappings = x.ProjectFreelancerMappings,
                CreateDateTime = x.CreateDateTime,
                Deleted = x.Deleted
            });
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public async Task<IList<Project>> GetProjectsAsync(Expression<Func<Project, Project>> expression)
        {
            return await _projectRepository.GetsAsync();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="_pridicate"></param>
        /// <param name="selectItem"></param>
        /// <returns></returns>
        public async Task<Project> GetProjectAsync(Expression<Func<Project, bool>> _pridicate, Expression<Func<Project, Project>> selectItem)
        {
            return await _projectRepository.GetAsync(_pridicate, selectItem);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="project"></param>
        /// <returns></returns>
        public async Task<int> EditProjectAsync(Project project)
        {
            return await _projectRepository.EditAsync(project);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="freelancerId"></param>
        /// <returns></returns>
        public async Task<IList<Project>> GetApplyedProjectByFreelancerId(string freelancerId)
        {
            var projects = _projectRepository.Table();
            var mapp = _projectMappingRepository.Table();

            return await (from proj in projects
                          join map in mapp
                          on proj.Id equals map.ProjectId
                          where proj.CustomerId == freelancerId
                          //&& map.IsApplyed
                          select new Project
                          {
                              Name = proj.Name,
                              PlatformDevelop = proj.PlatformDevelop,
                              CreateDateTime = proj.CreateDateTime,
                              CustomerId = proj.CustomerId,
                              Deleted = proj.Deleted,
                              Description = proj.Description,
                              Id = proj.Id,
                              PlatformId = proj.PlatformId,
                              ProjectFreelancerMappings = proj.ProjectFreelancerMappings
                          }).ToListAsync();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="freelancerId"></param>
        /// <returns></returns>
        public async Task<IList<Project>> GetApplyedProjectByCustomerId(string freelancerId)
        {
            var projects = _projectRepository.Table();
            var mapp = _projectMappingRepository.Table();

            return await (from proj in projects
                          join map in mapp
                          on proj.Id equals map.ProjectId
                          where proj.CustomerId == freelancerId
                          && map.IsApplyed
                          select new Project
                          {
                              Name = proj.Name,
                              PlatformDevelop = proj.PlatformDevelop,
                              CreateDateTime = proj.CreateDateTime,
                              CustomerId = proj.CustomerId,
                              Deleted = proj.Deleted,
                              Description = proj.Description,
                              Id = proj.Id,
                              PlatformId = proj.PlatformId,
                              ProjectFreelancerMappings = proj.ProjectFreelancerMappings
                          }).ToListAsync();
        }
    }
}
