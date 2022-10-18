using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudoConsoleApp.Desafios
{
    public static class Desafio011
    {
        public static void Executar()
        {
            double salario, aumento = 15.00;
            Console.Write("Salario = ");
            if (double.TryParse(Console.ReadLine(), out salario) == false)
            {
                Console.WriteLine("Serão aceitos somente Números.");
            }
            else
            {
                Console.Write("Salario com aumento {0} reais", salario + (salario * aumento) / 100);
            }

        }
    }
}
