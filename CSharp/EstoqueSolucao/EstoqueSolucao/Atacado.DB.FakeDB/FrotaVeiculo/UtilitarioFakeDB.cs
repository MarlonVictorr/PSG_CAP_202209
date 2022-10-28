using Base.Dominio.Veiculo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.DB.FakeDB.FrotaVeiculo
{
    public static class UtilitarioFakeDB
    {
        private static List<Utilitario> utilitarios;

        public static List<Utilitario> Utilitarios
        {
            get
            {
                if (utilitarios == null)
                {
                    utilitarios = new List<Utilitario>();
                    Carregar();
                }
                return utilitarios;
            }
        }
        private static void Carregar()
        {
            utilitarios.Add(new Utilitario(1, true, DateTime.Now, "891 A96NmA vk V15873", "branco", "Mini", "furgão", "rio 2a18", 3.500, 3.300,6.800));
            utilitarios.Add(new Utilitario(2, true, DateTime.Now, "8A7 D9Fv4e A6 zG1450", "preto", "Fiat", "Fiorino", "qut 4f19", 3.300, 3.100, 6.400));
            utilitarios.Add(new Utilitario(3, true, DateTime.Now, "3AE KZAaK9 7t X34538", "azul", "Volskvawen", "Kombi", "nfs 9j43", 3.100, 3.000, 6.100));
            utilitarios.Add(new Utilitario(4, true, DateTime.Now, "30A 02AwV4 T6 Ep9425", "amarelo", "Renault", "Duster", "ndt 5r63", 3.000, 2.900, 5.900));
            utilitarios.Add(new Utilitario(5, true, DateTime.Now, "7E0 PAM16V 3d GB4414", "vermelho", "Minivan", "Doblô", "rew 6v32", 3.250, 3.100, 6.350));
        }
    }
}
