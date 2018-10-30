using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesAbstractas
{
    public abstract class Universitario : Persona
    {
        #region Campos
        private int legajo;
        #endregion

        #region Metodos
        /// <summary>
        /// Constructor por defecto de universitario
        /// </summary>
        public Universitario()
        {

        }

        /// <summary>
        /// Constructor publico de universitario que establece el legajo, nombre, apellido, dni y nacionalidad
        /// </summary>
        /// <param name="legajo">Legajo a establecer en el campo this.legajo</param>
        /// <param name="nombre">Nombre a establecer en el campo base.nombre</param>
        /// <param name="apellido">Apellido a establecer en el campo base.apellido</param>
        /// <param name="dni">Dni a establecer en el campo base.dni</param>
        /// <param name="nacionalidad">Nacionalidad a establecer en el campo base.nacionalidad</param>
        public Universitario(int legajo, string nombre,
            string apellido, string dni, ENacionalidad nacionalidad)
            :base(nombre, apellido, nacionalidad)
        {
            this.legajo = legajo;
        }

        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("Universitario");
            sb.AppendLine(String.Format("Legajo n°: {0}", this.legajo);

            return sb.ToString();
        }

        protected abstract string ParticiparEnClase();

        /// <summary>
        /// Dos Universitario serán iguales si y sólo si son del mismo Tipo y su Legajo o DNI son iguales
        /// </summary>
        /// <param name="obj">Objeto a comparar con this</param>
        /// <returns>True si cumple con las condiciones, false de lo contrario</returns>
        public override bool Equals(object obj)
        {
            if(obj.GetType() == this.GetType())
            {
                if(((Universitario)obj).legajo == this.legajo ||
                ((Universitario)obj).DNI == this.DNI)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Utilizando Equals() verifica si dos universitarios son iguales
        /// </summary>
        /// <param name="pg1">Universitario a comparar con pg2</param>
        /// <param name="pg2">Universitario a comparar con pg1</param>
        /// <returns>True si son iguales, false si no lo son</returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            return pg1.Equals(pg2);
        }

        /// <summary>
        /// Utilizando el operador == verifica si dos universitarios son iguales
        /// </summary>
        /// <param name="pg1">Universitario a comparar con pg2</param>
        /// <param name="pg2">Universitario a comparar con pg1</param>
        /// <returns>False si son iguales, true si no lo son</returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }
        #endregion
    }
}
