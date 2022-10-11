using FreelancerProjects.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FreelancerProjects.Services
{
    public class WorkContextServices : IWorkContextServices
    {
        protected ApplicationDbContext _context;

        public WorkContextServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ApplicationUser> GetUser(Expression<Func<ApplicationUser, bool>> _predicate)
        {
            var user = _context.Users.Where(_predicate);
            return await user.FirstOrDefaultAsync();
        }

        public async Task<string> GetUserFullName(Expression<Func<ApplicationUser, bool>> _predicate)
        {
            var user = await _context.Users.FirstOrDefaultAsync(_predicate);
            return $"{user.FirstName} {user.LastName}";
        }
    }
}
