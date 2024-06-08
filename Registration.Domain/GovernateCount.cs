using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Domain
{
    public class GovernateCount: BaseEntity
    {
        public int Count { get; set; }

        public Guid GovernateId { get; set; }
        public Governate Governate { get; set; }
    }
}
