using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace Entidades
{
    public static class PaqueteDAO
    {
        private static SqlConnection _conexion;
        private static SqlCommand _comando;

        /// <summary>
        /// Inicializa la conexion
        /// Data source= .\SQLEXPRESS
        /// Base de datos: correo-sp-2017
        /// Integrated Security = true
        /// </summary>
        static PaqueteDAO()
        {
            string connectionString = "Data Source=.\\SQLEXPRESS; Initial Catalog=correo-sp-2017; Integrated Security=True;";
            _conexion = new SqlConnection(connectionString);
        }

        /// <summary>
        /// Inserta el Paquete p en la base de datos, con el agregado del campo 'Alumno'
        /// Tabla: direccionEntrega, trackingID, alumno
        /// Valores: p.DireccionEntrega, p.TrackingId, "Franco Canevali"
        /// </summary>
        /// <param name="p">Paquete del cual se obtendran sus datos para insertar en la base de datos</param>
        /// <returns>True si el paquete fue insertado correctamente</returns>
        public static bool Insertar(Paquete p)
        {
            try
            {
                _conexion.Open();
                string alumno = "Franco Canevali";
                string insertCommand = String.Format("INSERT INTO Paquetes (direccionEntrega,trackingID,alumno) " +
                                        "VALUES('{0}','{1}','{2}')", 
                                        p.DireccionEntrega, p.TrackingId, alumno);
                _comando = new SqlCommand(insertCommand, _conexion);
                _comando.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (_conexion != null)
                    _conexion.Close();
            }

        }

      
    }
}
