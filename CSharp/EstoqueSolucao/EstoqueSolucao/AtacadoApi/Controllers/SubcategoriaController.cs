using Atacado.Poco.Estoque;
using Atacado.Repositorio.Estoque;
using Atacado.Servico.Estoque;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AtacadoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubcategoriaController : ControllerBase
    {
        private SubcategoriaServico servico;

        public SubcategoriaController() : base()
        {
            this.servico = new SubcategoriaServico();
        }

        [HttpGet]
        public List<SubcategoriaPoco> GetAll()
        {
            return this.servico.Browse();
        }

        [HttpGet("{codigo:int}")]
        public SubcategoriaPoco GetPorId(int codigo)
        {
            return this.servico.Read(codigo);
        }

        [HttpPost]
        public SubcategoriaPoco Criar([FromBody] SubcategoriaPoco poco)
        {
            return this.servico.Add(poco);
        }

        [HttpPut]
        public SubcategoriaPoco Atualizar([FromBody] SubcategoriaPoco poco)
        {
            return this.servico.Edit(poco);
        }

        [HttpDelete("{codigo:int}")]
        public SubcategoriaPoco DeletePorId(int codigo)
        {
            return this.servico.Delete(codigo); 
        }

        [HttpDelete]
        public SubcategoriaPoco DeletePorInstancia([FromBody] SubcategoriaPoco poco)
        {
            return this.servico.Delete(poco);
        }
    }
}
