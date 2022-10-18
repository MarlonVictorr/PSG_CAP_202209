using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EstudoConsoleApp.Desafios
{
    public static class Desafio13
    {
        public static void Executar()
        {
            double Km;
            double Dias;
            Console.Write("Digite a Quantidade de Km Rodados = ");
            if (double.TryParse(Console.ReadLine(), out Km) == false)
            {
                Console.WriteLine("Serão aceitos somente Números.");
            }
            Console.Write("Digite a Quantidade de dias = ");
            if (double.TryParse(Console.ReadLine(), out Dias) == false)
            {
                Console.WriteLine("Serão aceitos somente Números.");
            }
            else
            {
                Console.WriteLine("Valor a pagar pelo aluguel é : {0}", Km * 0.15 + Dias * 60);
            }
            
        }
    }
}
