using Avaliar.Poco;
using DevTec.Envelope.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avaliar.Envelope.Modelo
{
    public class TipoUsuarioEnvelope : BaseEnvelope
    {
        public int CodigoTipoUsuario { get; set; }
        public string Descricao { get; set; } = null!;
        public bool? Ativo { get; set; }
        public DateTime? DataInclusao { get; set; }

        public TipoUsuarioEnvelope(TipoUsuarioPoco poco)
        {
            CodigoTipoUsuario = poco.CodigoTipoUsuario;
            Descricao = poco.Descricao;
            Ativo = poco.Ativo;
            DataInclusao = poco.DataInclusao;
        }

        public override void SetLinks()
        {
            Links.List = "GET /tipousuario";
            Links.Self = "GET /tipousuario/" + CodigoTipoUsuario.ToString();
            Links.Exclude = "DELETE /tipousuario/" + CodigoTipoUsuario.ToString();
            Links.Update = "PUT /tipousuario";
        }
    }
}
