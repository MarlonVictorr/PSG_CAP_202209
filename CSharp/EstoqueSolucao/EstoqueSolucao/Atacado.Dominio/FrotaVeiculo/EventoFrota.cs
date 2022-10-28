using Atacado.Dominio.Base;
using Atacado.Dominio.FrotaVeiculo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.Dominio.FrotaVeiculo
{
    public class EventoFrota : BaseCampos 
    {
        private string condutor;
        private DateOnly dataInicial;
        private DateOnly dataFinal;
        private int kmInicial;
        private int kmFinal;
        private string motivoEvento;
        

        public string Condutor { get => condutor; set => condutor = value; }
        public DateOnly DataInicial { get => dataInicial; set => dataInicial = value; }
        public DateOnly DataFinal { get => dataFinal; set => dataFinal = value; }
        public int KmInicial { get => kmInicial; set => kmInicial = value; }
        public int KmFinal { get => kmFinal; set => kmFinal = value; }
        public string MotivoEvento { get => motivoEvento; set => motivoEvento = value; }
       

        public EventoFrota() : base()
        { }

        public EventoFrota(int codigo, bool ativo, DateTime dataInclusao, string condutor, DateOnly dataInicial, DateOnly dataFinal, int kmInicial, int kmFinal, string motivoEvento) 
            : base(codigo, ativo, dataInclusao)
        {
            this.condutor = condutor;
            this.dataInicial = dataInicial;
            this.dataFinal = dataFinal;
            this.kmInicial = kmInicial;
            this.kmFinal = kmFinal;
            this.motivoEvento = motivoEvento;
        }
    }
}
