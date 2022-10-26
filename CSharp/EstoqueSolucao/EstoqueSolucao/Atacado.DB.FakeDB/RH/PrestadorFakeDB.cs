using Atacado.Dominio.RH;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.DB.FakeDB.RH
{
    public static class PrestadorFakeDB
    {
        private static List<Prestador> prestadores;

        public static List<Prestador> Prestadores
        {
            get
            {
                if (prestadores == null)
                {
                    prestadores = new List<Prestador>();
                    Carregar();
                }
                return prestadores;
            }
        }
        private static void Carregar()
        {
            prestadores.Add(new Prestador(1, "PSG", "PSG Tecnologias", "23.321.456/0001-32", "673875642", new DateTime(1970, 05, 19), "psgtecnologia@gmail.com",new DateOnly(2021, 04, 10 ),new DateOnly(2025, 04, 10)));
            prestadores.Add(new Prestador(2, "Itaú", "Itaú Banco Múltiplo S.A", "90.850.745/0001-97", "673145321", new DateTime(2000, 10, 21), "itau@gmail.com", new DateOnly(2018, 08, 15), new DateOnly(2022, 08, 15)));
            prestadores.Add(new Prestador(3, "Coca-Cola", "Coca Cola ltda", "67.541.165/0001-21", "670965543", new DateTime(1960, 11, 31), "cocacola@gmail.com", new DateOnly(2015, 12, 27), new DateOnly(2019, 12, 27)));
            prestadores.Add(new Prestador(4, "Vivo", "Vivo Comunicações", "10.786.984/0001-15", "679281547", new DateTime(1980, 01, 01), "vivo@gmail.com", new DateOnly(2019, 02, 03), new DateOnly(2023, 02, 03)));
            prestadores.Add(new Prestador(5, "ContaAzul", "ContaAzul Banco Múltiplo S.A", "11.470.254/0001-88", "671893043", new DateTime(1974, 08, 21), "contaazul@gmail.com", new DateOnly(2020, 11, 12), new DateOnly(2024, 11, 12)));
        }
    }
}