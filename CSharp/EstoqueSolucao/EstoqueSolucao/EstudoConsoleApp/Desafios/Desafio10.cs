using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudoConsoleApp.Desafios
{
    /// <summary>
    /// Desafio 010 - Faça um programa que leia o preço de um produto, e mostre seu novo preço, com
    /// 5% de desconto.
    /// </summary>
    public static class Desafio10
    {
        public static void Executar()
        {
            double preco, desconto = 5.00;
            Console.Write("Preço = ");
            if (double.TryParse(Console.ReadLine(), out preco) == false)
            {
                Console.WriteLine("Serão aceitos somente Números.");
            }
            else
            {
                Console.Write("Preço com desconto {0} reais", preco - (preco * desconto) / 100);
            }
           
        }
    }
}
