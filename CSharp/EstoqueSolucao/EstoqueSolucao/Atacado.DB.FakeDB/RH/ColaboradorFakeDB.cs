using Atacado.Dominio.RH;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Atacado.DB.FakeDB.RH
{   
    public static class ColaboradorFakeDB 
    {
        private static List<Colaborador> colaboradores;

        public static List<Colaborador> Colaboradores
        {
            get
            {
                if (colaboradores == null)
                {
                    colaboradores = new List<Colaborador>();
                    Carregar();
                }
                return colaboradores;
            }
        }
        private static void Carregar()
        {
            colaboradores.Add(new Colaborador(1, "1452", "akira", "6091", "M", new DateTime(2001, 04, 01), "akira@gmail.com", "12345678", "1234", "1841321987", true, "solteiro", 2, true, "Finanças", "Contador", 2000, "800154", "128522"));
            colaboradores.Add(new Colaborador(2, "1324", "marlon", "4521", "M", new DateTime(2002, 02, 17), "marlon@gmail.com", "97864132", "4321", "1234867593", true, "solteiro", 3, true, "Admin", "Administração", 3000, "543213", "342512"));
            colaboradores.Add(new Colaborador(3, "9867", "gemeli", "1989", "M", new DateTime(2003, 08, 20), "gemeli@gmail.com", "56422130", "8765", "9785432871", true, "solteiro", 1, true, "RH", "Secretario", 1500, "967432", "295432"));
            colaboradores.Add(new Colaborador(4, "5431", "bruno", "5231", "M", new DateTime(2000, 06, 13), "bruno@gmail.com", "80065432", "5231", "9018254392", true, "solteiro", 0, true, "Comercial", "Vendas", 2800, "756432", "756412"));
            colaboradores.Add(new Colaborador(5, "2134", "thiago", "3126", "M", new DateTime(1999, 12, 09), "thiago@gmail.com", "31297645", "9002", "7869032981", true, "solteiro", 4, true, "Operacional", "Logistica", 3500, "908123", "956483"));

        }
    }
}
