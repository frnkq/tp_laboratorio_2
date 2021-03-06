﻿using System;
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
        Alumno.EEstadoCuenta estadoCuenta;
        #endregion

        #region Metodos
        /// <summary>
        /// Constructor por defecto de Alumno
        /// </summary>
        public Alumno()
        {

        }

        /// <summary>
        /// Constructor de Alumno que establece el id, nombre, apellido, dni, nacionalidad, claseQueToma
        /// </summary>
        /// <param name="id">Id a establecer en base.legajo</param>
        /// <param name="nombre">Nombre a establecer en base.nombre</param>
        /// <param name="apellido">Apellido a establecer en base.apellido</param>
        /// <param name="dni">Dni a establecer en base.dni</param>
        /// <param name="nacionalidad">Nacionalidad a establecer en base.nacionalidad</param>
        /// <param name="claseQueToma">Clase a establecer en this.claseQueToma</param>
        public Alumno(int id, string nombre, 
            string apellido, string dni, Persona.ENacionalidad nacionalidad, Universidad.EClases claseQueToma)
            :base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }

        /// <summary>
        /// Constructor de Alumno que establece el id, nombre, apellido, dni, nacionalidad, claseQueToma
        /// </summary>
        /// <param name="id">Id a establecer en base.legajo</param>
        /// <param name="nombre">Nombre a establecer en base.nombre</param>
        /// <param name="apellido">Apellido a establecer en base.apellido</param>
        /// <param name="dni">Dni a establecer en base.dni</param>
        /// <param name="nacionalidad">Nacionalidad a establecer en base.nacionalidad</param>
        /// <param name="claseQueToma">Clase a establecer en this.claseQueToma</param>
        /// <param name="estadoCuenta">Estado de cuenta a establecer en this.estadoCuenta</param>
        public Alumno(int id, string nombre,
           string apellido, string dni,
           Persona.ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta)
            :this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }

        /// <summary>
        /// Rretornará la cadena "TOMA CLASE DE " junto al nombre de la clase que toma.
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            return String.Format("TOMA CLASE DE {0}", this.claseQueToma.ToString());
        }

        /// <summary>
        /// Devuelve todos los datos del alumno en un string
        /// </summary>
        /// <returns>Todos los datos del alumno en un string</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("--->Alumno");
            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine(String.Format("Clase que toma: {0}", this.claseQueToma.ToString()));
            sb.AppendLine(String.Format("Estado de cuenta: {0}", this.estadoCuenta.ToString()));
            return sb.ToString();
        }

        /// <summary>
        /// Devuelve todos los datos del alumno en un string
        /// </summary>
        /// <returns>Todos los datos del alumno en un string</returns>
        public override string ToString()
        {
            
            return this.MostrarDatos();
        }

        /// <summary>
        /// Un Alumno será igual a un EClase si toma esa clase y su estado de cuenta no es Deudor
        /// </summary>
        /// <param name="a">Alumno a analizar con EClase 'clase' y su estado de cuenta</param>
        /// <param name="clase">Clase que se utilizara para analizar al alumno 'a'</param>
        /// <returns>True si el alumno toma esa clase y estadoCuenta no es 'EEstadoDeCuenta.Deudor'</returns>
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            if(a.claseQueToma == clase && 
                a.estadoCuenta != Alumno.EEstadoCuenta.Deudor)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Un Alumno será distinto a un EClase sólo si no toma esa clase
        /// </summary>
        /// <param name="a">Alumno a analizar con EClase 'clase'</param>
        /// <param name="clase">Clase que se utilizara para analizar al alumno 'a'</param>
        /// <returns></returns>
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            return !(a.claseQueToma == clase);
        }
        #endregion


        #region Tipos Anidados
        /// <summary>
        /// Estados de cuenta disponibles para Alumno
        /// </summary>
        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }
        #endregion
    }
}
