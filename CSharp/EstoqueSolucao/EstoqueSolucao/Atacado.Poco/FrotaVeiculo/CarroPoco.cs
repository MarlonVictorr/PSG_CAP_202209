﻿using Atacado.Poco.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.Poco.FrotaVeiculo
{
    public class CarroPoco : BasePesoCarga
    {
        private int numPassageiros;
        public int NumPassageiros { get => numPassageiros; set => numPassageiros = value; }

        public CarroPoco()
        { }

    }
}
