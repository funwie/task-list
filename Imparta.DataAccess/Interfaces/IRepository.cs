using Imparta.Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Imparta.DataAccess.Interfaces
{
    public interface IRepository<T> where T : Entity
    {
        Task<IList<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid Id);
        Task<List<T>> FindAsync<T2>(Expression<Func<T, bool>> predicate, Expression<Func<T, T2>> order);
        Task<T> AddAsync(T Item);
        Task AddAllAsync(IEnumerable<T> Items);
        Task UpdateAsync(T Item);
        Task UpdateAllAsync(IEnumerable<T> Items);
        Task DeleteAsync(Guid PrimaryKey);
    }
}
