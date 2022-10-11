using FreelancerProjects.Models;
using FreelancerProjects.Models.ViewModels;
using FreelancerProjects.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreelancerProjects.Web.Factories
{
    public class ProjectLogModelFactory : IProjectLogModelFactory
    {
        private readonly IRepository<Project, ProjectModel> _projectRepository;
        private readonly IProjectLogServices _projectLogServices;
        private readonly IWorkContextServices _workContextServices;

        public ProjectLogModelFactory(IRepository<Project, ProjectModel> projectRepository, IProjectLogServices projectLogServices, IWorkContextServices workContextServices)
        {
            _projectRepository = projectRepository;
            _projectLogServices = projectLogServices;
            _workContextServices = workContextServices;
        }

        public async Task<ProjectLogModel> PrepareProjectLogAsync(ProjectLog projectLog)
        {
            return new ProjectLogModel()
            {
                CreateDateTime = projectLog.CreateDateTime,
                Deleted = projectLog.Deleted,
                Descriptions = projectLog.Descriptions,
                Id = projectLog.Id,
                IsClose = projectLog.IsClose,
                Project = projectLog.Project,
                ProjectId = projectLog.ProjectId,
                Title = projectLog.Title,
                Visibled = projectLog.Visibled,
                CreatorUserName = await _workContextServices.GetUserFullName
                (x => x.Id == projectLog.CreatorUserId)
            };
        }

        public async Task<IList<ProjectLogModel>> PrepareProjectLogsAsync(IList<ProjectLog> projectLogss)
        {
            var projectLogsIds = projectLogss.Select(x => x.Id).ToArray();

            projectLogss = await _projectLogServices
                .GetProjectLogsAsync(x => projectLogsIds.Contains(x.Id));

            var model = (from pl in projectLogss
                         join p in _projectRepository.Table()
                         on pl.ProjectId equals p.Id
                         select new ProjectLogModel
                         {
                             CreateDateTime = pl.CreateDateTime,
                             Deleted = pl.Deleted,
                             Id = pl.Id,
                             Descriptions = pl.Descriptions,
                             IsClose = pl.IsClose,
                             Project = pl.Project,
                             ProjectId = pl.ProjectId,
                             Title = pl.Title,
                             Visibled = pl.Visibled,
                             CreatorUserId = pl.CreatorUserId,
                             CreatorUserName = _workContextServices.GetUserFullName(x => x.Id == pl.CreatorUserId).Result
                         }).OrderByDescending(x => x.Id);

            return model.ToList();
        }
    }
}
