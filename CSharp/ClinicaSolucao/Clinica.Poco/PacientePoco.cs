﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica.Poco
{
    public class PacientePoco
    {
        public int CodigoPaciente { get; set; }

        public string Nome { get; set; } = null!;

        public string Endereco { get; set; } = null!;

        public string Telefone { get; set; } = null!;

        public DateTime DataDeNascimento { get; set; }

        public int CodigoProfissao { get; set; }

        public string? CPF { get; set; }

        public bool? Situacao { get; set; }

        public DateTime? DataInclusao { get; set; }

        public DateTime? DataAlteracao { get; set; }

        public PacientePoco()
        { }
    }
}
