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
            int Numero;
            Console.WriteLine("Digite um numero ");
            if (Int32.TryParse(Console.ReadLine(), out Numero) == false)
            {
                Console.WriteLine("Esse Campo só aceita Números");
                return;
            }
            else if ((Numero % 2) == 0)
            {
                Console.WriteLine("Você informou um número par");
            }
            else
            {
                Console.WriteLine("Você informou um número ímpar");
            }
        }
    }
}
