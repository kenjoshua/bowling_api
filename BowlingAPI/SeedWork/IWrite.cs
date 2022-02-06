using System;
using System.Threading.Tasks;

namespace domain_project.domain.SeedWork
{
    public interface IWrite<T> where T : IAggregateRoot
    {
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(int id);
    }
}

