using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Revisao.Dominio.EF
{
    [Table("Bilhete",Schema = "DBO")]
    public partial class Bilhete
    {
        [Key]
        public int CodigoBilhete { get; set; }

        [Column(name: "NumeroBilhete")]
        public int NumeroBilhete { get; set; }

        [Column(name: "Assento")]
        [Unicode(false)]
        [StringLength(4)]
        public string Assento { get; set; } = null!;
    }
}
