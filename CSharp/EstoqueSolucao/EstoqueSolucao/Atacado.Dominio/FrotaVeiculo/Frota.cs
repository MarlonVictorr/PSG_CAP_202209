using Base.Dominio.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Dominio.FrotaVeiculo
{
    public class Frota : BaseCampos
    {
        private string finalidade;
        private int veiculos;
        private List<EventoFrota> eventos;

        public string Finalidade { get => finalidade; set => finalidade = value; }
        public int Veiculos { get => veiculos; set => veiculos = value; }

        public List<EventoFrota> Eventos { get => eventos; set => eventos = value; }
        

        public Frota() : base()
        {
            this.eventos = new List<EventoFrota>();
        }

        public Frota(int codigo, bool ativo, DateTime dataInclusao, string finalidade, int veiculos, List<EventoFrota> eventos) 
            : base(codigo, ativo, dataInclusao)
        {
            this.finalidade = finalidade;
            this.veiculos = veiculos;
            this.eventos = eventos;
        }
    }
}
