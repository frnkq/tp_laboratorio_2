using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    public class Dulce : Producto
    {
        /// <summary>
        /// Dulce
        /// </summary>
        /// <param name="marca">Marca del dulce</param>
        /// <param name="codigoDeBarras">Codigo de barras del dulce</param>
        /// <param name="colorPrimarioEmpaque">Color primario del empaque del dulce</param>
        public Dulce(Producto.EMarca marca, string codigoDeBarras, ConsoleColor colorPrimarioEmpaque)
            :base(marca, codigoDeBarras, colorPrimarioEmpaque)
        {
        }

        /// <summary>
        /// Los dulces tienen 80 calorías
        /// </summary>
        public override short CantidadCalorias
        {
            get
            {
                return 80;
            }
        }
        
        /// <summary>
        /// Publica todos los datos deol producto
        /// </summary>
        /// <returns>Los datos del producto</returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("DULCE");
            sb.AppendLine((string)this);
            sb.AppendLine(String.Format("CALORIAS : {0}", this.CantidadCalorias));
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
