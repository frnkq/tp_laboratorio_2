using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    class Texto : IArchivo<string>
    {
        public bool Guardar(string archivo, string datos)
        {
            throw new NotImplementedException();
        }

        public bool Leer(string archivo, string datos)
        {
            throw new NotImplementedException();
        }
    }
}
