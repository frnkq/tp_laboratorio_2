using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Excepcion pensada para reflejar que dos Paquetes tienen el mismo trackingId
    /// </summary>
    public class TrackingIdRepetidoException : Exception
    {
        public TrackingIdRepetidoException(string mensaje) : base(mensaje)
        {

        }
        public TrackingIdRepetidoException(string mensaje, Exception inner) : base(mensaje, inner)
        {

        }
    }
}
