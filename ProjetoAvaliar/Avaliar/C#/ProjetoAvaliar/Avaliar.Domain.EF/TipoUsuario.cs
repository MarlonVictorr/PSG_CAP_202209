using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Avaliar.Domain.EF
{
    [Table(name: "TipoUsuario", Schema = "DBO")]
    public partial class TipoUsuario
    {
        [Key]
        [Column(name: "IdTipoUsuario")]
        public int CodigoTipoUsuario { get; set; }

        [Column(name: "Descricao")]
        [Unicode(false)]
        public string Descricao { get; set; } = null!;

        [Column(name: "Ativo")]
        public bool? Ativo { get; set; }

        [Column(name: "DataInclusao", TypeName = "datetime")]
        public DateTime? DataInclusao { get; set; }
    }
}
