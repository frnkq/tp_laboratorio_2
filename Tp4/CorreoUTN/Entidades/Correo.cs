using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace Entidades
{
    public class Correo : IMostrar<List<Paquete>>
    {
        #region Fields
        private List<Thread> mockPaquetes;
        private List<Paquete> paquetes;
        #endregion

        #region Properties

        /// <summary>
        /// Propiedad r/w de this.paquetes
        /// </summary>
        public List<Paquete> Paquetes
        {
           get
            {
                return this.paquetes;
            }
            set
            {
                this.paquetes = value;
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Constructor por defecto de Correo, encargado de inicializar las listas this.mockPaquetes y this.paquetes
        /// </summary>
        public Correo()
        {
            this.mockPaquetes = new List<Thread>();
            this.paquetes = new List<Paquete>();
        }


        /// <summary>
        /// Metodo encargado de finalizar todos los hilos abiertos en la lista this.mockPaquetes
        /// </summary>
        public void FinEntregas()
        {
            foreach(Thread t in this.mockPaquetes)
            {
                if (t.IsAlive)
                {
                    try
                    {
                        t.Abort();
                    }
                    catch(ThreadAbortException e)
                    {

                    }
                }
            }
        }

        /// <summary>
        /// Retorna los datos de todos los paquetes de this.paquetes
        /// </summary>
        /// <param name="elementos">Objeto que utiliza la interfaz IMostrar<List<Paquete>></param>
        /// <returns>Los datos de todos los paquetes de this.paquetes en formato string</returns>
        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            StringBuilder sb = new StringBuilder();
            string datosPaquete;
            List<Paquete> listaPaquetes = (List<Paquete>)((Correo)elementos).paquetes;

            foreach (Paquete p in listaPaquetes)
            {
                datosPaquete = String.Format("{0} para {1} ({2})", p.TrackingId, p.DireccionEntrega, p.Estado.ToString());
                sb.AppendLine(datosPaquete);
            }
            return sb.ToString();
        }

        /// <summary>
        /// Operador encargado de:
        /// agregar un paquete a this.Paquetes si este no fue agregado previamente, 
        /// crear un hilo para el metodo MockCicloDeVida de dicho paquete
        /// y de agregar ese hilo a this.mockPaquetes
        /// </summary>
        /// <param name="c">Correo donde se intentara agregar el Paquete p y su MockCicloDeVida</param>
        /// <param name="p">Paquete a intentar agregar en Correo c</param>
        /// <returns></returns>
        public static Correo operator +(Correo c, Paquete p)
        {
            foreach(Paquete paquete in c.Paquetes)
            {
                if(paquete == p)
                {
                    throw new TrackingIdRepetidoException("El tracking ID "+p.TrackingId+" ya figura en la lista de envios");
                }
            }
            c.Paquetes.Add(p);
            Thread hiloPaquete = new Thread(p.MockCicloDeVida);
            c.mockPaquetes.Add(hiloPaquete);
            hiloPaquete.Start();
            return c;
        }
        #endregion
    }
}
