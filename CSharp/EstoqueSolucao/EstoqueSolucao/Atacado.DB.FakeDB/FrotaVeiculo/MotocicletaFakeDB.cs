using Atacado.Dominio.FrotaVeiculo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.DB.FakeDB.FrotaVeiculo
{
    public static class MotocicletaFakeDB
    {
        private static List<Motocicleta> motocicletas;

        public static List<Motocicleta> Motocicletas
        {
            get
            {
                if (motocicletas == null)
                {
                    motocicletas = new List<Motocicleta>();
                    Carregar();
                }
                return motocicletas;
            }
        }
        private static void Carregar()
        {
            motocicletas.Add(new Motocicleta(1, true, DateTime.Now, "1hu 3LrKnJ w7 5z0202", "Preto", "Bmw", "F 850", "brk 2k20", 116, 130, 246));
            motocicletas.Add(new Motocicleta(2, true, DateTime.Now, "2rt 2artsj v8 6i4902", "Amarelo", "Honda", "Fan", "wtx 9h32", 118, 132, 250));
            motocicletas.Add(new Motocicleta(3, true, DateTime.Now, "8qs 4shamd q1 7r3142", "Roxo", "Honda", "Biz", "wqt 0g21", 120, 135, 255));
            motocicletas.Add(new Motocicleta(4, true, DateTime.Now, "6rd 2awqvc e3 2e7564", "Branco", "Honda", "xre", "fvt 4r23", 110, 120, 230));
            motocicletas.Add(new Motocicleta(5, true, DateTime.Now, "9ps 9dhaki 8u 4s9654", "Azul", "yamaha", "Factor", "rqa 6t43", 140, 145, 285));
        }
    }
}
