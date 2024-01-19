using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLight.Business.CustomExceptions.User
{
    public class InvalidCredentials : Exception
    {
        public string PropertyName { get; set; }
        public InvalidCredentials()
        {

        }

        public InvalidCredentials(string? message) : base(message)
        {
        }

        public InvalidCredentials(string propName, string? message) : base(message)
        {
            PropertyName = propName;
        }
    }
}
