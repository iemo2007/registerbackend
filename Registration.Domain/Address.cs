using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Domain
{
    public class Address : BaseEntity
    {
        public string Street { get; set; }
        public string BuildingNumber { get; set; }
        public int FlatNumber { get; set; }

        public Guid CityId { get; set; }
        public City City { get; set; }
        
        public Guid AccountId { get; set; }
        public Account Account { get; set; }
    }
}
