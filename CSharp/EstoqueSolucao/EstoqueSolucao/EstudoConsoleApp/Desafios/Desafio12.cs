using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudoConsoleApp.Desafios
{
    public static class Desafio12
    {
        public static void Executar()
        {
            double Graus;
            Console.Write("Digite a Temperatura em Graus = ");
            if (double.TryParse(Console.ReadLine(), out Graus) == false)
            {
                Console.WriteLine("Serão aceitos somente Números.");
            }
            Console.WriteLine("Sua Temperatura em fahrenheit é {0}°F", Graus * 1.8 + 32);
        }
    }
}
