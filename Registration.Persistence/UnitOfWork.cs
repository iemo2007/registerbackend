using Registration.Application.Persistence;
using Registration.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RegistrationContext _context;
        public IAccountRepository Accounts { get; private set; }
        public ICityRepository Cities { get; private set; }
        public IGovernateRepository Governates { get; private set; }
        public IGovernateCountRepository GovernateCount { get; private set; }

        public UnitOfWork(RegistrationContext context)
        {
            _context = context;
            Accounts = new AccountRepository(_context);
            Cities = new CityRepository(_context);
            Governates = new GovernateRepository(_context);
            GovernateCount = new GovernateCountRepository(_context);
        }

        public async Task<bool> Complete()
        {
            return (await _context.SaveChangesAsync() == 1);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
