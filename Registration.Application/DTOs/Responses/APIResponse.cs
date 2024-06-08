using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Application.DTOs.Responses
{
    public class APIResponse
    {
        public APIResponse(int statusCode, string message = null, string details = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetMessage(statusCode);
            Details = details;
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string Details { get; set; }

        private string GetMessage(int statusCode)
        {
            switch (statusCode)
            {
                case 400: return "You have made a bad request";
                case 401: return "You are not uthorized";
                case 403: return "Validation errors";
                case 404: return "The source is not found";
                case 500: return "An internal error occurred while handling the request";
                default: return null;
            }
        }
    }
}
