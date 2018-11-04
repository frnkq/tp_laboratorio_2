using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using Archivos;
namespace ClasesInstanciables
{
    [Serializable]
    public class Universidad
    {
        #region Campos
        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;
        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad para acceder a una jornada específica a través de un indexador
        /// </summary>
        /// <param name="i">Numero entero utilizado como índice</param>
        /// <returns></returns>
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

        /// <summary>
        /// Propiedad read/write de this.alumnos
        /// </summary>
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


        /// <summary>
        /// Propiedad read/write de this.instructores
        /// </summary>
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

        /// <summary>
        /// Propiedad read/write de this.jornadas
        /// </summary>
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
        /// <summary>
        /// Constructor por defecto de Universidad,
        /// inicializa las listas: alumnos, profesores y jornadas
        /// </summary>
        public Universidad()
        {
            this.alumnos = new List<Alumno>();
            this.profesores = new List<Profesor>();
            this.jornada = new List<Jornada>();
        }

        /// <summary>
        /// Metodo que permite la serializacion de la universidad en formato XML
        /// utilizando Archivos.Xml.Guardar() en un archivo nombrado "FrancoCanevali.Tp3.universidad.cs"
        /// en el escritorio.
        /// </summary>
        /// <param name="uni">Universidad a serializar</param>
        /// <returns>True si la universidad pudo ser serializada, false de lo contrario</returns>
        public static bool Guardar(Universidad uni)
        {
            Xml<Universidad> xml = new Xml<Universidad>();
            string fileName = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) +
                             "\\FrancoCanevali.Tp3.universidad.cs";
            try
            {
                xml.Guardar(fileName, uni);
                return true;
            }
            catch(Exception e)
            { 
                return false;
            }
        }

        /// <summary>
        /// Metodo encargado de exponer los datos de la Universidad en formato string
        /// </summary>
        /// <param name="uni">Universidad de la cual se obtendran los datos</param>
        /// <returns>Los datos de la universidad</returns>
        private string MostrarDatos(Universidad uni)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Jornadas");
            foreach (Jornada j in this.jornada)
                sb.AppendLine(j.ToString());
            return sb.ToString();
        }

        /// <summary>
        /// Devuelve el metodo this.MostrarDatos()
        /// </summary>
        /// <returns>Los datos de la universidad</returns>
        public override string ToString()
        {
            return MostrarDatos(this);
        }

        /// <summary>
        /// Una universidad será igual a un alumno si este se encuentra inscripto en la misma
        /// </summary>
        /// <param name="g">Universidad donde se buscará Alumno a</param>
        /// <param name="a">Alumno a buscar en Universidad g</param>
        /// <returns>True si el alumno se encuentra en la universidad, false de lo contrario</returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            foreach (Alumno al in g.Alumnos)
                if (al == a)
                    return true;

            return false;
        }

        /// <summary>
        /// Una universidad será distinta a un alumno si este no se encuentra inscripto en la misma
        /// </summary>
        /// <param name="g">Universidad donde se buscará Alumno a</param>
        /// <param name="a">Alumno a buscar en Universidad g</param>
        /// <returns>False si el alumno se encuentra en la universidad, true de lo contrario</returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g==a);
        }

        /// <summary>
        /// Una universidad será igual a un profesor si el mismo da clases en ella.
        /// </summary>
        /// <param name="g">Universidad donde se buscará Profesor i</param>
        /// <param name="i">Profesor a buscar en Universidad g</param>
        /// <returns>True si el profesor se encuentra en la lista profesores, false de lo contrario</returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            foreach (Profesor prof in g.Instructores)
                if (prof == i)
                    return true;
            return false;
        }

        /// <summary>
        /// Una universidad será distinta a un profesor si el mismo no da clases en ella.
        /// </summary>
        /// <param name="g">Universidad donde se buscará Profesor i</param>
        /// <param name="i">Profesor a buscar en Universidad g</param>
        /// <returns>False si el profesor se encuentra en la lista profesores, true de lo contrario</returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g==i);
        }

        /// <summary>
        /// Una universidad será igual a una clase si hay un profesor capaz de dar esta clase
        /// Si no, lanzará SinProfesorException()
        /// </summary>
        /// <param name="u">Universidad de donde se obtendrán los profesores a analizar</param>
        /// <param name="clase">Clase a comparar con cada profesor</param>
        /// <returns>El primer profesor capaz de dar la clase si existe</returns>
        public static Profesor operator ==(Universidad u, EClases clase)
        {
            foreach (Profesor prof in u.Instructores)
                if (prof == clase)
                    return prof;

            throw new SinProfesorException("Clase sin profesor");
        }

        /// <summary>
        /// El operador != devolverá el primer profesor de la lista 'profesores' incapaz de dar la clase
        /// </summary>
        /// <param name="u">Universidad de donde se obtendrán los profesores a analizar</param>
        /// <param name="clase">Clase a comparar con cada profesor</param>
        /// <returns>El primer profesor capaz de dar la clase si existe</returns>
        public static Profesor operator !=(Universidad u, EClases clase)
        {
            foreach (Profesor prof in u.Instructores)
                if (prof != clase)
                    return prof;

            throw new SinProfesorException("Jornada sin profesor");
        }

        /// <summary>
        /// Al agregar una clase a un Universidad se deberá generar y agregar una nueva Jornada 
        /// indicando la clase, un Profesor que pueda darla (según su atributo ClasesDelDia) 
        /// y la lista de alumnos que la toman (todos los que coincidan en su campo ClaseQueToma).
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {
            Profesor profesor;
            Jornada jornada;

            ///Se trae el primer profesor capaz de dar esa clase si existe
            try
            {
                profesor = g == clase;
            }
            catch (SinProfesorException e)
            {
                throw e;
            }
                       
            //Creo una jornada con esa clase y ese profesor
            jornada = new Jornada(clase, profesor);

            //Agrego los alumnos a la jornada y a la universidad
            foreach(Alumno al in g.Alumnos)
            {
                if(al == clase)
                {
                    jornada += al;
                }
            }

            //Agrego la jornada a la universidad
            g.Jornadas.Add(jornada);

            return g;
        }

        /// <summary>
        /// Operador encargado de agregar un alumno a la universidad si este no fue ya agregado
        /// </summary>
        /// <param name="u">Universidad donde se intentara agregar el alumno</param>
        /// <param name="a">Alumno que se intentara agregar en universidad</param>
        /// <returns>La misma universidad pasada por parametro, haya sido modificada o no</returns>
        public static Universidad operator +(Universidad u, Alumno a)
        {
            if(u != a)
            {
                u.Alumnos.Add(a);
            }

            return u;
        }

        /// <summary>
        /// Operador que agregara un profesor a una universidad si este no fue agregado anteriormente
        /// </summary>
        /// <param name="u">Universidad donde se intentara agregar el profesor</param>
        /// <param name="i">Profesor que se intentara agregar en la universidad</param>
        /// <returns>La misma universidad pasada por parametro, haya sido modificada o no</returns>
        public static Universidad operator +(Universidad u, Profesor i)
        {
            if(u != i)
            {
                u.Instructores.Add(i);
            }
            return u;
        }
        #endregion

        #region Tipos Anidados
        /// <summary>
        /// Clases disponibles para las universidades
        /// </summary>
        public enum EClases
        {
            Programacion = 0,
            Laboratorio,
            Legislacion,
            SPD
        }
        #endregion
    }
}
