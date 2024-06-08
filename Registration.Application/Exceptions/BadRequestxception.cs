using System;

namespace Registration.Application.Exceptions
{
    public class BadRequestxception : Exception
    {
        public BadRequestxception(string message) : base(message)
        {

        }
    }
}
