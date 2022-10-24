using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreelancerProjects.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var result = new string[] { "Ehsan", "Nilai" };
            return View(result);
        }
    }
}
