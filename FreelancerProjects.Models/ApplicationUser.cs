using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FreelancerProjects.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ImageProfile { get; set; }
        public bool IsActive { get; set; }
        public byte[] Avatar { get; set; }
        //[NotMapped]
        //public IFormFile ImageFile { get; set; }
    }
}
