using Domain.Entities.Commons;
using Microsoft.EntityFrameworkCore;

namespace Application.Abstractions.Repositories;

public interface IBaseRepository<T> where T : BaseEntity
{
    DbSet<T> Table { get;}
    Task<T> GetAsync(Guid id);
    Task<IQueryable<T>> GetAllAsync();
    Task<T> AddAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task<T> DeleteAsync(Guid id);
    Task<int> SaveAsync();

}
