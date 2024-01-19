using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace finalexam.business.Exceptions
{
    public class InvalidAuthException:Exception
    {
        public string PropertyName { get; set; }
        public InvalidAuthException()
        {

        }
        public InvalidAuthException(string? message) : base(message)
        {

        }
        public InvalidAuthException(string propertyname, string? message) : base(message)
        {
            PropertyName = propertyname;
        }
    }
}
