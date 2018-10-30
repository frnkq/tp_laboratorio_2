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
        private Random random;
        #endregion

        #region Metodos
        private Profesor()
        {
            clasesDelDia = new Queue<Universidad.EClases>();    
        }

        public Profesor(int id, string nombre,
            string apellido, string dni, Persona.ENacionalidad nacionalidad)
            :base(id, nombre, apellido, dni, nacionalidad)
        {

        }

        private void _randomClases()
        {

        }

        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();

            return sb.ToString();
        }

        protected string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            return sb.ToString();
        }

        public override string ToString()
        {
            return this.MostrarDatos();
        }

        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            return true;
        }

        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i==clase);
        }
        #endregion
    }
}
