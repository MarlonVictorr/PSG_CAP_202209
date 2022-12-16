namespace TecnoShop.Poco
{
    public class GerentePoco
    {
        public int CodigoGerente { get; set; }
        public string PrimeiroNome { get; set; } = null!;
        public string SobreNome { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Telefone { get; set; }
        public bool? Ativo { get; set; }
        public int CodigoLoja { get; set; }
    }
}
