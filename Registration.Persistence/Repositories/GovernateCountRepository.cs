using Microsoft.EntityFrameworkCore;
using Registration.Application.Persistence;
using Registration.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Persistence.Repositories
{
    public class GovernateCountRepository : GenericRepository<GovernateCount>, IGovernateCountRepository
    {
        public GovernateCountRepository(RegistrationContext context) : base(context)
        {
        }

        public async Task<GovernateCount> GetCountByGovernateId(Guid governateId)
        {
            return await _context.GovernateCount.FirstOrDefaultAsync(c => c.GovernateId == governateId);
        }
    }
}
