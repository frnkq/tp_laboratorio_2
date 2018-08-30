using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    class Program
    {
        static void Main(string[] args)
        {
            Numero n1 = new Numero("82");
            Numero n2 = new Numero(4);
            Numero zero = new Numero(0);

            double suma = n1 + n2;
            double division = n1 / n2;
            double failureDivision = n1 / zero;

            Console.WriteLine("Suma {0} division {1} failureDivision {2}", suma, division, failureDivision);


            Console.ReadKey();
        }
    }
}
