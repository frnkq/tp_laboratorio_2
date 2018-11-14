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

        public void MockCicloDeVida()
        {
            do
            {
                InformaEstado.Invoke(this, null);
                System.Threading.Thread.Sleep(10000);

                //Recorre los distintos tipos de estado hasta el ultimo
                this.Estado = ((EEstado)((int)this.Estado) + 1);
            } while (this.Estado != EEstado.Entregado);

            try
            {
                PaqueteDAO.Insertar(this);
            }
            catch(Exception dbException)
            {
                ErrorBaseDeDatos.Invoke(dbException, null);
            }

            InformaEstado.Invoke(this, null);
             
        }

        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            Paquete p = (Paquete)elemento;
            return String.Format("{0} para {1}", p.trackingID, p.direccionEntrega);
        }

        public override string ToString()
        {
            return this.MostrarDatos(this);
        }

        public static bool operator ==(Paquete p1, Paquete p2)
        {
            return p1.TrackingId.Equals(p2.TrackingId);
        }

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
