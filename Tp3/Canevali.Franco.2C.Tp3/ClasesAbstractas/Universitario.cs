using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesAbstractas
{
    public abstract class Universitario : Persona
    {
        #region Fields
        private int legajo;
        #endregion

        #region Methods
        public Universitario()
        {

        }

        public Universitario(int legajo, string nombre,
            string apellido, string dni, ENacionalidad nacionalidad)
            :base(nombre, apellido, nacionalidad)
        {

        }

        protected string MostrarDatos()
        {
            return base.ToString();
        }

        protected string ParticiparEnClase()
        {
            return "";
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            return false;
        }

        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }
        #endregion
    }
}
