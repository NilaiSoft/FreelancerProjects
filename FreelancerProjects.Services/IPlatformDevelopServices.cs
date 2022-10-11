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
    public interface IPlatformDevelopServices
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        Task<EntityEntry<PlatformDevelop>> AddAsync(PlatformDevelop item);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<int> AddAndSaveChangesAsync(PlatformDevelop model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<PlatformDevelop> GetPlatformAsync
            (Expression<Func<PlatformDevelop, bool>> predicate);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<IList<PlatformDevelop>> GetPlatformsAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        Task<IList<PlatformDevelop>> GetPlatformsByIdsAsync(int[] ids);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<IList<PlatformDevelop>> GetPlatformsAsync
            (Expression<Func<PlatformDevelop, bool>> predicate);
    }
}
