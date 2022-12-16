

namespace TecnoShop.Poco
{
    public class ProdutoPoco
    {
        public int CodigoProduto { get; set; }
        public string NomeProduto { get; set; } = null!;
        public int CodigoMarca { get; set; }
        public int CodigoCategoria { get; set; }
        public int AnoModelo { get; set; }
        public decimal Preco { get; set; }
        public bool? Ativo { get; set; }
    }
}
