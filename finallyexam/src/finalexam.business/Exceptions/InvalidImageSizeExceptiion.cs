using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace finalexam.business.Exceptions
{
    public class InvalidImageSizeExceptiion:Exception
    {
        public string PropertyName { get; set; }
        public InvalidImageSizeExceptiion()
        {

        }
        public InvalidImageSizeExceptiion(string? message) : base(message)
        {

        }
        public InvalidImageSizeExceptiion(string propertyname, string? message) : base(message)
        {
            PropertyName = propertyname;
        }
    }
}
