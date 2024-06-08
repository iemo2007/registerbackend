using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Domain
{
    public class Governate : BaseEntity
    {
        public Governate()
        {
            Cities = new List<City>();
        }

        public string Name { get; set; }
        public List<City> Cities { get; set; }
    }
}
