﻿using Microsoft.EntityFrameworkCore;
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
    [Table("Usuario", Schema = "DBO")]
    public partial class Usuario
    {
        [Key]
        public int Codigo { get; set; }

        [Column(name: "Nome")]
        [Unicode(false)]
        public string Nome { get; set; } = null!;

        [Column(name: "Sobrenome")]
        [Unicode(false)]
        public string Sobrenome { get; set; } = null!;

        [Column(name: "Senha")]
        [Unicode(false)]
        [StringLength(255)]
        public string Senha { get; set; } = null!;

        [Column(name: "Email")]
        [Unicode(false)]
        public string Email { get; set; } = null!;

        [Column(name: "MaxEmprestimos")]
        public int MaxEmprestimos { get; set; }

        [Column(name: "CodigoTipoUsuario")]
        public int CodigoTipoUsuario { get; set; }

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
