using FreelancerProjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FreelancerProjects.Services
{
    public interface IWorkContextServices
    {
        Task<ApplicationUser> GetUser(Expression<Func<ApplicationUser, bool>> _predicate);
        Task<string> GetUserFullName(Expression<Func<ApplicationUser, bool>> _predicate);
    }
}
