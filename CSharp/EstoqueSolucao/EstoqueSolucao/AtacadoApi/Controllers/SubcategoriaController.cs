using Atacado.Poco.Estoque;
using Atacado.Servico.Estoque;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AtacadoApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class SubcategoriaController : ControllerBase
    {
        private SubcategoriaServico servico;

        /// <summary>
        /// 
        /// </summary>
        public SubcategoriaController() : base()
        {
            this.servico = new SubcategoriaServico();
        }

        /// <summary>
        /// Listar todos os registros da tabela.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<SubcategoriaPoco>> GetAll()
        {
            try
            {
                List<SubcategoriaPoco> list = this.servico.Listar();
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Lista a subcategoria pelo código de categoria
        /// </summary>
        /// <param name="catid"></param>
        /// <returns></returns>
        [HttpGet("PorCategoria/{catid:int}")]
        public ActionResult<List<SubcategoriaPoco>> GetPorCategoria(int catid)
        {
            try
            {
                List<SubcategoriaPoco> ListPoco = this.servico.Consultar(sub => sub.CodigoCategoria == catid).ToList();
                return Ok(ListPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Lista a Subcategoria pelo código informado
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        [HttpGet("{codigo:int}")]
        public ActionResult<SubcategoriaPoco> GetPorId(int codigo)
        {
            try
            {
                SubcategoriaPoco poco = this.servico.PesquisarPelaChave(codigo);
                return Ok(poco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Cria um novo registro na tabela
        /// </summary>
        /// <param name="poco"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<SubcategoriaPoco> Criar([FromBody] SubcategoriaPoco poco)
        {
            try
            {
                SubcategoriaPoco nova = this.servico.Inserir(poco);
                return Ok(poco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Atualiza os dados da tabela 
        /// </summary>
        /// <param name="poco"></param>
        /// <returns></returns>
        [HttpPut]
        public ActionResult<SubcategoriaPoco> Atualizar([FromBody] SubcategoriaPoco poco)
        {
            try
            {
                SubcategoriaPoco atPoco = this.servico.Alterar(poco);
                return Ok(atPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Apaga um registro por codigo informado
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        [HttpDelete("{codigo:int}")]
        public ActionResult<SubcategoriaPoco> DeletePorId(int codigo)
        {
            try
            {
                SubcategoriaPoco delPoco = this.servico.Excluir(codigo);
                return Ok(delPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Apaga um registro de acordo com os dados informados 
        /// </summary>
        /// <param name="poco"></param>
        /// <returns></returns>
        [HttpDelete]
        public ActionResult<SubcategoriaPoco> DeletePorInstancia([FromBody] SubcategoriaPoco poco)
        {
            try
            {
                SubcategoriaPoco delPoco = this.servico.Excluir(poco.Codigo);
                return Ok(delPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
