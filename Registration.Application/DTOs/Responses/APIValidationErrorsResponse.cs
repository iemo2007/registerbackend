using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Application.DTOs.Responses
{
    public class APIValidationErrorsResponse : APIResponse
    {
        public List<string> Errors { get; set; }
        public APIValidationErrorsResponse(string statusCode) : base(403)
        {
            Errors = new List<string>();
        }
    }
}
