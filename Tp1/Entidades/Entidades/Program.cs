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

            String bin = n1.BinarioDecimal("1010");
            Console.WriteLine("dec: "+bin);
                        
            Console.ReadLine();
        }
    }
}
