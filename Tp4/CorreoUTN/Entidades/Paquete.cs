using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Paquete
    {
        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;

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
        #region Methods
        public Paquete(string direccionEntrega, string trackingId)
        {
            this.DireccionEntrega = direccionEntrega;
            this.TrackingId = trackingID;
        }

        public void MockCicloDeVida()
        {

        }

        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            return "";
        }

        public override string ToString()
        {
            return base.ToString();
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
        Ingresado,
        EnViaje,
        Entregado
    }
}
