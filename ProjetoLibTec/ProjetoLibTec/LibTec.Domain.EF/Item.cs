using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace LibTec.Domain.EF
{
    [Table("Item", Schema = "DBO")]
    public partial class Item
    {
        [Key]
        public int Codigo { get; set; }

        [Column(name: "Descricao")]
        [Unicode(false)]
        public string Descricao { get; set; } = null!;

        [Column(name: "ISBN")]
        [Unicode(false)]
        [StringLength(255)]
        public string ISBN { get; set; } = null!;

        [Column(name: "Observacoes")]
        [Unicode(false)]
        public string Observacoes { get; set; } = null!;


        [Column(name: "CodigoTipoItem")]
        public int CodigoTipoItem { get; set; }

        [Column(name: "Ativo")]
        public bool? Ativo { get; set; }

        [Column(name: "DataInclusao", TypeName = "datetime")]
        public DateTime? DataInclusao { get; set; }

        [Column(name: "DataAlteracao", TypeName = "datetime")]
        public DateTime? DataAlteracao { get; set; }

        [Column(name: "DataExclusao", TypeName = "datetime")]
        public DateTime? DataExclusao { get; set; }
    }
}