using Atacado.Dominio.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.Dominio.Base
{
    public abstract class BasePesoCarga : BaseVeiculo
    {
        protected double pesobruto;
        protected double pesoLiquido;
        protected double pesoTotal;

        public double Pesobruto { get => pesobruto; set => pesobruto = value; }
        public double PesoLiquido { get => pesoLiquido; set => pesoLiquido = value; }
        public double PesoTotal { get => pesoTotal; set => pesoTotal = value; }

        public BasePesoCarga() : base()
        { }

        public BasePesoCarga(int codigo, bool ativo, DateTime dataInclusao, string chassi, string cor, string marca, string modelo, string placa, double pesobruto, double pesoLiquido, double pesoTotal)
            : base(codigo, ativo, dataInclusao, chassi, cor, marca, modelo, placa)
        {
            this.pesobruto = pesobruto;
            this.pesoLiquido = pesoLiquido;
            this.pesoTotal = pesoTotal;
        }
    }
}
