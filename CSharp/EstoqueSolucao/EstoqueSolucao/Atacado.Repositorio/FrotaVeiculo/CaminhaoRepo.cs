using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Atacado.DB.FakeDB.FrotaVeiculo;
using Atacado.Dominio.Estoque;
using Atacado.Repositorio.Base;
using Base.Dominio.Veiculo;

namespace Atacado.Repositorio.FrotaVeiculo
{
    public class CaminhaoRepo : BaseRepositorio<Caminhao>
    {
        private FrotaContexto contexto;

        public CaminhaoRepo()
        {
            this.contexto = new FrotaContexto();
        }
        public override Caminhao Create(Caminhao instancia)
        {
            return this.contexto.AddCaminhao(instancia);
        }
        public override Caminhao Delete(Caminhao instancia)
        {
            return this.Delete(instancia.Codigo);
        }
        public override Caminhao Delete(int chave)
        {
            Caminhao del = this.Read(chave);
            if (this.contexto.Caminhaos.Remove(del) == false)
            {
                return null;
            }
            else
            {
                return del;
            }
        }
        public override List<Caminhao> Read()
        {
            return this.contexto.Caminhaos;
        }
        public override Caminhao Read(int chave)
        {
            return this.contexto.Caminhaos.SingleOrDefault(cam => cam.Codigo == chave);
        }
        public override Caminhao Update(Caminhao instancia)
        {
            Caminhao atu = this.Read(instancia.Codigo);
            if (atu == null)
            {
                return null;
            }
            else
            {
                atu.Ativo = instancia.Ativo;
                atu.DataInclusao = instancia.DataInclusao;
                atu.Chassi = instancia.Chassi;
                atu.Cor = instancia.Cor;
                atu.Marca = instancia.Marca;
                atu.Modelo = instancia.Modelo;
                atu.Placa = instancia.Placa;
                atu.Pesobruto = instancia.Pesobruto;
                atu.PesoLiquido = instancia.PesoLiquido;
                atu.PesoTotal = instancia.PesoTotal;
                return atu;
            }
        }
    }
}
