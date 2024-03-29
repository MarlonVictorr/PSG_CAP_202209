﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.Poco.Base
{
    public abstract class BasePesoCargaPoco : BaseVeiculoPoco
    {
        protected double pesobruto;
        protected double pesoLiquido;
        protected double pesoTotal;

        public double PesoLiquido { get => pesoLiquido; set => pesoLiquido = value; }
        public double Pesobruto { get => pesobruto; set => pesobruto = value; }
        public double PesoTotal { get => pesoTotal; set => pesoTotal = value; }
        public BasePesoCargaPoco() : base()
        { }
    }
}
