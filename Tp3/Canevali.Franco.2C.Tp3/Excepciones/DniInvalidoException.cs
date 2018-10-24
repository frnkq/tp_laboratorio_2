using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    class DniInvalidoException : Exception
    {
        public DniInvalidoException()
        {
        }
        public DniInvalidoException(Exception e) : base("removethis", e)
        {

        }
        public DniInvalidoException(string message) : base(message)
        {
        }
        public DniInvalidoException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
