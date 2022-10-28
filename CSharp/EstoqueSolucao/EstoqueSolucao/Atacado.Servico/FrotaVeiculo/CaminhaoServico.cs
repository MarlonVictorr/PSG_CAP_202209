﻿using Atacado.Dominio.Estoque;
using Atacado.Dominio.FrotaVeiculo;
using Atacado.Poco.Estoque;
using Atacado.Poco.FrotaVeiculo;
using Atacado.Repositorio.FrotaVeiculo;
using Atacado.Servico.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.Servico.FrotaVeiculo
{
    public class CaminhaoServico : BaseServico<CaminhaoPoco, Caminhao>
    {
        private CaminhaoRepo repo;

        public CaminhaoServico() : base()
        {
            this.repo = new CaminhaoRepo();
        }
        public override CaminhaoPoco Add(CaminhaoPoco poco)
        {
            Caminhao nova = this.ConvertTo(poco);
            Caminhao criada = this.repo.Create(nova);
            CaminhaoPoco criadaPoco = this.ConvertTo(criada);
            return criadaPoco;
        }

        public override List<CaminhaoPoco> Browse()
        {
            List<CaminhaoPoco> listapoco = this.repo.Read()
                 .Select(cam =>
                 new CaminhaoPoco()
                 {
                     Codigo = cam.Codigo,
                     Ativo = cam.Ativo,
                     DataInclusao = cam.DataInclusao,
                     Chassi = cam.Chassi,
                     Cor = cam.Cor,
                     Marca = cam.Marca,
                     Modelo = cam.Modelo,
                     Placa = cam.Placa,
                     Pesobruto = cam.Pesobruto,
                     PesoLiquido = cam.PesoLiquido,
                     PesoTotal = cam.PesoTotal
                 }
             )
             .ToList();
            return listapoco;
        }

        public override CaminhaoPoco ConvertTo(Caminhao dominio)
        {
            return new CaminhaoPoco()
            {
                Codigo = dominio.Codigo,
                Ativo = dominio.Ativo,
                DataInclusao = dominio.DataInclusao,
                Chassi = dominio.Chassi,
                Cor = dominio.Cor,
                Marca = dominio.Marca,
                Modelo = dominio.Modelo,
                Placa = dominio.Placa,
                Pesobruto = dominio.Pesobruto,
                PesoLiquido = dominio.PesoLiquido,
                PesoTotal = dominio.PesoTotal
            };
        }

        public override Caminhao ConvertTo(CaminhaoPoco poco)
        {
            return new Caminhao(poco.Codigo, poco.Ativo, poco.DataInclusao, poco.Chassi, poco.Cor, poco.Marca, poco.Modelo, poco.Placa, poco.Pesobruto, poco.PesoLiquido, poco.PesoTotal);
        }

        public override CaminhaoPoco Delete(int chave)
        {
            Caminhao del = this.repo.Delete(chave);
            CaminhaoPoco delPoco = this.ConvertTo(del);
            return delPoco;
        }

        public override CaminhaoPoco Delete(CaminhaoPoco poco)
        {
            Caminhao del = this.repo.Delete(poco.Codigo);
            CaminhaoPoco delPoco = this.ConvertTo(del);
            return delPoco;
        }

        public override CaminhaoPoco Edit(CaminhaoPoco poco)
        {
            Caminhao editada = this.ConvertTo(poco);
            Caminhao alterada = this.repo.Update(editada);
            CaminhaoPoco alteradaPoco = this.ConvertTo(alterada);
            return alteradaPoco;

        }

        public override CaminhaoPoco Read(int chave)
        {
            Caminhao lida = this.repo.Read(chave);
            CaminhaoPoco lidaPoco = this.ConvertTo(lida);
            return lidaPoco;
        }
    }
}
