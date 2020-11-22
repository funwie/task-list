using Imparta.DataAccess.Interfaces;
using Imparta.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Imparta.DataAccess.Implementations
{
    public class BaseRepository<T> : IRepository<T> where T : Entity
    {
        protected TaskDbContext _context;

        public BaseRepository(TaskDbContext context)
        {
            _context = context;
        }

        public virtual async Task<T> AddAsync(T Item)
        {
            var tackedItem = _context.Set<T>().Add(Item);
            await _context.SaveChangesAsync();
            return tackedItem.Entity;
        }

        public virtual async Task AddAllAsync(IEnumerable<T> Items)
        {
            _context.Set<T>().AddRange(Items);
            await _context.SaveChangesAsync();
        }


        public virtual async Task DeleteAsync(Guid Id)
        {
            _context.Set<T>().Remove(await GetByIdAsync(Id));
            await _context.SaveChangesAsync();
        }

        public virtual async Task<List<T>> FindAsync<T2>(Expression<Func<T, bool>> predicate, Expression<Func<T, T2>> order)
        {
            return await _context.Set<T>().AsNoTracking().Where(predicate).OrderBy(order).ToListAsync();
        }

        public virtual async Task<IList<T>> GetAllAsync()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }

        public virtual async Task<T> GetByIdAsync(Guid Id)
        {
            return await _context.Set<T>().FindAsync(Id);
        }

        public virtual async Task UpdateAllAsync(IEnumerable<T> Items)
        {
            _context.Set<T>().UpdateRange(Items);
            await _context.SaveChangesAsync();
        }

        public virtual async Task UpdateAsync(T Item)
        {
            _context.Set<T>().Update(Item);
            await _context.SaveChangesAsync();
        }
    }
}
