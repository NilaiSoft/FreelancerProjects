using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelancerProjects.Models.ViewModels
{
    public class ProjectLogModel : BaseViewModel
    {
        public string Title { get; set; }

        public string Descriptions { get; set; }

        public bool IsClose { get; set; }

        [ScaffoldColumn(false)]
        public bool Deleted { get; set; }

        [ScaffoldColumn(false)]
        public bool Visibled { get; set; }

        public string CreatorUserId { get; set; }

        public string CreatorUserName { get; set; }

        public DateTime CreateDateTime { get; set; }

        public Project Project { get; set; }

        public int ProjectId { get; set; }

        public IList<ProjectLogModel> ProjectLogModels { get; set; }
    }
}
