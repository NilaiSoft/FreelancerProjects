using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using FreelancerProjects.Services;
using System.Threading.Tasks;
using AutoMapper;
using FreelancerProjects.Models.ViewModels;
using System.Collections.Generic;
using System;

namespace NilaiSofts.Web.Freelancer.Controllers.Components
{
    public class ProjectListViewComponent : ViewComponent
    {
        private readonly IProjectServices _projectService;
        private readonly IWorkContextServices _workContextServices;
        private readonly IMapper _mapper;

        public ProjectListViewComponent(IProjectServices projectService, IMapper mapper, IWorkContextServices workContextServices)
        {
            _projectService = projectService;
            _mapper = mapper;
            _workContextServices = workContextServices;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _projectService.GetProjectsAsync()
                ?? throw new ArgumentException("No project found with the projects");
            var retModel = _mapper.Map<IList<ProjectModel>>(model);
            foreach (var item in retModel)
            {
                var user = await _workContextServices.GetUser(x => x.Id == item.CustomerId);
                item.CustomerName = $"{user.FirstName} {user.LastName}";
            }
            return View(retModel);
        }
    }
}
