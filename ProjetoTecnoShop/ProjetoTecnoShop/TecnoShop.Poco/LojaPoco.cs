
namespace TecnoShop.Poco
{
    public class LojaPoco
    {
        public int CodigoLoja { get; set; }
        public string Nome { get; set; } = null!;
        public string? Telefone { get; set; }
        public string? Email { get; set; }
        public int CodigoEndereco { get; set; }
        public bool? Ativo { get; set; }
    }
}
