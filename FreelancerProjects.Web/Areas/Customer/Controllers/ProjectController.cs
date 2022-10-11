using AutoMapper;
using FreelancerProjects.Models;
using FreelancerProjects.Models.ViewModels;
using FreelancerProjects.Services;
using FreelancerProjects.Web.Customer.BaseController;
using FreelancerProjects.Web.Factories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FreelancerProjects.Web.Customer.Controllers
{
    public class ProjectController : CustomerBaseController<Project, ProjectModel>
    {
        private readonly IProjectServices _projectService;
        private readonly IProjectFreelancerServices _projectFreelancerServices;
        private readonly IPlatformDevelopServices _platformDevelopServices;
        private readonly IProjectModelFactory _projectModelFactory;
        private readonly IProjectLogServices _projectLogServices;
        private readonly IProjectLogModelFactory _projectLogModelFactory;
        private readonly ILogger<ProjectController> _logger;
        private readonly IMapper _mapper;

        public ProjectController(IProjectServices projectService, IMapper mapper
            , IRepository<Project, ProjectModel> repository
            , ILogger<ProjectController> logger
            , IProjectModelFactory projectModelFactory, IPlatformDevelopServices platformDevelopServices, IProjectFreelancerServices projectFreelancerServices, IProjectLogServices projectLogServices, IProjectLogModelFactory projectLogModelFactory) : base(repository, mapper)
        {
            _projectService = projectService;
            _logger = logger;
            _logger.LogDebug(1, $"NLog injected into {nameof(ProjectController)}");
            _mapper = mapper;
            _projectModelFactory = projectModelFactory;
            _platformDevelopServices = platformDevelopServices;
            _projectFreelancerServices = projectFreelancerServices;
            _projectLogServices = projectLogServices;
            _projectLogModelFactory = projectLogModelFactory;
        }

        public override async Task<IActionResult> Index()
        {
            _logger.LogInformation(nameof(Index));
            var projects = await _projectService.GetProjectsAsync();

            var model = await _projectModelFactory.PrepareProjectAsync(projects);
            return View(model);
        }

        public override async Task<IActionResult> Create()
        {
            var platform = await _platformDevelopServices.GetPlatformsAsync();
            ViewBag.Platforms = new SelectList(platform, "Id", "Name");
            return await base.Create();
        }

        public override async Task<IActionResult> Create(ProjectModel entity)
        {
            var UserId = User.GetUserID();
            entity.CustomerId = UserId;
            entity.CreateDateTime = DateTime.Now;
            return await base.Create(entity);
        }

        public override async Task<IActionResult> Edit(int id)
        {
            var platform = await _platformDevelopServices.GetPlatformsAsync();
            ViewBag.Platforms = new SelectList(platform, "Id", "Name");
            return await base.Edit(id);
        }

        public override async Task<IActionResult> Edit(ProjectModel entity)
        {
            var UserId = User.GetUserID();
            entity.CustomerId = UserId;
            return await base.Edit(entity);
        }

        public virtual async Task<IActionResult> FreelancerApplyed()
        {
            var user = User.GetUserID();
            var projects = await _projectService.GetApplyedProjectByFreelancerId(user);
            var model = await _projectModelFactory.PrepareProjectAsync(projects);
            return View(model);
        }

        public virtual async Task<IActionResult> FreelancerApplyedDetails(int id)
        {
            var user = User.GetUserID();
            var projects = await _projectService
                .GetProjectAsync(x => x.ProjectFreelancerMappings.Id == id && x.CustomerId == user);

            var model = await _projectModelFactory.PrepareProjectModelAsync(projects);

            return View(model);
        }

        [HttpPost]
        public virtual async Task<IActionResult> FreelancerApplyedDetails(ProjectModel model)
        {
            var project = await _projectFreelancerServices
                .GetFreelancerProjectAsync(x => x.Id == model.ProjectFreelancerMappings.Id)
                ?? throw new ArgumentException("project not exists");

            var projectMapping = await _projectFreelancerServices.GetFreelancerProjectAsync
                (x => x.Id == model.ProjectFreelancerMappings.Id);

            if (projectMapping != null)
            {
                projectMapping.IsApplyed = projectMapping.IsApplyed == true ? false : true;
                await _projectFreelancerServices.EditAsync(projectMapping);
            }

            return RedirectToAction("FreelancerApplyedDetails"
                , new { id = project.Id });
        }

        public virtual async Task<IActionResult> ProjectLogs(int id)
        {
            var model = await _projectLogServices
                .GetProjectLogsAsync(x => x.ProjectId == id);
            var retModel = await _projectLogModelFactory.PrepareProjectLogsAsync(model);

            var projectLogModel = new ProjectLogModel
            {
                ProjectLogModels = retModel,
                ProjectId = id
            };

            return View(projectLogModel);
        }

        public virtual async Task<IActionResult> DetailsProjectLogs(int id)
        {
            var projectLog = await _projectLogServices.GetProjectLogAsync(x => x.Id == id)
                ?? throw new ArgumentException("project not exists");

            var model = await _projectLogModelFactory.PrepareProjectLogAsync(projectLog);

            return View(model);
        }
    }
}
