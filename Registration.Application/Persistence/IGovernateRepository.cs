using Registration.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Registration.Application.Persistence
{
    public interface IGovernateRepository : IGenericRepository<Governate>
    {
        Task<List<Governate>> AllWithCities();
    }
}
