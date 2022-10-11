using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Logging;
using FreelancerProjects.Models;
using FreelancerProjects.Services.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FreelancerProjects.Services
{
    public class Repository<TEntity, TModel> : IRepository<TEntity, TModel>
        where TEntity : BaseEntity
    {
        protected ApplicationDbContext _context;
        private readonly IUnitOfWork _uow;
        internal DbSet<TEntity> _dbSet;

        public IQueryable<TEntity> Table()
        {
            return _dbSet.AsQueryable();
        }

        public Repository(ApplicationDbContext context, IUnitOfWork uow)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
            _uow = uow;
        }

        public async Task<int> AddAndSaveChangesAsync(TEntity entity)
        {
            entity.CreateDateTime = DateTime.Now;
            await _dbSet.AddAsync(entity);
            return await _uow.CompleteAsync();
        }

        public async Task<int> AddRangeAndSaveChangesAsync(IList<TEntity> entitys)
        {
            await _dbSet.AddRangeAsync(entitys);
            return await _uow.CompleteAsync();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _uow.CompleteAsync();
        }

        public async Task<EntityEntry<TEntity>> AddAsync(TEntity entity)
        {
            entity.CreateDateTime = DateTime.Now;
            return await _dbSet.AddAsync(entity);
        }

        public async Task AddRangeAsync(IList<TEntity> entitys)
        {
            await _dbSet.AddRangeAsync(entitys);
        }

        public Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression)
        {
            return _dbSet.AnyAsync(expression);
        }
        public Task<bool> AnyAsync()
        {
            return _dbSet.AnyAsync();
        }

        public async Task<int> DeleteAsync(Expression<Func<TEntity, bool>> _pridicate)
        {
            try
            {
                var entity = await _dbSet.Where(_pridicate)
                                        .FirstOrDefaultAsync();

                if (entity == null) return 0;

                _dbSet.Remove(entity);
                return await SaveChangesAsync();
            }
            catch
            {
                return 0;
            }
        }

        public async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> _pridicate)
        {
            return await _dbSet.FindAsync(_pridicate);
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> _pridicate)
        {
            return await _dbSet.FirstOrDefaultAsync(_pridicate);
        }

        public async Task<IList<TEntity>> GetsAsync(Expression<Func<TEntity, bool>> _pridicate)
        {
            return await _dbSet.Where(_pridicate).ToListAsync();
        }

        public async Task<IList<TEntity>> GetsAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<IList<TEntity>> GetsAsync(Expression<Func<TEntity, TEntity>> expression)
        {
            return await _dbSet.Select(expression).ToListAsync();
        }

        public async Task<IList<TEntity>> GetsAsync
            (Expression<Func<TEntity, bool>> _pridicate, Expression<Func<TEntity, TEntity>> _selectList)
        {
            return await _dbSet.Where(_pridicate).Select(_selectList).ToListAsync();
        }

        #region UpdateUseZEntity
        //public async Task<int> EditAsync(Expression<Func<TEntity, bool>> predicate,
        //    Expression<Func<TEntity, TEntity>> expression)
        //{
        //    var result = await _dbSet.Where(predicate)
        //        .UpdateFromQueryAsync(expression);
        //    return result;
        //}
        #endregion

        public async Task<int> EditAsync(TEntity entity)
        {
            #region OtherMethod
            //_context.Entry<TEntity>(entity).State = EntityState.Modified;
            #endregion
            _dbSet.Update(entity);
            return await _uow.CompleteAsync();
        }

        public async Task<int> EditAsync(Expression<Func<TEntity, TEntity>> predicate
            , Expression<Func<TEntity, TEntity>> entity)
        {
            _context.Entry(predicate).CurrentValues.SetValues(entity);
            return await _uow.CompleteAsync();
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> _pridicate, Expression<Func<TEntity, TEntity>> selectItem)
        {
            return await _dbSet.Where(_pridicate).Select(selectItem).FirstOrDefaultAsync();
        }

        public async Task<ApplicationUser> GetUser(Expression<Func<ApplicationUser, bool>> _predicate)
        {
            var user = _context.Users.Where(x => x.Id == "25b47bfd-3e89-42e3-8290-d9d90a3c74b6");
            return await user.FirstOrDefaultAsync();
        }
    }
}
