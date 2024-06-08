using Registration.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Application.Features.AccountFeatures.Commands.CreateAccount
{
    public class CreateAccountCommandDTO
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public List<CreateAccountCommandAddressDTO> Addresses { get; set; }
    }

    public class CreateAccountCommandAddressDTO
    {
        public string Street { get; set; }
        public string BuildingNumber { get; set; }
        public int FlatNumber { get; set; }

        public Guid GovernateId { get; set; }
        public Guid CityId { get; set; }
    }
}
