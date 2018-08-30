using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    class Numero
    {
        private double numero;
        private string SetNumero
        {
            set
            {
                double n = ValidarNumero(value);
                numero = n;
            }
        }

        public Numero() { }
        public Numero(double numero)
        {
            this.numero = numero;
        }

        public Numero(string numero)
        {
            //TODO: validacion?
            this.numero = ValidarNumero(numero);
        }

        /// <summary>
        /// Valida que el valor recibido sea numerico y lo retorna en formato double, de no ser numerico, retorna 0
        /// </summary>
        /// <param name="strNumero"></param>
        /// <returns>El valor del parametro en formato double si este es numerico, 0 si no lo es</returns>
        private double ValidarNumero(string strNumero)
        {
            double number;
            if (double.TryParse(strNumero, out number))
                return number;
            return 0;
        }

        /// <summary>
        /// Convierte un numero binario representado en un string, a un numero decimal
        /// </summary>
        /// <param name="binario">String que representa el numero binario</param>
        /// <returns>Devuelve el numero decimal que representa el binario, en formato string</returns>
        public string BinarioDecimal(string binario)
        {
            bool converted = false;
            string result = "";

            if (converted)
                return result;
            return "Valor invalido";
        }

        /// <summary>
        /// Convierte un numero decimal a un numero binario
        /// </summary>
        /// <param name="numero">Numero decimal a ser convertido en binario</param>
        /// <returns>Devuelve el numero binario que representa al decimal, en formato string</returns>
        public string DecimalBinario(double numero)
        {
            return "";
        }


        /**Operators**/
        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }
        public static double operator *(Numero n1, Numero n2)
        {
           return n1.numero* n2.numero;
        }
        public static double operator /(Numero n1, Numero n2)
        {
            if (n2.numero == 0)
                return -1; //TODO: change this value
            return n1.numero / n2.numero;
        }
        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }
        /**\Operators**/
        

    }
}
