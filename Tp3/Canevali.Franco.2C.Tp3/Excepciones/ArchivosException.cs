using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    class ArchivosException : Exception
    {
        public ArchivosException()
        {
        }
        public ArchivosException(string message) : base(message)
        {
        }
        public ArchivosException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
