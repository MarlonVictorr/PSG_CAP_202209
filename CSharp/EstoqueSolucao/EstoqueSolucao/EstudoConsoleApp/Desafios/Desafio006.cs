using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudoConsoleApp.Desafios
{
    /// <summary>
    /// Desafio 006 - Escreva um programa que leia um valor em metros e o exiba convertido em
    /// centímetros e milímetros.
    /// </summary>
    public static class Desafio006
    {
        public static void Executar()
        {
            double metros;
            Console.Write("Quantidade em metros: ");
            if (Double.TryParse(Console.ReadLine(), out metros) == false)
            {
                Console.WriteLine("Somente Números são aceitos.");
            }
            else
            {
                double centimetros = metros * 100;
                double milimetros = metros * 1000;
                Console.WriteLine("{0} metros são {1} centímetros.", metros, centimetros);
                Console.WriteLine("{0} metros são {1} milímetros.", metros, milimetros);
            }
        }
    }
}
