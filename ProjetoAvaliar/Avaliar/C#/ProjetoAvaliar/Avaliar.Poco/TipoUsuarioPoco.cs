
namespace Avaliar.Poco
{
    public class TipoUsuarioPoco
    {
        public int CodigoTipoUsuario { get; set; }
        public string Descricao { get; set; } = null!;
        public bool? Ativo { get; set; }
        public DateTime? DataInclusao { get; set; }
    }
}
