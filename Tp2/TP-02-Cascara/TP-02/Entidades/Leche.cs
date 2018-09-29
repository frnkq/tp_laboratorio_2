using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Entidades_2018
{
    public class Leche : Producto
    {
        public enum ETipo { Entera, Descremada }
        ETipo tipo;

        /// <summary>
        /// Por defecto, TIPO será ENTERA
        /// </summary>
        /// <param name="marca">Marca de la leche</param>
        /// <param name="patente">Codigo de barras de la leche</param>
        /// <param name="colorPrimarioEmpaque">Color primario del empaque de la leche</param>
        /// 
        public Leche(Producto.EMarca marca, string patente, ConsoleColor colorPrimarioEmpaque)
            : base(marca, patente, colorPrimarioEmpaque)
        {
            tipo = ETipo.Entera;
        }
        /// <summary>
        /// Constructor de Leche con el agregado del tipo de leche
        /// </summary>
        /// <param name="marca">Marca de la leche</param>
        /// <param name="patente">Codigo de barras de la leche</param>
        /// <param name="colorPrimarioEmpaque">Color primario del empaque de la leche</param>
        /// <param name="tipo">Tipo de leche</param>
        public Leche(Producto.EMarca marca, string patente, ConsoleColor color, Leche.ETipo tipo)
            :base(marca, patente, color)
        {
            this.tipo = tipo;
        }

        /// <summary>
        /// Las leches tienen 20 calorías
        /// </summary>
        protected override short CantidadCalorias
        {
            get
            {
                return 20;
            }
        }
       
        /// <summary>
        /// Publica todos los datos del producto
        /// </summary>
        /// <returns>Los datos del producto</returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("LECHE");
            sb.AppendLine((string)this);
            sb.AppendLine(String.Format("CALORIAS: {0}TIPO: {1}", 
                this.CantidadCalorias,this.tipo.ToString()));
            sb.AppendLine();
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
