using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelancerProjects.Models
{
    public class BaseEntity
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [ScaffoldColumn(false)]
        public bool Deleted { get; set; }
        public bool Visibled { get; set; }
        public DateTime CreateDateTime { get; set; }
    }
}
