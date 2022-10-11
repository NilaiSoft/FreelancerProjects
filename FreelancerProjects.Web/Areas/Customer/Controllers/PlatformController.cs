using AutoMapper;
using FreelancerProjects.Models;
using FreelancerProjects.Models.ViewModels;
using FreelancerProjects.Services;
using FreelancerProjects.Web.Customer.BaseController;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreelancerProjects.Web.Areas.Customer.Controllers
{
    public class PlatformController : CustomerBaseController<PlatformDevelop, PlatformDevelopModel>
    {
        private readonly IPlatformDevelopServices _projectService;
        private readonly ILogger<PlatformController> _logger;
        private readonly IMapper _mapper;

        public PlatformController(IPlatformDevelopServices projectService, IMapper mapper
            , IRepository<PlatformDevelop, PlatformDevelopModel> repository
            , ILogger<PlatformController> logger) : base(repository, mapper)
        {
            _projectService = projectService;
            _logger = logger;
            _logger.LogDebug(1, $"NLog injected into {nameof(PlatformController)}");
            _mapper = mapper;
        }
    }
}
