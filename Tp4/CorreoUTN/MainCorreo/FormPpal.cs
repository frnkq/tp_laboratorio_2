using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using Entidades;
namespace MainCorreo
{
    public partial class FormPpal : Form
    {
        public Correo correo;
        public FormPpal()
        {
            InitializeComponent();
            this.correo = new Correo();
            this.rtbMostrar.Enabled = false;

        }

        /// <summary>
        /// Crea un paquete con los parametros this.mtxtTrackingId.Text y this.txtDireccion.Text respectivamente
        /// y luego lo agrega a this.correo utilizando el operador correo + paquete
        /// capturando la excepcion TrackingIdRepetidoException, mostrando una alerta mediante un MessageBox en caso de ocurrirse
        /// Finalmente llama al metodo this.mtxtTrackingId.Clear()
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Paquete paquete = new Paquete(this.mtxtTrackingId.Text, this.txtDireccion.Text);

            
            paquete.InformaEstado += paq_InformaEstado;
            paquete.ErrorBaseDeDatos += paq_ErrorBaseDeDatos;

            try
            {
                correo += paquete;
            }
            catch (TrackingIdRepetidoException ex)
            {
                MessageBox.Show(ex.Message, "Paquete repetido");
            }

            this.mtxtTrackingId.Clear();
            this.txtDireccion.Clear();
        }

        /// <summary>
        /// Metodo que va a ser llamado por el evento Paquete.InformaEstado
        /// Llama a this.ActualizarEstados()
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void paq_InformaEstado(Object sender, EventArgs e)
        {
            if(this.InvokeRequired)
            {
                DelegadoEstado d = new DelegadoEstado(paq_InformaEstado);
                this.Invoke(d,new object[] { sender, e });
            }
            else
            {
                ActualizarEstados();
            }
        }

        /// <summary>
        /// Actualiza las listas de paquetes segun corresponda
        /// </summary>
        public void ActualizarEstados()
        {

            //Limpia las listas de paquetes
            this.lstEstadoIngresado.Items.Clear();
            this.lstEstadoEnViaje.Items.Clear();
            this.lstEstadoEntregado.Items.Clear();
            
            //Agrega los paquetes a las listas segun su estado determine
            foreach(Paquete p in correo.Paquetes)
            {
                switch (p.Estado)
                {
                    case EEstado.Ingresado:
                        this.lstEstadoIngresado.Items.Add(p);
                        break;
                    case EEstado.EnViaje:
                        this.lstEstadoEnViaje.Items.Add(p);
                        break;
                    case EEstado.Entregado:
                        this.lstEstadoEntregado.Items.Add(p);
                        break;
                }
            }
        }


        /// <summary>
        /// Metodo asociado al evento ErrorBaseDeDatos, encargado de llamar al metodo
        /// NotificarErrorBaseDeDatos con el parametro sender, siendo este la excepcion
        /// ocurrida en la clase PaqueteDAO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void paq_ErrorBaseDeDatos(Object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                DelegadoEstado d = new DelegadoEstado(paq_ErrorBaseDeDatos);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                NotificarErrorBaseDeDatos(sender);
            }
        }

        /// <summary>
        /// Visualiza mediante un MessageBox la posible excepcion lanzada por PaqueteDAO, referente a
        /// la relacion entre el programa y la base de datos
        /// </summary>
        /// <param name="sender"></param>
        public void NotificarErrorBaseDeDatos(object sender)
        {
            string trackingPaquete = (((Dictionary<Paquete, Exception>)sender).First()).Key.TrackingId;
            string error = (((Dictionary<Paquete, Exception>)sender).First()).Value.Message;

            string formatedError = String.Format("Hubo un error a la hora de insertar el paquete trackingID: '{0}' en la base de datos: \n\n {1}",
                trackingPaquete, error);

            MessageBox.Show(formatedError, "Problema con la base de datos");
        }

        /// <summary>
        /// Imprime la informacion de todos los paquetes de la lista this.correo.Paquetes en this.rtbMostrar
        /// y guarda dicha informacion en un archivo mediante el metodo de extension Entidades.GuardaString()
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="elementos">Correo del cual se espera obtener la lista de paquetes</param>
        public void MostrarInformacion<T>(IMostrar<T> elementos)
        {
            
            if (elementos != null)
            {
                Correo correo = (Correo)elementos;
                StringBuilder sb = new StringBuilder();

                foreach (Paquete p in correo.Paquetes)
                {
                    string datos = String.Format("{0} ({1})", p.ToString(), p.Estado.ToString());

                    sb.AppendLine(datos);

                    datos.Guardar("salida.txt");
                }

                this.rtbMostrar.Text = sb.ToString();
            }
        }


        /// <summary>
        /// Muestra la información del paquete seleccionado de this.lstEstadoEntregado
        /// utilizando paquete.ToString(), en this.rtbMostrar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mostrarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                Paquete p = (Paquete)this.lstEstadoEntregado.SelectedItem;
                this.rtbMostrar.Text = String.Format("{0}", p.ToString());
            }
            catch(Exception)
            {

            }
            
        }

        /// <summary>
        /// Evento que llama a this.MostrarInformacion() pasandole por parametro this.correo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }

    }
}
