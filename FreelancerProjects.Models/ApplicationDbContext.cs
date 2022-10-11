using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Threading.Tasks;

namespace FreelancerProjects.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            //_transaction = Database.BeginTransaction();
        }

        public ApplicationDbContext() : base()
        {

        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //}

        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<ProjectFreelancerMapping> ProjectFreelancerMappings { get; set; }
        public virtual DbSet<PlatformDevelop> PlatformDevelops { get; set; }
        public virtual DbSet<ProjectLog> ProjectLogs { get; set; }

        private IDbContextTransaction _transaction;

        public void BeginTransaction()
        {
            //_transaction = Database.BeginTransaction();
        }

        public async Task<int> CommitAsync()
        {
            try
            {
                var result = await SaveChangesAsync();
                //_transaction.Commit();
                return result;
            }
            catch (Exception ex)
            {
                //await _transaction.RollbackAsync();
                //await _transaction.DisposeAsync();
                return 0;
            }
        }
    }
}
