using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;


namespace Atacado.DB.EF.Database
{
    [Table("Tipo_Rebanho", Schema = "dbo")]
    public partial class TipoRebanho
    {
        //   [ID_Tipo][int] IDENTITY(1,1) NOT NULL,
        [Key]
        [Column("ID_Tipo")] //pode ser assim ou name:ID_Tipo
        public int CodigoTipo { get; set; }


        //   [Descricao] [varchar] (max) NOT NULL,
        [Column(name: "Descricao")]
        [Unicode(false)]
        public string Descricao { get; set; } = null!;

        //[Situacao][bit] NULL,
        [Column (name:"Situacao")]
        public bool? Situacao { get; set; }

        //[DataInclusao][datetime] NULL,
        [Column(name: "DataInclusao", TypeName = "datetime")]
        public DateTime? DataInclusao { get; set; }


        //[DataAlteracao][datetime] NULL,
        [Column(name: "DataAlteracao", TypeName = "datetime")]
        public DateTime? DataAlteracao { get; set; }


        //[DataExclusao][datetime] NULL,
        [Column(name: "DataExclusao", TypeName = "datetime")]
        public DateTime? DataExclusao { get; set; }
    }
}
