using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClasesAbstractas;

namespace ClasesInstanciables
{
    public sealed class Alumno : Universitario
    {
        #region Campos
        Universidad.EClases claseQueToma;
        Alumno.EEstadoDeCuenta estadoCuenta;
        #endregion

        #region Metodos
        public Alumno()
        {

        }

        public Alumno(int id, string nombre, 
            string apellido, string dni, Persona.ENacionalidad nacionalidad, Universidad.EClases claseQueToma)
            :base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }

        Alumno(int id, string nombre,
           string apellido, string dni,
           Persona.ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoDeCuenta estadoCuenta)
            :this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
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

        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            return true;
        }

        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            return !(a==clase);
        }
        #endregion


        #region Tipos Anidados
        public enum EEstadoDeCuenta
        {
            AlDia,
            Deudor,
            Becado
        }
        #endregion
    }
}
