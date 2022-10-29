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
    public class MotocicletaServico : BaseServico<MotocicletaPoco, Motocicleta>
    {
        private MotocicletaRepo repo;

        public MotocicletaServico()
        {
            this.repo = new MotocicletaRepo();
        }

        public override MotocicletaPoco Add(MotocicletaPoco poco)
        {
            Motocicleta nova = this.ConvertTo(poco);
            Motocicleta criada = this.repo.Create(nova);
            return this.ConvertTo(criada);
        }

        public override List<MotocicletaPoco> Browse()
        {
            List<MotocicletaPoco> listaPoco = this.repo.Read()
                .Select(mo =>
                    new MotocicletaPoco()
                    {
                        Ativo = mo.Ativo,
                        Codigo = mo.Codigo,
                        DataInclusao = mo.DataInclusao,
                        Chassi = mo.Chassi,
                        Cor = mo.Cor,
                        Marca = mo.Marca,
                        Modelo = mo.Modelo,
                        Placa = mo.Placa,
                        Pesobruto = mo.Pesobruto,
                        PesoLiquido = mo.PesoLiquido,
                        PesoTotal = mo.PesoTotal
                    }
                )
                .ToList();
            return listaPoco;
        }

        public override MotocicletaPoco ConvertTo(Motocicleta dominio)
        {
            return new MotocicletaPoco()
            {
                Ativo = dominio.Ativo,
                Codigo = dominio.Codigo,
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

        public override Motocicleta ConvertTo(MotocicletaPoco poco)
        {
            return new Motocicleta(poco.Codigo, poco.Ativo, poco.DataInclusao, poco.Chassi, poco.Cor, poco.Marca, poco.Modelo, poco.Placa, poco.Pesobruto, poco.PesoLiquido, poco.PesoTotal);
        }

        public override MotocicletaPoco Delete(int chave)
        {
            Motocicleta del = this.repo.Delete(chave);
            MotocicletaPoco delPoco = this.ConvertTo(del);
            return delPoco;
        }

        public override MotocicletaPoco Delete(MotocicletaPoco poco)
        {
            Motocicleta del = this.repo.Delete(poco.Codigo);
            MotocicletaPoco delPoco = this.ConvertTo(del);
            return delPoco;
        }

        public override MotocicletaPoco Edit(MotocicletaPoco poco)
        {
            Motocicleta editada = this.ConvertTo(poco);
            Motocicleta alterada = this.repo.Update(editada);
            MotocicletaPoco alteradaPoco = this.ConvertTo(alterada);
            return alteradaPoco;
        }

        public override MotocicletaPoco Read(int chave)
        {
            Motocicleta lida = this.repo.Read(chave);
            MotocicletaPoco lidaPoco = this.ConvertTo(lida);
            return lidaPoco;
        }
    }
}
