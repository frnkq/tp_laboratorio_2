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
        /// <param name="color">Color primario del empaque del dulce</param>
        public Dulce(Producto.EMarca marca, string patente, ConsoleColor color)
            :base(marca, patente, color)
        {
        }

        /// <summary>
        /// Los dulces tienen 80 calorías
        /// </summary>
        protected override short CantidadCalorias
        {
            get
            {
                return 80;
            }
        }
        
        /// <summary>
        /// Publica todos los datos del producto
        /// </summary>
        /// <returns>Los datos del producto</returns>
        public override sealed string Mostrar()
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
