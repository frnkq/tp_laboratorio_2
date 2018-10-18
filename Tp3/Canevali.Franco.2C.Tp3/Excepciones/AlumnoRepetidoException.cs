using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    class AlumnoRepetidoException : Exception
    {
        public AlumnoRepetidoException()
        {
        }
        public AlumnoRepetidoException(string message) : base(message)
        {
        }
        public AlumnoRepetidoException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
