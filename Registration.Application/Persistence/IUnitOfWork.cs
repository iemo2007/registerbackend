using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Application.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        IAccountRepository Accounts { get; }
        ICityRepository Cities { get; }
        IGovernateRepository Governates { get; }
        IGovernateCountRepository GovernateCount { get; }
        Task<bool> Complete();
    }
}
