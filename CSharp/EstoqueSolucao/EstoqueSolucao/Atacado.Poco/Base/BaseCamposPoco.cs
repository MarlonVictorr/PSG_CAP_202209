﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.Poco.Base
{
    public abstract class BaseCamposPoco
    {
        protected int codigo;
        protected bool ativo;
        protected DateTime dataInclusao;

        public int Codigo { get => codigo; set => codigo = value; }
        public bool Ativo { get => ativo; set => ativo = value; }
        public DateTime DataInclusao { get => dataInclusao; set => dataInclusao = value; }
        public BaseCamposPoco()
        { }
    }
}
