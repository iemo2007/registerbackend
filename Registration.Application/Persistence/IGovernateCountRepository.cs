using Registration.Domain;
using System;
using System.Threading.Tasks;

namespace Registration.Application.Persistence
{
    public interface IGovernateCountRepository : IGenericRepository<GovernateCount>
    {
        public Task<GovernateCount> GetCountByGovernateId(Guid governateId);
    }
}
