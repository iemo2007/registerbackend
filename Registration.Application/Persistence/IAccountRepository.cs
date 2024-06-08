using Registration.Domain;
using System.Threading.Tasks;

namespace Registration.Application.Persistence
{
    public interface IAccountRepository: IGenericRepository<Account>
    {
        public bool IsEmailUnique(string email);
        public bool IsMobileNumberUnique(string mobileNumber);
    }
}
