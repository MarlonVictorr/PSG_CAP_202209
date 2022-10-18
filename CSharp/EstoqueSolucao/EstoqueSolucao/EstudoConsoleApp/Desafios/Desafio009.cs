using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudoConsoleApp.Desafios
{
    /// <summary>
    /// Desafio 009 - Faça um programa que leia a largura e a altura de uma parede em metros, e calcule
    /// a sua área e a quantidade de tinta necessária para pintá-la, sabendo que cada litro de tinta pinta
    /// uma área de 2 metros quadrados.
    /// </summary>
    public static class Desafio009
    {
        public static void Executar()
        {
            double largura, altura, tinta;
            Console.Write("Largura da Parede em metros: ");
            if (double.TryParse(Console.ReadLine(), out largura) == false)
            {
                Console.WriteLine("Serão aceitos somente Números.");
              
            }
            Console.Write("Altura da parede em metros: ");
            if (double.TryParse(Console.ReadLine(), out altura) == false)
            {
                Console.WriteLine("Serão aceitos somente Números.");
              
            }
            Console.WriteLine();
            Console.Write("Quantidade necessária de  {0} Litros de tinta para pintar a parede.", largura * altura / 2);
        }
    }
}
