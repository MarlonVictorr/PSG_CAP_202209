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
    [Table("Funcionario",Schema = "DBO")]
    public partial class Funcionario
    {
        [Key]
        public int CodigoFuncionario { get; set; }

        [Column(name:"Nome")]
        [Unicode(false)]
        [StringLength(50)]
        public string Nome { get; set; } = null!;

        [Column(name: "Email")]
        [Unicode(false)]
        [StringLength(50)]
        public string Email { get; set; } = null!;


        [Column(name: "Telefone")]
        [Unicode(false)]
        [StringLength(50)]
        public string Telefone { get; set; } = null!;

        [Column(name: "Usuario")]
        [Unicode(false)]
        [StringLength(50)]
        public string Usuario { get; set; } = null!;

        [Column(name: "Senha")]
        [Unicode(false)]
        [StringLength(50)]
        public string Senha { get; set; } = null!;

        [Column(name: "DataNascimento", TypeName = "datetime")]
        public DateTime DataNascimento { get; set; } 

        [Column(name: "Matricula")]
        [Unicode(false)]
        [StringLength(100)]
        public string Matricula { get; set; } = null!;


        [Column(name: "ContaCorrente")]
        [Unicode(false)]
        [StringLength(50)]
        public string ContaCorrente { get; set; } = null!;
    }
}



//[CodigoFuncionario][int] IDENTITY(1,1) NOT NULL,

//    [Nome] [varchar] (50) NOT NULL,

//    [Email] [varchar] (50) NOT NULL,

//    [Telefone] [varchar] (50) NOT NULL,

//    [Usuario] [varchar] (50) NOT NULL,

//    [Senha] [varchar] (50) NOT NULL,

//    [DataNascimento] [datetime] NOT NULL,

//    [Matricula] [varchar] (100) NOT NULL,

//    [ContaCorrente] [varchar] (50) NOT NULL,