using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelancerProjects.Models
{
    public class Project : BaseEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 
        /// </summary>

        public string CustomerId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ForeignKey(nameof(PlatformId))]
        public PlatformDevelop PlatformDevelop { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int PlatformId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual ProjectFreelancerMapping ProjectFreelancerMappings { get; set; }
    }
}
