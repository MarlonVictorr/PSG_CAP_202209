﻿using Atacado.Poco.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.Poco.FrotaVeiculo
{
    public class EventoFrotaPoco : BaseCampos
    {
        private string condutor;
        private DateOnly dataInicial;
        private DateOnly dataFinal;
        private int kmInicial;
        private int kmFinal;
        private string motivoEvento;
        private int codigoFrota;

        public string Condutor { get => condutor; set => condutor = value; }
        public DateOnly DataInicial { get => dataInicial; set => dataInicial = value; }
        public DateOnly DataFinal { get => dataFinal; set => dataFinal = value; }
        public int KmInicial { get => kmInicial; set => kmInicial = value; }
        public int KmFinal { get => kmFinal; set => kmFinal = value; }
        public string MotivoEvento { get => motivoEvento; set => motivoEvento = value; }
        public int CodigoFrota { get => codigoFrota; set => codigoFrota = value; }
       
        public EventoFrotaPoco() : base()
        { }

        public EventoFrotaPoco(int codigo, bool ativo, DateTime dataInclusao, string condutor,
            DateOnly dataInicial, DateOnly dataFinal, int kmInicial, int kmFinal, string motivoEvento,
            int codigoFrota)
            : base(codigo, ativo, dataInclusao)
        {
            this.condutor = condutor;
            this.dataInicial = dataInicial;
            this.dataFinal = dataFinal;
            this.kmInicial = kmInicial;
            this.kmFinal = kmFinal;
            this.motivoEvento = motivoEvento;
            this.codigoFrota = codigoFrota;
        }
    }
}
