using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelancerProjects.Models
{
    public class PlatformDevelop : BaseEntity
    {
        [Display(Name = "PlatformName")]
        public string Name { get; set; }
    }
}
