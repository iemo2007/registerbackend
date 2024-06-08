using Registration.Application.Persistence;
using Registration.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Persistence.Repositories
{
    public class AccountRepository : GenericRepository<Account>, IAccountRepository
    {
        public AccountRepository(RegistrationContext context): base(context)
        {
        }
        public bool IsEmailUnique(string email)
        {
            return !_context.Accounts.Any(a => a.Email == email);
        }

        public bool IsMobileNumberUnique(string mobileNumber)
        {
            return !_context.Accounts.Any(a => a.MobileNumber == mobileNumber);
        }
    }
}
