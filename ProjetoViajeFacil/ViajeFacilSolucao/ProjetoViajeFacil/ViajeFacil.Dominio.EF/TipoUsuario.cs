﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ViajeFacil.Dominio.EF
{
    [Table("Tipo_Usuario", Schema = "DBO")]
    public partial class TipoUsuario
    {
        [Key]
        [Column(name: "id_tipo_usuario")]
        public long CodigoTipoUsuario { get; set; }

        [Column(name: "descricao")]
        [Unicode(false)]
        [StringLength(50)]
        public string Descricao { get; set; } = null!;
    }
}




