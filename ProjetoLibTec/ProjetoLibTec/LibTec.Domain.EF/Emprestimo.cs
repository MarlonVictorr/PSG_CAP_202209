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
    [Table("Emprestimo", Schema = "DBO")]
    public partial class Emprestimo
    {
        [Key]
        public int Codigo { get; set; }

        [Column(name: "CodigoUsuario")]
        public int CodigoUsuario { get; set; }

        [Column(name: "CodigoItem")]
        public int CodigoItem { get; set; }

        [Column(name: "QtdRenovado")]
        public int? QuantidadeRenovado { get; set; }

        [Column(name: "DataSaida", TypeName = "datetime")]
        public DateTime DataSaida { get; set; }

        [Column(name: "DataExpiracao", TypeName = "datetime")]
        public DateTime DataExpiracao { get; set; }

        [Column(name: "DataRetorno", TypeName = "datetime")]
        public DateTime? DataRetorno { get; set; }

        [Column(name: "CodigoStatus")]
        public int CodigoStatus { get; set; }

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