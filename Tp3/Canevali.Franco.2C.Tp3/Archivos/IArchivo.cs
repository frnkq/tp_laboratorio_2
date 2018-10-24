using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    interface IArchivo<T>
    {
        #region Methods
        bool Guardar(string archivo, T datos);
        bool Leer(string archivo, T datos);
        #endregion
    }
}
