using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesAbstractas
{
    public enum ENacionalidad
    {
        Argentino,
        Extranjero
    }
    public abstract class Persona
    {
        #region Fields
        private string apellido;
        private string nombre;
        private int dni;
        private ENacionalidad nacionalidad;
        #endregion

        #region Properties
        public string Apellido
        {
            get { return this.apellido;  }
            set { this.apellido = value; }
        }

        public int DNI
        {
            get { return this.dni;  }
            set { this.dni = value; }
        }

        public ENacionalidad Nacionalidad
        {
            get { return this.nacionalidad;  }
            set { this.nacionalidad = value; }
        }

        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = value; }
        }

        public string StringToDni
        {
            get { return this.dni.ToString(); }
            set { this.dni = int.Parse(value); }
        }
        #endregion

        #region Methods
        public Persona()
        {

        }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad) : this()
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) 
            : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.dni = int.Parse(dni);
        }

        public override string ToString()
        {
            return base.ToString();
        }

        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            return 0;
        }

        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            return 0;
        }

        private string ValidarNombreYApellido(string dato)
        {
            return dato;
        }
        #endregion
    }
}
