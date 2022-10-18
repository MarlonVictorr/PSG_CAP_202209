using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudoConsoleApp.Desafios
{
    public static class Desafio19
    {
        public static void Executar()
        {
            double Numero;
            Console.WriteLine("Digite um numero ");
            if (Double.TryParse(Console.ReadLine(), out Numero) == false)
            {
                Console.WriteLine("Somente Números são aceitos.");
            }
            else
            {
                Console.Write("Numero % 2 = 0");
                Console.WriteLine();
                Console.WriteLine("Seu Numero é par");
            }
        }
    }
}
