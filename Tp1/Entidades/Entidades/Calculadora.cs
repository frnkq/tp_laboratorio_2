using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// @Franco Canevali
/// </summary>
namespace Entidades
{
    public class Calculadora
    {
        /// <summary>
        /// Realiza operaciones matematicas basicas entre dos numeros
        /// </summary>
        /// <param name="num1">Primer numero</param>
        /// <param name="num2">Segundo numbero</param>
        /// <param name="operador">Operador que determina que operación se va a llevar a cabo ('+', '-', '*', '-')</param>
        /// <returns>El resultado de la operación</returns>
        public double Operar(Numero num1, Numero num2, string operador)
        {
            operador = ValidarOperador(operador);
            switch (operador)
            {
                case "+":
                    return num1 + num2;
                case "-":
                    return num1 - num2;
                case "*":
                    return num1 * num2;
                case "/":
                    return num1 / num2;
                default: //no debería llegar nunca a esta parte siendo que se valida el operador
                    return 0;
            }
        }
        /// <summary>
        /// Verifies if a string is a valid operator
        /// </summary>
        /// <param name="operador">String to be checked</param>
        /// <returns>Returns the operator if it's a valid one, otherwise, returns '+' </returns>
        private String ValidarOperador(string operador)
        {
            char[] operators = new char[] { '+', '-', '/', '*' };

            if(operador.Length == 1 && operators.Contains(operador.ElementAt(0)))
            {
                return operador;
            }
            return "+";
        }
    }
}
