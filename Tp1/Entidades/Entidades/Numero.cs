using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

//BASIC and horrible dec to bin
//while (numero > 0 || numero < 0)
//{
//    resto = numero % 2;
//    binary = binary + "" + resto;
//    if (numero > 0)
//        numero = Math.Floor((double)numero / 2);
//    else
//        numero = Math.Ceiling((double)numero / 2);
//}
////reverts the string as 'binary' is backwards
//for (int i = binary.Length - 1; i >= 0; i--)
//{
//    retorno = retorno + binary.ElementAt(i);
//}

namespace Entidades
{
    class Numero
    {
        private double numero;
        private string SetNumero
        {
            set
            {
                if (ValidarNumero(value) != null)
                    numero = (double)ValidarNumero(value);
                else
                    numero = 0;
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
            if (ValidarNumero(numero) != null)
                this.numero = (double)ValidarNumero(numero);
            else
                this.numero = 0;
        }

        /// <summary>
        /// Valida que el valor recibido sea numerico y lo retorna en formato double, de no ser numerico, retorna 0
        /// </summary>
        /// <param name="strNumero"></param>
        /// <returns>El valor del parametro en formato double si este es numerico, 0 si no lo es</returns>
        private double? ValidarNumero(string strNumero)
        {
            double number;
            if (double.TryParse(strNumero, NumberStyles.AllowDecimalPoint | NumberStyles.AllowTrailingSign, 
                CultureInfo.CurrentCulture, out number))
            {
                return number;
            }
            return null;
        }

        /// <summary>
        /// Convierte un numero binario representado en un string, a un numero decimal
        /// </summary>
        /// <param name="binario">String que representa el numero binario</param>
        /// <returns>Devuelve el numero decimal que representa el binario, en formato string</returns>
        public string BinarioDecimal(string binario)
        {
            bool converted = false;
            double numero = 0;

            double? binary = ValidarNumero(binario);
            if(binary != null)
            {
                for (int i = 0; i < binario.Length; i++)
                {
                    int digito = int.Parse(binario.ElementAt(i).ToString());
                    numero += digito * Math.Pow(2, binario.Length - i - 1);
                }
            }
            else
            {
                return "Valor invalido";
            }

            return numero.ToString();
        }

        /// <summary>
        /// Convierte un numero decimal a un numero binario
        /// </summary>
        /// <param name="numero">Numero decimal a ser convertido en binario</param>
        /// <returns>Devuelve el numero binario que representa al decimal, en formato string</returns>
        public string DecimalBinario(double? numero)
        {
            double? resto;
            string retorno = "Valor invalido";
            string[] splittedDecimal = new string[2];
            string binary = "";
            bool isNegative = false;
            if (numero != null)
            {
                retorno = "";
                if (numero.Equals((double)0))
                    retorno = "0" ;

                while (numero > 0 || numero < 0)
                {
                    resto = numero % 2;
                    binary = binary + "" + resto;
                    if (numero > 0)
                        numero = Math.Floor((double)numero / 2);
                    else
                        isNegative = true;
                        numero = Math.Ceiling((double)numero / 2);


                }
                for (int i = binary.Length - 1; i >= 0; i--)
                {
                    retorno = retorno + binary.ElementAt(i);
                }
                retorno = retorno.Replace("-", String.Empty);
                if (isNegative)
                    retorno = "-" + retorno;
            }
            return retorno;
        }



        /// <summary>
        /// Convierte un numero decimal a un numero binario
        /// </summary>
        /// <param name="numero">Numero decimal a ser convertido en binario</param>
        /// <returns>Devuelve el numero binario que representa al decimal, en formato string</returns>
        public string DecimalBinario(string numero)
        {
            return DecimalBinario(ValidarNumero(numero));
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
