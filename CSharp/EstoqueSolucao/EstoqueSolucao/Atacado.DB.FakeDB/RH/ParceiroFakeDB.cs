using Atacado.Dominio.RH;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.DB.FakeDB.RH
{
    public static class ParceiroFakeDB
    {
        private static List<Parceiro> parceiros;

        public static List<Parceiro> Parceiros
        {
            get
            {
                if (parceiros == null)
                {
                    parceiros = new List<Parceiro>();
                    Carregar();
                }
                return parceiros;
            }
        }
        private static void Carregar()
        {
            parceiros.Add(new Parceiro(1,"PSG","PSG Tecnologias","23.321.456/0001-32","673875642",new DateTime(1970,05,19),"psgtecnologia@gmail.com",90,5000,"Desenvolvimento"));
            parceiros.Add(new Parceiro(2, "Itaú", "Itaú Banco Múltiplo S.A", "90.850.745/0001-97", "673145321", new DateTime(2000, 10, 21), "itau@gmail.com", 80, 4000, "Finanças"));
            parceiros.Add(new Parceiro(3, "Coca-Cola", "Coca Cola ltda", "67.541.165/0001-21", "670965543", new DateTime(1960, 11, 31), "cocacola@gmail.com", 70, 3000, "Alimenticios"));
            parceiros.Add(new Parceiro(4, "Vivo", "Vivo Comunicações", "10.786.984/0001-15", "679281547", new DateTime(1980, 01, 01), "vivo@gmail.com", 50, 2450, "Comunicação"));
            parceiros.Add(new Parceiro(5, "ContaAzul", "ContaAzul Banco Múltiplo S.A", "11.470.254/0001-88", "671893043", new DateTime(1974, 08, 21), "contaazul@gmail.com", 65, 2700, "Finanças"));
        }
    }
}