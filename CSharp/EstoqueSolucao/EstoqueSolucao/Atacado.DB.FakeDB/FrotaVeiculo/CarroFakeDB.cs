using Base.Dominio.Veiculo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.DB.FakeDB.FrotaVeiculo
{
    public static class CarroFakeDB
    {
        private static List<Carro> carros;

        public static List<Carro> Carros
        {
            get
            {
                if (carros == null)
                {
                    carros = new List<Carro>();
                    Carregar();
                }
                return carros;
            }
        }
        private static void Carregar()
        {
            carros.Add(new Carro(1, true, DateTime.Now, "891 A96NmA vk V15873", "branco", "volkswagen", "gol", "rio 2a18", 921, 700, 1621, 2));
            carros.Add(new Carro(2, true, DateTime.Now, "8A7 D9Fv4e A6 zG1450", "preto", "fiat", "palio", "qut 4f19", 800, 650, 1450, 1));
            carros.Add(new Carro(3, true, DateTime.Now, "3AE KZAaK9 7t X34538", "azul", "ford", "ka", "nfs 9j43", 800, 750, 1550, 2));
            carros.Add(new Carro(4, true, DateTime.Now, "30A 02AwV4 T6 Ep9425", "amarelo", "chevrolet", "prisma", "ndt 5r63", 750, 700, 1450, 1));
            carros.Add(new Carro(5, true, DateTime.Now, "7E0 PAM16V 3d GB4414", "vermelho", "hyundai", "hb20", "rew 6v32", 790, 600, 1390, 1));
        }
    }
}

