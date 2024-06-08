using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Application.Exceptions
{
    public class NotFoundException: Exception
    {
        public NotFoundException(string typeName, Guid key): base($"{typeName} with id '{key}' wasn't found")
        {
            
        }
    }
}
