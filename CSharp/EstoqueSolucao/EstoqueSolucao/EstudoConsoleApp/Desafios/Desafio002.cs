using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudoConsoleApp.Desafios
{
    public static class Desafio002
    {
        public static void Executar()
        {
            Console.WriteLine("Digite um Dia:");
            int dia = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Digite um Mês:");
            int mes = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Digite um Ano:");
            int ano = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            DateTime Data = new DateTime(ano, mes, dia);
            

            if (dia > 31 || dia < 1)
            {
                Console.WriteLine("Digite um Dia Válido:");
            }
            else if (mes > 12 || mes < 1)
            {
                Console.WriteLine("Digite um Mês Válido:");
            }
            else if (ano > DateTime.Now.Year)
            {
                Console.WriteLine("O Ano não pode ser maior que o atual");
            }
            else 
            {
                Console.Write("A Data Informada foi:");
                Console.WriteLine(Data.ToString("dddd, dd MMMM yyyy"));    
            }
            

        }
    }
}
