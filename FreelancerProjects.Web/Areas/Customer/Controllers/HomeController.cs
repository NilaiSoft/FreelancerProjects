using Microsoft.AspNetCore.Mvc;

namespace FreelancerProjects.Web.Areas.Customer.Controllers
{
    [Area("customer")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
