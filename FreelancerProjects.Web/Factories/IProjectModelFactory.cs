using FreelancerProjects.Models;
using FreelancerProjects.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreelancerProjects.Web.Factories
{
    public interface IProjectModelFactory
    {
        Task<IList<ProjectModel>> PrepareProjectAsync(IList<Project> projects);
        Task<ProjectModel> PrepareProjectModelAsync(ProjectModel model, Project project);
        Task<ProjectModel> PrepareProjectModelAsync(Project project, string freelancerId);
        Task<ProjectModel> PrepareProjectModelAsync(Project project);
    }
}
