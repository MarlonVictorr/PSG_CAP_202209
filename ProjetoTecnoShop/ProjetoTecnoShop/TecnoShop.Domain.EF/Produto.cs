﻿using Microsoft.EntityFrameworkCore;
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
    [Table(name: "Produto", Schema = "DBO")]
    public partial class Produto
    {
        [Key]
        [Column(name: "produto_id")]
        public int CodigoProduto { get; set; }

        [Column(name: "produto_nome")]
        [Unicode(false)]
        [StringLength(255)]
        public string NomeProduto { get; set; } = null!;

        [Column(name: "marca_id")]
        public int CodigoMarca { get; set; }

        [Column(name: "categoria_id")]
        public int CodigoCategoria { get; set; }

        [Column(name: "ano_modelo")]
        public int AnoModelo { get; set; }

        [Column(name: "preco_listado")]
        public decimal Preco { get; set; }

        [Column(name: "ativo")]
        public bool? Ativo { get; set; }
    }
}