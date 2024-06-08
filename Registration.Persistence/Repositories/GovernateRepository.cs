using Microsoft.EntityFrameworkCore;
using Registration.Application.Persistence;
using Registration.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Persistence.Repositories
{
    public class GovernateRepository : GenericRepository<Governate>, IGovernateRepository
    {
        public GovernateRepository(RegistrationContext context) : base(context)
        {
            
        }

        public async Task<List<Governate>> AllWithCities()
        {
            List<Governate> governates = await _context.Governates.Include(g => g.Cities).ToListAsync();
            return governates;
        }
    }
}
