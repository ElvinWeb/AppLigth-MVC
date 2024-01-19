using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLight.Business.CustomExceptions.WorkerImage
{
    public class InvalidImageContentTypeOrSize : Exception
    {
        public string PropertyName { get; set; }
        public InvalidImageContentTypeOrSize()
        {

        }

        public InvalidImageContentTypeOrSize(string? message) : base(message)
        {
        }

        public InvalidImageContentTypeOrSize(string propName, string? message) : base(message)
        {
            PropertyName = propName;
        }
    }
}
