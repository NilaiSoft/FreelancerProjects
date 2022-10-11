using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelancerProjects.Models
{
    public class ProjectFreelancerMapping : BaseEntity
    {
        [ForeignKey(nameof(ProjectId))]
        public Project Project { get; set; }
        public int ProjectId { get; set; }
        [ForeignKey(nameof(FreelancerId))]
        public ApplicationUser ApplicationUser { get; set; }
        public string FreelancerId { get; set; }
        public decimal Price { get; set; }
        public bool IsApplyed { get; set; }
    }
}
