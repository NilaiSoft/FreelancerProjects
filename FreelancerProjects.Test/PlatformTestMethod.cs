using AutoMapper;
using FreelancerProjects.Models;
using FreelancerProjects.Models.ViewModels;
using FreelancerProjects.Services;
using FreelancerProjects.Web.Customer.BaseController;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FreelancerProjects.Test
{
    [TestClass]
    public class PlatformTestMethod : CustomerBaseController<PlatformDevelop, PlatformDevelopModel>
    {
        public PlatformTestMethod(IRepository<PlatformDevelop, PlatformDevelopModel> repository,
            IMapper mapper) : base(repository, mapper)
        {

        }

        [TestMethod]
        public void CreatePlatform()
        {

        }
    }
}
