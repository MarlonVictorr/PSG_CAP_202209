using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Atacado.Poco.Estoque;
using Atacado.Servico.Estoque;
using Microsoft.IdentityModel.Tokens;

namespace AtacadoApi.Controllers
{
    [Route("api/estoque/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private CategoriaServico servico;
        public CategoriaController() : base()
        {
            this.servico = new CategoriaServico();
        }

        [HttpGet]
        public List<CategoriaPoco> GetAll()
        {
            return this.servico.Browse();
        }

        [HttpGet("{codigo:int}")]
        public CategoriaPoco GetPorId(int codigo)
        {
            return this.servico.Read(codigo);
        }

        [HttpPost]
        public CategoriaPoco Criar([FromBody] CategoriaPoco poco)
        {
            return this.servico.Add(poco);
        }

        [HttpPut]
        public CategoriaPoco Atualizar([FromBody] CategoriaPoco poco)
        {
            return this.servico.Edit(poco);
        }

        [HttpDelete("{codigo:int}")]
        public CategoriaPoco DeletePorId(int codigo)
        {
           return this.servico.Delete(codigo);
        }

        [HttpDelete]
        public CategoriaPoco DeletePorInstancia([FromBody] CategoriaPoco poco)
        {
            return this.servico.Delete(poco);
        }

    }
}
