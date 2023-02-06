using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using PedroFarah.Web.Api.Infrastructure.Interfaces.Repositories;

namespace PedroFarah.Web.Api.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public readonly DbContext CurrentContext;

        public DbSet<T> DbSet { get; set; }

        public Repository(DbContext currentContext)
        {
            CurrentContext = currentContext;
            DbSet = CurrentContext.Set<T>();
        }

        public virtual async Task<T> GetAsync(Expression<Func<T, bool>> predicate) => await DbSet.FirstOrDefaultAsync(predicate);

        public virtual IQueryable<T> ListNoTracking(Expression<Func<T, bool>> predicate) =>
            DbSet.Where(predicate).AsNoTracking();

        public virtual async Task<T> AddAsync(T entity)
        {
            var ret = await DbSet.AddAsync(entity);

            return ret.Entity;
        }

        public virtual void Delete(List<T> entity)
        {
            DbSet.RemoveRange(entity.AsEnumerable());
        }
    }
}
