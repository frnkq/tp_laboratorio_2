using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClasesAbstractas;
namespace ClasesInstanciables
{
    public sealed class Profesor : Universitario
    {
        #region Campos
        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;
        #endregion

        #region Metodos
        /// <summary>
        /// Constructor por defecto que se utilizara para inicializar la Queue clasesDelDia y Random random.
        /// Ejecutará el método _randomClases para popular 
        /// </summary>
        /// 
        
        static Profesor()
        {
            random = new Random();
        }
      
        private Profesor()
        {
            
        }

        /// <summary>
        /// Constructor de Profesor que establece el id, nombre, apellido, dni y nacionalidad
        /// </summary>
        /// <param name="id">Id a establecer en base.legajo</param>
        /// <param name="nombre">Nombre a establecer en base.nombre</param>
        /// <param name="apellido">Apellido a establecer en base.apellido</param>
        /// <param name="dni">Dni a establecer en base.dni</param>
        /// <param name="nacionalidad">Nacionalidad a establecer en base.nacionalidad</param>
        public Profesor(int id, string nombre,
            string apellido, string dni, Persona.ENacionalidad nacionalidad)
            :base(id, nombre, apellido, dni, nacionalidad)
        {
            clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
        }

        /// <summary>
        /// Asignará dos clases al azar al Profesor
        /// </summary>
        private void _randomClases()
        {
            //no utilizo for porque son solo dos veces?
            this.clasesDelDia.Enqueue((Universidad.EClases)random.Next(3));
            System.Threading.Thread.Sleep(500);
            this.clasesDelDia.Enqueue((Universidad.EClases)random.Next(3));
        }

        /// <summary>
        /// Retornará la cadena "CLASES DEL DÍA" junto al nombre de la clases que da.
        /// </summary>
        /// <returns>string "CLASES DEL DIA" junto al nombre de las clases de clasesDelDia</returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Clases del dia: ");
            foreach (Universidad.EClases clase in this.clasesDelDia)
            {
                sb.Append(" " + clase.ToString());
            }
            return sb.ToString();
        }

        /// <summary>
        /// Devuelve todos los datos del profesor en un string utilizando this.ToString();
        /// </summary>
        /// <returns>Todos los datos del profesor</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("-->Profesor");
            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine(this.ParticiparEnClase());
            return sb.ToString();
        }

        /// <summary>
        /// Devuelve todos los datos del profesor
        /// </summary>
        /// <returns>Todos los datos del profesor</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }


        /// <summary>
        /// Un Profesor será igual a un EClase si da esa clase.
        /// </summary>
        /// <param name="i">Profesor en el cual se buscará la EClase clase</param>
        /// <param name="clase">EClase clase a buscar en la lista de clases de Profesor i</param>
        /// <returns>True si la EClase se encuentra en la lista de clases de Profesor i, false de lo contrario</returns>
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            foreach(Universidad.EClases claseDelDia in i.clasesDelDia)
            {
                if (clase == claseDelDia)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Un Profesor será igual a un EClase si da esa clase.
        /// </summary>
        /// <param name="i">Profesor en el cual se buscará la EClase clase</param>
        /// <param name="clase">EClase clase a buscar en la lista de clases de Profesor i</param>
        /// <returns>False si la EClase se encuentra en la lista de clases de Profesor i, true de lo contrario</returns>
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i==clase);
        }
        #endregion
    }
}
