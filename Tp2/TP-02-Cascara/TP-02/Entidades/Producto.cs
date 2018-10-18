using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    /// <summary>
    /// La clase Producto no deberá permitir que se instancien elementos de este tipo.
    /// </summary>
    public abstract class Producto
    {
        public enum EMarca
        {
            Serenisima, Campagnola, Arcor, Ilolay, Sancor, Pepsico
        }
        
        private EMarca marca;
        private string codigoDeBarras;
        private ConsoleColor colorPrimarioEmpaque;

        /// <summary>
        /// Producto
        /// </summary>
        /// <param name="marca">Marca del producto</param>
        /// <param name="patente">Codigo de barras del producto</param>
        /// <param name="colorPrimarioEmpaque">Color primario del empaque del empaque</param>
        public Producto(EMarca marca, string patente, ConsoleColor color)
        {
            this.marca = marca;
            this.codigoDeBarras = patente;
            this.colorPrimarioEmpaque = color;
        }

        /// <summary>
        /// ReadOnly: Retornará la cantidad de calorias del producto
        /// </summary>
        protected abstract short CantidadCalorias
        {
            get;
          
        }

        /// <summary>
        /// Publica todos los datos del Producto.
        /// </summary>
        /// <returns>Los datos del producto</returns>
        public abstract string Mostrar();

        /// <summary>
        /// Recopila los datos deol producto
        /// </summary>
        /// <param name="p">Productos del cual se recopilaran los datos</param>
        public static explicit operator string(Producto p)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(String.Format("CODIGO DE BARRAS: {0}", p.codigoDeBarras));
            sb.AppendLine(String.Format("MARCA          : {0}", p.marca.ToString()));
            sb.AppendLine(String.Format("COLOR EMPAQUE  : {0}", p.colorPrimarioEmpaque.ToString()));
            sb.AppendLine("---------------------");

            return sb.ToString();
        }

        /// <summary>
        /// Dos productos son iguales si comparten el mismo código de barras
        /// </summary>
        /// <param name="v1">Primer producto a analizar</param>
        /// <param name="v2">Segundo producto a analizar</param>
        /// <returns>True si ambos productos comparten codigo de barras, false en caso contrario</returns>
        public static bool operator ==(Producto v1, Producto v2)
        {
            return (String.Compare(v1.codigoDeBarras, v2.codigoDeBarras) == 0) ? true : false;
        }
        /// <summary>
        /// Dos productos son distintos si su código de barras es distinto
        /// </summary>
        /// <param name="v1">Primer producto a analizar</param>
        /// <param name="v2">Segundo producto a analizar</param>
        /// <returns>True si sus codigos de barras son distintos, false si son iguales</returns>
        public static bool operator !=(Producto v1, Producto v2)
        {
            return !(v1 == v2);
        }
    }
}
