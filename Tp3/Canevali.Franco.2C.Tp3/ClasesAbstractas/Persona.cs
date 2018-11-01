using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
namespace ClasesAbstractas
{

    public abstract class Persona
    {
        #region Campos
        private string apellido;
        private string nombre;
        private int dni;
        private ENacionalidad nacionalidad;
        #endregion

        #region Propiedades
        /// <summary>
        /// Read/Write.
        /// Write: Establece el apellido tras procesarlo con la función ValidarNombreYApellido
        /// Read: devuelve el valor de this.apellido
        /// </summary>
        public string Apellido
        {
            get { return this.apellido;  }
            set { this.apellido = this.ValidarNombreYApellido(value); }
        }

        /// <summary>
        /// Read/Write.
        /// Write: Establece el nombre tras procesarlo con la función ValidarNombreYApellido
        /// Read: devuelve el valor de this.nombre
        /// </summary>
        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = this.ValidarNombreYApellido(value); }
        }

        /// <summary>
        /// Read/Write
        /// Write: Establece el dni tras procesarlo con la función ValidarDni
        /// Read: devuelve el valor de this.dni
        /// </summary>
        public int DNI
        {
            get { return this.dni;  }
            set { this.dni = this.ValidarDni(this.Nacionalidad, value); }
        }

        /// <summary>
        /// Propiedad Read/Write de this.nacionalidad
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            get { return this.nacionalidad;  }
            set { this.nacionalidad = value; }
        }

        /// <summary>
        /// Writeonly
        /// Delega la asignacion del dni a la propiedad "DNI", tras verificar que tenga entre 1 y 8 caracteres, y que todos sean numericos
        /// </summary>
        public string StringToDni
        {
            set
            {
                this.DNI = this.ValidarDni(this.Nacionalidad, value);
            }
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Constructor vacío de Persona
        /// </summary>
        public Persona()
        {

        }

        /// <summary>
        /// Constructor de persona que establece el nombre, apellido y nacionalidad
        /// </summary>
        /// <param name="nombre">Nombre a establecer en el campo 'nombre'</param>
        /// <param name="apellido">Apellido a establecer en el campo 'apellido'</param>
        /// <param name="nacionalidad">Nacionalidad a establecer en el campo 'nacionalidad'</param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad) : this()
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }


        /// <summary>
        /// Constructor de persona que establece el nombre, apellido, nacionalidad, y dni en formato int
        /// </summary>
        /// <param name="nombre">Nombre a establecer en el campo 'nombre'</param>
        /// <param name="apellido">Apellido a establecer en el campo 'apellido'</param>
        /// <param name="dni">Dni a establecer en el campo 'dni'</param>
        /// <param name="nacionalidad">Nacionalidad a establecer en el campo 'nacionalidad'</param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) 
            : this(nombre, apellido, nacionalidad)
        {

                this.DNI = dni;
        }

        /// <summary>
        /// Constructor de persona que establece el nombre, apellido, nacionalidad, y dni en formato string
        /// </summary>
        /// <param name="nombre">Nombre a establecer en el campo 'nombre'</param>
        /// <param name="apellido">Apellido a establecer en el campo 'apellido'</param>
        /// <param name="dni">Dni a establecer en el campo 'dni'</param>
        /// <param name="nacionalidad">Nacionalidad a establecer en el campo 'nacionalidad'</param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
                this.StringToDni = dni;

        }

        /// <summary>
        /// Retornará los datos de la Persona
        /// </summary>
        /// <returns>Un string formado con los datos de la persona</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(String.Format("Nombre: {0}, {1}", this.Nombre, this.Apellido));
            sb.AppendLine("Dni: "+this.DNI);
            sb.AppendLine("Nacionalidad: "+this.Nacionalidad.ToString());
            return sb.ToString();
        }

        /// <summary>
        /// Funcion que se ocupa de la validacion numerica del dni con respecto a la nacionalidad
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad que se tomara en cuenta</param>
        /// <param name="dato">Dato que se analizara que sea un dni valido con respecto a la nacionalidad</param>
        /// <returns>El dni de ser correcto, new NacionalidadInvalidaException </returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {

            ///Se verifica el rango del dni de acuerdo a nacionalidad Argentina
            if (nacionalidad == Persona.ENacionalidad.Argentino)
            {
                if (dato >= 1 && dato <= 89999999)
                    return dato;
            }
            ///Se verifica el rango del dni de acuerdo a nacionalidad Exranjera
            if (nacionalidad == Persona.ENacionalidad.Extranjero)
            {
                if (dato >= 90000000 && dato <= 99999999)
                    return dato;
            }
            throw new NacionalidadInvalidaException("Nacionalidad invalida");
        }

        /// <summary>
        /// Valida que el dni sea correcto de acuerdo a la nacionalidad
        /// Argentino: entre 1 y 89999999
        /// Extranjero: entre 90000000 y 99999999.
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad a tener en cuenta</param>
        /// <param name="dato">Dato a verificar que sea un correcto DNI</param>
        /// <returns>El dni de ser correcto, new NacionalidadInvalidaException de no serlo</returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            ///Se descarta que dato tenga más de 8 o menos de 1 caracter
            if (dato.Length > 8 || dato.Length < 1)
                throw new DniInvalidoException();

            ///Se descarta que dato tenga algún caracter que no es un dígito
            foreach (char c in dato)
                if (!(char.IsDigit(c)))
                    throw new DniInvalidoException("Dni invalido");
            
            ///Se descarta que dato no pueda ser parseado a int
            int dni;
            if(!(int.TryParse(dato, out dni)))
            {
                throw new DniInvalidoException("Dni invalido");
            }
            else
            {
                return this.ValidarDni(nacionalidad, dni);
            }

        }
        /// <summary>
        /// Validará que los nombres sean cadenas con caracteres válidos (caracteres alfabeticos, de puntuacion o espacios)
        /// </summary>
        /// <param name="dato">Dato a analizar que sea un nombre y apellido correcto</param>
        /// <returns>Dato si es valido, string vacio si no lo es</returns>
        private string ValidarNombreYApellido(string dato)
        {
            foreach(char c in dato)
            {

                if (!(char.IsLetter(c)) && !(char.IsPunctuation(c)) && !(char.IsWhiteSpace(c)))
                    return "";                    
            }
            return dato;
        }
        #endregion

        #region Tipos anidados
        /// <summary>
        /// Nacionalidades disponibles para Persona y sus derivados
        /// </summary>
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }
        #endregion
    }
}
