using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public delegate void DelegadoEstado(Object sender, EventArgs e);
    public class Paquete : IMostrar<Paquete>
    {
        #region Fields
        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;
        public event DelegadoEstado InformaEstado;
        public event DelegadoEstado ErrorBaseDeDatos;
        #endregion

        #region Properties
        /// <summary>
        /// Propiedad r/w para this.direccionEntrega
        /// </summary>
        public string DireccionEntrega
        {
            get
            {
                return this.direccionEntrega;
            }
            set
            {
                this.direccionEntrega = value;
            }
        }

        /// <summary>
        /// Propiedad r/w para this.estado
        /// </summary>
        public EEstado Estado
        {
            get
            {
                return this.estado;
            }
            set
            {
                this.estado = value;
            }
        }

        /// <summary>
        /// Propiedad r/w para this.trackingId
        /// </summary>
        public string TrackingId
        {
            get
            {
                return this.trackingID;
            }
            set
            {
                this.trackingID = value;
            }
        }
        #endregion


        #region Methods
        /// <summary>
        /// Constructor por defecto de paquete, que establece la direccionEntrega y el trackingID
        /// </summary>
        /// <param name="direccionEntrega">Valor a establecer en this.direccionEntrega</param>
        /// <param name="trackingId">Valor a establecer en this.TrackingID</param>
        public Paquete(string direccionEntrega, string trackingId)
        {
            this.DireccionEntrega = direccionEntrega;
            this.TrackingId = trackingId;
            this.Estado = EEstado.Ingresado;
        }

        /// <summary>
        /// Metodo que emula el ciclo de vida de un paquete, 
        /// cambiando this.Estado estado secuencialmente segun indica el enumerado EEstado,
        /// cada 10 segundos. Invocando al evento InformaEstado en cada paso, y guardando
        /// el paquete en la base de datos al llegar al último elemento del enumerado,
        /// utilizando la clase PaqueteDAO
        /// </summary>
        public void MockCicloDeVida()
        {
            do
            {
                InformaEstado.Invoke(this, null);
                System.Threading.Thread.Sleep(10000);

                //Recorre los distintos tipos de estado hasta el ultimo
                this.Estado++;
            } while (this.Estado != EEstado.Entregado);

            //Inserta en base de datos
            try
            {
                PaqueteDAO.Insertar(this);
            }
            //Si hay excepcion, invoca el evento ErrorBaseDeDatos con un diccionario <paquete, excepcion>
            catch(Exception dbException)
            {

                Dictionary<Paquete, Exception> exceptionPaquete = new Dictionary<Paquete, Exception>()
                {
                    {this, dbException}
                };
                
                ErrorBaseDeDatos.Invoke(exceptionPaquete, null);
            }

            InformaEstado.Invoke(this, null);
        }

        /// <summary>
        /// Devuelve los datos del paquete en formato: (trackingId) para (direccionEntrega)
        /// </summary>
        /// <param name="elemento">Paquete deol cual se obtendran los elementos</param>
        /// <returns></returns>
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            Paquete p = (Paquete)elemento;
            return String.Format("{0} para {1}", p.trackingID, p.direccionEntrega);
        }

        /// <summary>
        /// Devuelve el metodo MostrarDatos()
        /// </summary>
        /// <returns>El metodo MostrarDatos()</returns>
        public override string ToString()
        {
            return this.MostrarDatos(this);
        }

        /// <summary>
        /// Dos paquetes seran iguales si tienen el mismo tracking id
        /// </summary>
        /// <param name="p1">Paquete a comparar con p2</param>
        /// <param name="p2">Paquete a comparar con p1</param>
        /// <returns>True si son iguales, false si no lo son</returns>
        public static bool operator ==(Paquete p1, Paquete p2)
        {
            return p1.TrackingId.Equals(p2.TrackingId);
        }

        /// <summary>
        /// Dos paquetes seran distintos si tienen un trackingId distinto
        /// </summary>
        /// <param name="p1">Paquete a comparar con p2</param>
        /// <param name="p2">Paquete a comparar con p1</param>
        /// <returns>True si son distintos, false si no lo son</returns>
        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }
        #endregion
    }

    public enum EEstado
    {
        Ingresado = 0,
        EnViaje,
        Entregado
    }
}
