using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace TecnoShop.Domain.EF
{
    [Table(name: "Cidade", Schema = "DBO")]
    public partial class Cidade
    {
        [Key]
        [Column(name: "cidade_id")]
        public int CodigoCidade { get; set; }

        [Column(name: "nome")]
        [Unicode(false)]
        public string Nome { get; set; } = null!;

        [Column(name: "codigo_ibge7")]
        public int CodigoIBGE7 { get; set; }

        [Column(name: "estado_id")]
        public int CodigoEstado { get; set; }
    }
}

