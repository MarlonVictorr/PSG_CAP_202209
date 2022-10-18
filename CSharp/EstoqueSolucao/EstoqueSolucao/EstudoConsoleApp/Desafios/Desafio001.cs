using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudoConsoleApp.Desafios
{
    /// <summary>
    /// Desafio 001 - Crie um programa que leia o nome de uma pessoa e mostre uma mensagem de
    /// boas-vindas de acordo com o valor digitado.
    /// </summary>
    public static class Desafio001
    {
        public static void Executar()
        {
            Console.WriteLine("Digite seu Nome:");
            string userName = Console.ReadLine();
            if (string.IsNullOrEmpty(userName)) 
            {
                Console.WriteLine("O Nome não pode ser vazio");  
            }
            else
            {
                Console.WriteLine("Bem Vindo {0}.", userName);
            }

           

        }
    }
}
