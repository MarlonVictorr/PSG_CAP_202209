using Avaliar.Poco;
using DevTec.Envelope.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avaliar.Envelope.Modelo
{
    public class UsuarioEnvelope : BaseEnvelope
    {
        public int CodigoUsuario { get; set; }
        public int CodigoTipoUsuario { get; set; }
        public string Nome { get; set; } = null!;
        public string Sobrenome { get; set; } = null!;
        public string Email { get; set; } = null!;
        public bool? Ativo { get; set; }
        public DateTime? DataInclusao { get; set; }

        public UsuarioEnvelope(UsuarioPoco poco)
        {
            CodigoUsuario = poco.CodigoUsuario;
            CodigoTipoUsuario = poco.CodigoTipoUsuario;
            Nome = poco.Nome;
            Sobrenome = poco.Sobrenome;
            Email = poco.Email;
            Ativo = poco.Ativo;
            DataInclusao = poco.DataInclusao;
        }

        public override void SetLinks()
        {
            Links.List = "GET /usuario";
            Links.Self = "GET /usuario/" + CodigoUsuario.ToString();
            Links.Exclude = "DELETE /usuario/" + CodigoUsuario.ToString();
            Links.Update = "PUT /cidade";
        }
    }
}
