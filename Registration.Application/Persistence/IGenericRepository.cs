using Registration.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Application.Persistence
{
    public interface IGenericRepository<T> where T : BaseEntity
    {       
        void Delete(T entity);
        void Update(T entity);
        Task CreateAsync(T entity);
        Task<T> GetByIdAsync(Guid id);
        Task<List<T>> GetAsync();
    }
}
