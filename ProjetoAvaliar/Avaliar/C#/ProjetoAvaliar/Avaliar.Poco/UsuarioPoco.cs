
namespace Avaliar.Poco
{
    public class UsuarioPoco
    {
        public int CodigoUsuario { get; set; }
        public int CodigoTipoUsuario { get; set; }     
        public string Nome { get; set; } = null!;
        public string Sobrenome { get; set; } = null!;
        public string Email { get; set; } = null!;
        public bool? Ativo { get; set; }
        public DateTime? DataInclusao { get; set; }
    }
}
