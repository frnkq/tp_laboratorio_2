using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;
namespace ClasesInstanciables
{
    public class Jornada
    {
        #region Campos
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;
        #endregion

        #region Propiedades
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

        public Universidad.EClases Clase
        {
            get
            {
                return this.clase;
            }
            set
            {
                this.clase = value;
            }
        }

        public Profesor Instructor
        {
            get
            {
                return this.instructor;
            }
            set
            {
                this.instructor = value;
            }
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Constructor por defecto que inicializará la lista de alumnos
        /// </summary>
        private Jornada()
        {
            this.alumnos = new List<Alumno>();
        }
        /// <summary>
        /// Constructor de Jornada que establece la clase y el instructor
        /// </summary>
        /// <param name="clase">Clase a la cual correspondera la jornada</param>
        /// <param name="instructor">Profesor al cual correspondera la jornada</param>
        public Jornada(Universidad.EClases clase, Profesor instructor) : this()
        {
            this.clase = clase;
            this.instructor = instructor;
        }

        /// <summary>
        /// Guardará los datos de la Jornada en un archivo de texto nombrado con la clase correspondiente a la jornada,
        /// en el escritorio.
        /// </summary>
        /// <param name="jornada">Jornada a guardar en archivo de texto</param>
        /// <returns>true si pudo guardar, false de lo contrario</returns>
        public static bool Guardar(Jornada jornada)
        {
            Texto texto = new Texto();
            string fileName = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) +
                              "\\FrancoCanevali.Tp3.jornada.txt";
            try
            {
                texto.Guardar(fileName, jornada.ToString());
                return true;
            }catch(Exception e)
            {
                ///TODO throw exception?
                return false;
            }
                
        }

        /// <summary>
        /// Leerá los datos de la Jornada de un archivo de texto nombrado con la clase correspondiente a la jornada,
        /// en el escritorio.
        /// </summary>
        /// <returns>Retornará los datos de la Jornada como texto.</returns>
        public static string Leer()
        {
            Texto texto = new Texto();
            string fileName = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) +
                              "\\FrancoCanevali.Tp3.jornada.txt";
            string data = "";
            try
            {
                texto.Leer(fileName, out data);
            }
            catch (Exception e)
            {
                //TODO no Exception?
            }
            return data;
        }

        /// <summary>
        /// Mostrará todos los datos de la Jornada.
        /// </summary>
        /// <returns>Los datos de la jornada en formato string</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("->Jornada");
            sb.AppendLine("-->Clase: " + this.clase.ToString());
            sb.AppendLine(this.instructor.ToString());
            sb.AppendLine("Alumnos: ");
            foreach(Alumno al in this.alumnos)
            {
                ///TODO tostring(), mostrardatos()??
                sb.AppendLine(al.ToString());
            }
            sb.AppendLine("---------------");
            return sb.ToString();
        }

        /// <summary>
        /// Una Jornada será igual a un Alumno si el mismo participa de la clase.
        /// </summary>
        /// <param name="j">Jornada en la cual se buscara el Alumno a</param>
        /// <param name="a">Alumno a buscar en Jornada j</param>
        /// <returns>True si el alumno se encuentra en la jornada, falso de lo contrario</returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            foreach(Alumno alumno in j.alumnos)
            {
                if (a == alumno)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Una Jornada será distinta a un Alumno si el mismo no participa de la clase.
        /// </summary>
        /// <param name="j">Jornada en la cual se buscara el Alumno a</param>
        /// <param name="a">Alumno a buscar en Jornada j</param>
        /// <returns>False si el alumno se encuentra en la jornada, true de lo contrario</returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        /// <summary>
        /// Agregar Alumnos a la clase por medio del operador +, validando que no estén previamente cargados.
        /// </summary>
        /// <param name="j">Jornada en la que se agregara el alumno si este no forma parte ya de la misma</param>
        /// <param name="a">Alumno a agregar en jornada si este no forma parte ya de la misma</param>
        /// <returns>Devuelve la jornada ingresada por parametro, con sus modificaciones o no</returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
                j.alumnos.Add(a);
            return j;
        }
        #endregion
    }
}
