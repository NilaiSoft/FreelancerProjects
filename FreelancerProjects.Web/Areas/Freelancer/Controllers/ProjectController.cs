using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using FreelancerProjects.Models;
using FreelancerProjects.Models.ViewModels;
using FreelancerProjects.Services;
using FreelancerProjects.Web.BaseController;
using FreelancerProjects.Web.Factories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FreelancerProjects.Web.Freelancer.BaseController;
using Microsoft.AspNetCore.Authorization;
using System;

namespace FreelancerProjects.Web.Freelancer.Controllers
{
    [Authorize]
    public class ProjectController : FreelancerBaseController<Project, ProjectModel>
    {
        private readonly IProjectServices _projectService;
        private readonly IProjectFreelancerServices _projectFreelancerService;
        private readonly IProjectLogServices _projectLogServices;
        private readonly IProjectModelFactory _projectModelFactory;
        private readonly IProjectLogModelFactory _projectLogModelFactory;
        private readonly ILogger<ProjectController> _logger;
        private readonly IMapper _mapper;

        public ProjectController(IProjectServices projectService, IMapper mapper
            , IRepository<Project, ProjectModel> repository, ILogger<ProjectController> logger, IProjectModelFactory projectModelFactory, IProjectFreelancerServices projectFreelancerService, IProjectLogModelFactory projectLogModelFactory, IProjectLogServices projectLogServices) : base(repository, mapper)
        {
            _projectService = projectService;
            _logger = logger;
            _logger.LogDebug(1, $"NLog injected into {nameof(ProjectController)}");
            _mapper = mapper;
            _projectModelFactory = projectModelFactory;
            _projectFreelancerService = projectFreelancerService;
            _projectLogModelFactory = projectLogModelFactory;
            _projectLogServices = projectLogServices;
        }

        public virtual async Task<IActionResult> FreelancerApplyed()
        {
            var user = User.GetUserID();
            var projects = await _projectService.GetApplyedProjectByCustomerId(user);
            var model = await _projectModelFactory.PrepareProjectAsync(projects);
            return View(model);
        }

        [HttpPost]
        public override async Task<IActionResult> Edit(ProjectModel pModel)
        {
            var project = _mapper.Map<Project>(pModel);
            await _projectService.EditProjectAsync(project);
            return RedirectToAction(nameof(Index));
        }

        public override async Task<IActionResult> Details(int id)
        {
            var freelancerId = User.GetUserID();
            var project = await _projectService.GetProjectAsync(x => x.Id == id);
            var model = await _projectModelFactory
                .PrepareProjectModelAsync(project, freelancerId);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Details(ProjectModel model)
        {
            var project = await _projectService.GetProjectAsync(x => x.Id == model.Id)
                ?? throw new ArgumentException("project not exists");

            var projectMapping = await _projectFreelancerService.GetFreelancerProjectAsync
                (x => x.FreelancerId == User.GetUserID() && x.ProjectId == project.Id);

            if (projectMapping != null)
            {
                await _projectFreelancerService.DeleteMapping(projectMapping);
                return RedirectToAction("Details", new { id = project.Id });
            }

            if (ModelState.IsValid)
            {
                var datetime = project.CreateDateTime.AddMinutes(30);
                if (datetime <= DateTime.Now)
                {
                    ModelState.AddModelError(nameof(model.Price)
                        , $"Expired Create DateTime,Create DateTime is {project.CreateDateTime}");

                    return View(model);
                }

                var projectFreelancerMapping = new ProjectFreelancerMapping
                {
                    FreelancerId = User.GetUserID(),
                    Price = model.Price.Value,
                    ProjectId = project.Id
                };

                await _projectFreelancerService.AddAndSaveChangesAsync(projectFreelancerMapping);
            }
            else
            {
                ModelState.AddModelError(nameof(model.Price), "Price");
                return View(model);
            }

            return RedirectToAction("Details", new { id = project.Id });
        }

        public virtual async Task<IActionResult> CreateProjectLogs(int id)
        {
            var project = await _projectService.GetProjectAsync(x => x.Id == id)
                ?? throw new ArgumentException("project not exists");

            var model = new ProjectLogModel
            {
                ProjectId = id,
                CreateDateTime = DateTime.Now
            };

            return View(model);
        }

        public virtual async Task<IActionResult> DeleteProjectLogs(int id)
        {
            var projectLog = await _projectLogServices.GetProjectLogAsync(x => x.Id == id)
                ?? throw new ArgumentException("project not exists");

            await _projectLogServices.DeleteAsync(x => x.Id == projectLog.Id);

            return RedirectToAction("ProjectLogs", new { id = projectLog.Id });
        }


        public virtual async Task<IActionResult> EditProjectLogs(int id)
        {
            var projectLog = await _projectLogServices.GetProjectLogAsync(x => x.Id == id)
                ?? throw new ArgumentException("project not exists");

            var model = await _projectLogModelFactory.PrepareProjectLogAsync(projectLog);

            return View(model);
        }


        public virtual async Task<IActionResult> DetailsProjectLogs(int id)
        {
            var projectLog = await _projectLogServices.GetProjectLogAsync(x => x.Id == id)
                ?? throw new ArgumentException("project not exists");

            var model = await _projectLogModelFactory.PrepareProjectLogAsync(projectLog);

            return View(model);
        }


        [HttpPost]
        public virtual async Task<IActionResult> CreateOrUpdateProjectLogs(ProjectLogModel logModel)
        {
            var project = await _projectService.GetProjectAsync(x => x.Id == logModel.ProjectId)
                ?? throw new ArgumentException("project not exists");

            var logs = _mapper.Map<ProjectLog>(logModel);
            if (logModel.Id == 0)
            {
                logs.CreatorUserId = User.GetUserID();
                var result = await _projectLogServices.AddAndSaveChangesAsync(logs);
            }
            else
            {
                await _projectLogServices.EditAsync(logs);
            }

            return RedirectToAction("ProjectLogs", new { id = project.Id });
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
    }
}
