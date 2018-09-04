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
            Numero n1 = new Numero("");

            String bin = n1.DecimalBinario("9009090");
            String dec = n1.BinarioDecimal("1110000100");
            Console.WriteLine("dec: "+dec);
                        
            Console.ReadLine();
        }
    }
}
