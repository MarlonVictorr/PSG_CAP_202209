using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Dominio.Base
{
    public abstract class BaseCampos
    {
        protected int codigo;
        protected bool ativo;
        protected DateTime dataInclusao;

        public int Codigo { get => codigo; set => codigo = value; }
        public bool Ativo { get => ativo; set => ativo = value; }
        public DateTime DataInclusao { get => dataInclusao; set => dataInclusao = value; }

        public BaseCampos()
        { }

        protected BaseCampos(int codigo, bool ativo, DateTime dataInclusao)
        {
            this.codigo = codigo;
            this.ativo = ativo;
            this.dataInclusao = dataInclusao;
        }
    }
}
