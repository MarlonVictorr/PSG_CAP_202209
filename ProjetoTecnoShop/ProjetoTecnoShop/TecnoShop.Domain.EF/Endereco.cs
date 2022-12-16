using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TecnoShop.Domain.EF
{
    [Table(name: "Endereco", Schema = "DBO")]
    public partial class Endereco
    {
        [Key]
        [Column(name: "endereco_id")]
        public int CodigoEndereco { get; set; }

        [Column(name: "rua")]
        [Unicode(false)]
        [StringLength(100)]
        public string Rua { get; set; } = null!;

        [Column(name: "numero")]
        public int Numero { get; set; }

        [Column(name: "complemento")]
        [Unicode(false)]
        [StringLength(255)]
        public string Complemento { get; set; } = null!;

        [Column(name: "bairro")]
        [Unicode(false)]
        [StringLength(100)]
        public string Bairro { get; set; } = null!;

        [Column(name: "cep")]
        [Unicode(false)]
        [StringLength(9)]
        public string CEP { get; set; } = null!;

        [Column(name: "cidade_id")]
        public int CodigoCidade { get; set; }
    }
}


