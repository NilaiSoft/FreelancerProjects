using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelancerProjects.Models.ViewModels
{
    public class ProjectModel : BaseViewModel
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
        public int PlatformId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public PlatformDevelop PlatformDevelop { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string PlatformName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ScaffoldColumn(false)]
        public string CustomerId { get; set; }

        [ScaffoldColumn(false)]
        public string CustomerName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ScaffoldColumn(false)]
        [Required]
        public decimal? Price { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ScaffoldColumn(false)]
        [Required]
        public bool IsApplyed { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Project Project { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? CreateDateTime { get; set; } = DateTime.Now;

        /// <summary>
        /// 
        /// </summary>
        public virtual ProjectFreelancerMapping ProjectFreelancerMappings { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool Deleted { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool Visibled { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string FreelancerName { get; set; }
    }
}
