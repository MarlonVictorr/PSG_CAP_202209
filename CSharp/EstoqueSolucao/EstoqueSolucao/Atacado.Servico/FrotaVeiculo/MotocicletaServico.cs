using Atacado.Dominio.FrotaVeiculo;
using Atacado.Repositorio.Base;
using Atacado.Repositorio.FrotaVeiculo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.Servico.FrotaVeiculo
{
    public class MotocicletaServico : BaseRepositorio<MotocicletaPoco, Motocicleta>
    {
        private MotocicletaRepo repo;
    }
}
