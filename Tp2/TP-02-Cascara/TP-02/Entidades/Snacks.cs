using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    public class Snacks : Producto
    {
        /// <summary>
        /// Snacks
        /// </summary>
        /// <param name="marca">Marca del snack</param>
        /// <param name="codigoDeBarras">Codigo de barras del snack</param>
        /// <param name="colorPrimarioEmpaque">Color primario del empaque del snack</param>
        public Snacks(Producto.EMarca marca, string codigoDeBarras, ConsoleColor colorPrimarioEmpaque)
            : base(marca, codigoDeBarras, colorPrimarioEmpaque)
        {
        }
        /// <summary>
        /// Los snacks tienen 104 calorías
        /// </summary>
        public override short CantidadCalorias
        {
            get
            {
                return 104;
            }
        }

        /// <summary>
        /// Publica todos los datos deol producto
        /// </summary>
        /// <returns>Los datos del producto</returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SNACKS");
            sb.AppendLine((string)this);
            sb.AppendLine(String.Format("CALORIAS : {0}", this.CantidadCalorias));
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
