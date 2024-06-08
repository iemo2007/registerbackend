using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Application.DTOs.Exceptions
{
    public class ValidationsException: Exception
    {
        List<string> ValidationErrors { get; set; }
        public ValidationsException(List<string> errors)
        {
            ValidationErrors = errors;
        }
    }
}
