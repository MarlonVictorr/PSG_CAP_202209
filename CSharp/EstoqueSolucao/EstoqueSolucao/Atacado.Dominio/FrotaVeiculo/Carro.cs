using Base.Dominio.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Dominio.Veiculo
{
    public class Carro : BasePesoCarga
    {
        private int numPassageiros;
        public int NumPassageiros { get => numPassageiros; set => numPassageiros = value; }

        public Carro() : base()
        { }

        public Carro(int codigo, bool ativo, DateTime dataInclusao, string chassi, string cor,
            string marca, string modelo, string placa, double pesobruto, double pesoLiquido, double pesoTotal, int numPassageiros)
            : base(codigo, ativo, dataInclusao, chassi, cor, marca, modelo, placa, pesobruto, pesoLiquido, pesoTotal)
        {
            this.numPassageiros = numPassageiros;
        }
    }
}
