using System;
using System.Linq;
using System.Threading.Tasks;

namespace domain_project.domain.SeedWork
{
    public interface IRead<T> where T : IAggregateRoot
    {
        IQueryable<T> GetAsQueryable();
        Task<T> GetByIdAsync(int id);
    }

}