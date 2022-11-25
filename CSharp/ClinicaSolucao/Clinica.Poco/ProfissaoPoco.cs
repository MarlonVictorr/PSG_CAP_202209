using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica.Poco
{
    public class ProfissaoPoco
    {
        public int CodigoProfissao { get; set; }

        public string Descricao { get; set; } = null!;

        public DateTime? DataInclusao { get; set; }

        public bool? Ativo { get; set; }

        public ProfissaoPoco()
        { }
    }
}
