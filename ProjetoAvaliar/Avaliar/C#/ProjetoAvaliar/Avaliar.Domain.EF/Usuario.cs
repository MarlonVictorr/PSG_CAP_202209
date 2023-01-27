using Avaliar.Domain.EF;
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
    [Table(name: "Usuario", Schema = "DBO")]
    public partial class Usuario
    {

        [Key]
        [Column(name: "IdUsuario")]
        public int CodigoUsuario { get; set; }

        [Column(name: "IdTipoUsuario")]
        public int CodigoTipoUsuario { get; set; }

        [Column(name: "Nome")]
        [Unicode(false)]
        [StringLength(255)]
        public string Nome { get; set; } = null!;

        [Column(name: "Sobrenome")]
        [Unicode(false)]
        [StringLength(255)]
        public string Sobrenome { get; set; } = null!;

        [Column(name: "Email")]
        [Unicode(false)]
        [StringLength(255)]
        public string Email { get; set; } = null!;

        [Column(name: "Ativo")]
        public bool? Ativo { get; set; }

        [Column(name: "DataInclusao", TypeName = "datetime")]
        public DateTime? DataInclusao { get; set; }
    }
}


