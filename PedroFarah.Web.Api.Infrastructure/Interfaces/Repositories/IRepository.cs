using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PedroFarah.Web.Api.Infrastructure.Interfaces.Repositories
{
    public interface IRepository<T> where T : class
    {
        DbSet<T> DbSet { get; set; }
        Task<T> GetAsync(Expression<Func<T, bool>> predicate);
        IQueryable<T> ListNoTracking(Expression<Func<T, bool>> predicate);
        Task<T> AddAsync(T entity);
        void Delete(List<T> entity);
    }
}
