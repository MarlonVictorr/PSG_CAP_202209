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
    [Table(name:"Categoria",Schema ="DBO")]
    public partial class Categoria
    {
        [Key]
        [Column(name: "categoria_id")]
        public int CodigoCategoria { get; set; }

        [Column(name: "categoria_nome")]
        [Unicode(false)]
        [StringLength(255)]
        public string Nome { get; set; } = null!;

        [Column(name: "ativo")]
        public bool? Ativo { get; set; }
    }
}


