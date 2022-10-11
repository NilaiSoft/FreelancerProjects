using AutoMapper;
using FreelancerProjects.Models;
using FreelancerProjects.Models.ViewModels;
using FreelancerProjects.Services;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreelancerProjects.Web.Factories
{
    public class ProjectModelFactory : IProjectModelFactory
    {
        private readonly IProjectServices _projectService;
        private readonly IProjectFreelancerServices _projectFreelancerService;
        private readonly IWorkContextServices _workContextServices;
        private readonly IMapper _mapper;

        public ProjectModelFactory(IMapper mapper, IProjectServices projectService, IProjectFreelancerServices projectFreelancerService, IWorkContextServices workContextServices)
        {
            _mapper = mapper;
            _projectService = projectService;
            _projectFreelancerService = projectFreelancerService;
            _workContextServices = workContextServices;
        }

        public async Task<IList<ProjectModel>> PrepareProjectAsync(IList<Project> projects)
        {
            var model = (from p in projects
                         select new ProjectModel
                         {
                             CreateDateTime = p.CreateDateTime,
                             CustomerId = p.CustomerId,
                             Description = p.Description,
                             Id = p.Id,
                             PlatformDevelop = p.PlatformDevelop,
                             Name = p.Name,
                             ProjectFreelancerMappings = p.ProjectFreelancerMappings
                         }).ToList();

            foreach (var item in model)
            {
                if (item.ProjectFreelancerMappings != null)
                    item.FreelancerName = await _workContextServices.GetUserFullName(x => x.Id == item.ProjectFreelancerMappings.FreelancerId);
            }

            return model;
        }

        public async Task<ProjectModel> PrepareProjectModelAsync(ProjectModel model, Project project)
        {
            project = await _projectService.GetProjectAsync(x => x.Id == project.Id,
                x => new Project
                {
                    Description = x.Description,
                    Id = x.Id,
                    Name = x.Name
                });

            return new ProjectModel
            {
                Description = project.Description,
                Id = project.Id,
                Name = project.Name
            };
        }

        public async Task<ProjectModel> PrepareProjectModelAsync(Project project, string freelancerId)
        {
            return new ProjectModel
            {
                Description = project.Description,
                Id = project.Id,
                Name = project.Name,
                ProjectFreelancerMappings = project.ProjectFreelancerMappings,
                Visibled = project.Visibled,
                CreateDateTime = project.CreateDateTime,
                CustomerId = project.CustomerId,
                Deleted = project.Deleted,
                PlatformDevelop = project.PlatformDevelop,
                CustomerName = await _workContextServices.GetUserFullName
                (x => x.Id == project.CustomerId)
            };
        }

        public async Task<ProjectModel> PrepareProjectModelAsync(Project project)
        {
            return new ProjectModel
            {
                Description = project.Description,
                Id = project.Id,
                Name = project.Name,
                ProjectFreelancerMappings = project.ProjectFreelancerMappings,
                Visibled = project.Visibled,
                CreateDateTime = project.CreateDateTime,
                CustomerId = project.CustomerId,
                Deleted = project.Deleted,
                PlatformDevelop = project.PlatformDevelop
            };
        }
    }
}
