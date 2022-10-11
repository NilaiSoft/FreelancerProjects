using Microsoft.EntityFrameworkCore.ChangeTracking;
using FreelancerProjects.Models;
using FreelancerProjects.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FreelancerProjects.Services
{
    public interface IProjectServices
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        Task<EntityEntry<Project>> AddProjectAsync(Project item);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<int> AddAndSaveChangesProjectAsync(Project model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="project"></param>
        /// <returns></returns>
        Task<int> EditProjectAsync(Project project);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<int> SaveChangesProjectAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_pridicate"></param>
        /// <returns></returns>
        Task<int> DeleteProjectAsync(Expression<Func<Project, bool>> _pridicate);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_pridicate"></param>
        /// <returns></returns>
        Task<IList<Project>> GetProjectsAsync(Expression<Func<Project, bool>> _pridicate);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_pridicate"></param>
        /// <returns></returns>
        Task<IList<Project>> GetApplyedProjectByFreelancerId(string freelancerId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        Task<IList<Project>> GetApplyedProjectByCustomerId(string customerId);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<IList<Project>> GetProjectsAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        Task<IList<Project>> GetProjectsAsync(Expression<Func<Project, Project>> expression);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_pridicate"></param>
        /// <returns></returns>
        Task<Project> GetProjectAsync(Expression<Func<Project, bool>> _pridicate);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_pridicate"></param>
        /// <param name="selectItem"></param>
        /// <returns></returns>
        Task<Project> GetProjectAsync
            (Expression<Func<Project, bool>> _pridicate, Expression<Func<Project, Project>> selectItem);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<Project> FindProjectAsync(Expression<Func<Project, bool>> predicate);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        Task<bool> AnyProjectAsync(Expression<Func<Project, bool>> expression);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<bool> AnyProjectAsync();
    }
}
