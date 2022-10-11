using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelancerProjects.Models
{
    public class ProjectLog : BaseEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Descriptions { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsClose { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ForeignKey(nameof(ProjectId))]
        public Project Project { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int ProjectId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ForeignKey(nameof(CreatorUserId))]
        public ApplicationUser ApplicationUser { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string CreatorUserId { get; set; }
    }
}
