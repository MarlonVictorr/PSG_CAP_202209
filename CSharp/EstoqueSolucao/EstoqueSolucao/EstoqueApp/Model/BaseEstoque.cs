using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstoqueApp.Model
{
    public abstract class BaseEstoque
    {
        protected int codigo;

        protected string descricao;

        protected bool ativo;

        protected DateTime dataInclusao;
    }
}
