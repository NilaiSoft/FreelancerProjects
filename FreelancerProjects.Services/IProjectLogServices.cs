using FreelancerProjects.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FreelancerProjects.Services
{
    public interface IProjectLogServices
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        Task<EntityEntry<ProjectLog>> AddAsync(ProjectLog item);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<int> EditAsync(ProjectLog entity);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<int> AddAndSaveChangesAsync(ProjectLog model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<ProjectLog> GetProjectLogAsync
            (Expression<Func<ProjectLog, bool>> predicate);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<IList<ProjectLog>> GetProjectLogsAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        Task<IList<ProjectLog>> GetProjectLogsByIdsAsync(int[] ids);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<IList<ProjectLog>> GetProjectLogsAsync
            (Expression<Func<ProjectLog, bool>> predicate);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_pridicate"></param>
        /// <returns></returns>
        Task<int> DeleteAsync(Expression<Func<ProjectLog, bool>> _pridicate);
    }
}
