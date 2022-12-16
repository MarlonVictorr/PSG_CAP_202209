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
    [Table(name: "Marca", Schema = "DBO")]
    public partial class Marca
    {
        [Key]
        [Column(name: "marca_id")]
        public int CodigoMarca { get; set; }

        [Column(name: "marca_nome")]
        [Unicode(false)]
        [StringLength(255)]
        public string NomeMarca { get; set; } = null!;

        [Column(name: "ativo")]
        public bool? Ativo { get; set; }
    }
}

