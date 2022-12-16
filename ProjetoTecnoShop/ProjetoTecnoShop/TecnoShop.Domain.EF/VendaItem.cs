using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TecnoShop.Domain.EF
{
    [Table(name: "venda_item", Schema = "DBO")]
    public partial class VendaItem
    {
        [Key]
        [Column(name: "venda_item_id")]
        public int CodigoVendaItem { get; set; }

        [Column(name: "venda_id")]
        public int CodigoVenda { get; set; }

        [Column(name: "item_id")]
        public int CodigoItem { get; set; }

        [Column(name: "produto_id")]
        public int CodigoProduto { get; set; }

        [Column(name: "quantidade")]
        public int Quantidade { get; set; }

        [Column(name: "preco_listado")]
        public decimal Preco { get; set; }

        [Column(name: "desconto")]
        public decimal Desconto { get; set; }

        [Column(name: "ativo")]
        public bool? Ativo { get; set; }
    }
}

