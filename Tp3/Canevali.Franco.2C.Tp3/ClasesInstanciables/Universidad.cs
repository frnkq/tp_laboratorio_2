using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesInstanciables
{
    public class Universidad
    {
        #region Campos
        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;
        #endregion

        #region Propiedades
        public Jornada this[int i]
        {
            get
            {
                return this.jornada[i];
            }
            set
            {
                this.jornada[i] = value;
            }
        }

        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }
            set
            {
                this.alumnos = value;
            }
        }


        public List<Profesor> Instructores
        {
            get
            {
                return this.profesores;
            }
            set
            {
                this.profesores = value;
            }
        }

        private List<Jornada> Jornadas
        {
            get
            {
                return this.jornada;
            }
            set
            {
                this.jornada = value;
            }
        }
        #endregion

        #region Metodos
        public Universidad()
        {

        }

        public bool Guardar()
        {
            return false;
        }

        private string MostrarDatos(Universidad uni)
        {
            StringBuilder sb = new StringBuilder();

            return sb.ToString();
        }

        public override string ToString()
        {
            return MostrarDatos(this);
        }

        public static bool operator ==(Universidad g, Alumno a)
        {
            return false;
        }

        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g==a);
        }

        public static bool operator ==(Universidad g, Profesor i)
        {
            return false;
        }

        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g==i);
        }

        public static Profesor operator ==(Universidad u, EClases clase)
        {
            return new ClasesInstanciables.Profesor(3,"","","",ClasesAbstractas.Persona.ENacionalidad.Argentino);
        }

        public static Profesor operator !=(Universidad u, EClases clase)
        {
            return u==clase;
        }

        public static Universidad operator +(Universidad g, EClases clase)
        {
            return g;
        }

        public static Universidad operator +(Universidad u, Alumno a)
        {
            return u;
        }

        public static Universidad operator +(Universidad u, Profesor i)
        {
            return u;
        }
        #endregion

        #region Tipos Anidados
        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }
        #endregion
    }
}
