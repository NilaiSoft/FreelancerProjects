using FreelancerProjects.Models;
using FreelancerProjects.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreelancerProjects.Web.Factories
{
    public interface IProjectLogModelFactory
    {
        Task<IList<ProjectLogModel>> PrepareProjectLogsAsync(IList<ProjectLog> projectLogs);
        Task<ProjectLogModel> PrepareProjectLogAsync(ProjectLog projectLog);
    }
}
