﻿using Atacado.Dominio.FrotaVeiculo;
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
    public class CarroServico : BaseServico<CarroPoco, Carro>
    {
        private CarroRepo repo;

        public CarroServico() : base()
        {
            this.repo = new CarroRepo();
        }

        public override CarroPoco Add(CarroPoco poco)
        {
            Carro nova = this.ConvertTo(poco);
            Carro criada = this.repo.Create(nova);
            return this.ConvertTo(criada);
        }

        public override List<CarroPoco> Browse()
        {
            List<CarroPoco> listapoco = this.repo.Read()
                .Select(cam =>
                new CarroPoco()
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
                    PesoTotal = cam.PesoTotal,
                    NumPassageiros = cam.NumPassageiros
                }
                
             )
                .ToList();
            return listapoco;
        }

        public override CarroPoco ConvertTo(Carro dominio)
        {
            return new CarroPoco()
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
                PesoTotal = dominio.PesoTotal,
                NumPassageiros = dominio.NumPassageiros
            };
        }

        public override Carro ConvertTo(CarroPoco poco)
        {
            return new Carro(poco.Codigo, poco.Ativo, poco.DataInclusao, poco.Chassi, poco.Cor, poco.Marca, poco.Modelo, poco.Placa, poco.Pesobruto, poco.PesoLiquido, poco.PesoTotal, poco.NumPassageiros);
        }

        public override CarroPoco Delete(int chave)
        {
            Carro del = this.repo.Delete(chave);
            CarroPoco delPoco = this.ConvertTo(del);
            return delPoco;
        }

        public override CarroPoco Delete(CarroPoco poco)
        {
            Carro del = this.repo.Delete(poco.Codigo);
            CarroPoco delPoco = this.ConvertTo(del);
            return delPoco;
        }

        public override CarroPoco Edit(CarroPoco poco)
        {
            Carro editada = this.ConvertTo(poco);
            Carro alterada = this.repo.Update(editada);
            CarroPoco alteradaPoco = this.ConvertTo(alterada);
            return alteradaPoco;
        }

        public override CarroPoco Read(int chave)
        {
            Carro lida = this.repo.Read(chave);
            CarroPoco lidaPoco = this.ConvertTo(lida);
            return lidaPoco;
        }
    }
}
