using AutoMapper;
using FreelancerProjects.Models;
using FreelancerProjects.Models.ViewModels;
using FreelancerProjects.Services;
using FreelancerProjects.Web.Controllers;
using FreelancerProjects.Web.Customer.BaseController;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FreelancerProjects.Test
{
    [TestClass]
    public class PlatformTestMethod : CustomerBaseController<PlatformDevelop, PlatformDevelopModel>
    {
        private readonly IRepository<PlatformDevelop, PlatformDevelopModel> _platformDevelopRepository;
        private readonly IMapper _mapper;
        public PlatformTestMethod(IRepository<PlatformDevelop, PlatformDevelopModel> repository,
            IMapper mapper) : base(repository, mapper)
        {

        }

        [TestMethod]
        public async void CreatePlatform()
        {
            #region IndexTest1
            //var controller = new HomeController();

            //var result = controller.Index() as ViewResult;

            //Assert.IsNotNull(result);
            //Assert.IsNotNull(result.Model); // add additional checks on the Model
            //Assert.IsTrue(string.IsNullOrEmpty(result.ViewName) || result.ViewName == "Index");

            //Assert.AreEqual("Index", result.ViewName);
            #endregion

            #region IndexTest2
            //// Arrange
            //HomeController controller = new HomeController();
            //// Act
            //ViewResult result = controller.Index() as ViewResult;
            //// Assert
            //Assert.IsNotNull(result);
            #endregion

            var controller =
                new CustomerBaseController<PlatformDevelop, PlatformDevelopModel>
                (_platformDevelopRepository, _mapper);

            var result = await controller.Details(1) as ViewResult;

            Assert.AreEqual("Details", result.ViewName);
        }
    }
}
