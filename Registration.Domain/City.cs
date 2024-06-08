using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Domain
{
    public class City : BaseEntity
    {
        public string Name { get; set; }
        public Guid GovernateId { get; set; }
        public Governate Governate { get; set; }
    }
}
