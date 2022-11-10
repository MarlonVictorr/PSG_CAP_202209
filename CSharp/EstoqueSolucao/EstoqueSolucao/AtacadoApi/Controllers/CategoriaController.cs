using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Atacado.Poco.Estoque;
using Atacado.Servico.Estoque;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics.CodeAnalysis;

namespace AtacadoApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/estoque/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private CategoriaServico servico;

        /// <summary>
        /// 
        /// </summary>
        public CategoriaController() : base()
        {
            this.servico = new CategoriaServico();
        }

        /// <summary>
        /// Listar todos os registros da tabela.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<CategoriaPoco>> GetAll()
        {
            try
            {
                List<CategoriaPoco> list = this.servico.Listar();
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Lista a categoria pelo código
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        [HttpGet("{codigo:int}")]
        public ActionResult<CategoriaPoco> GetPorId(int codigo)
        {
            try
            {
                CategoriaPoco poco = this.servico.PesquisarPelaChave(codigo);
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
        public ActionResult<CategoriaPoco> Criar([FromBody] CategoriaPoco poco)
        {
            try
            {
                CategoriaPoco nova = this.servico.Inserir(poco);
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
        public ActionResult<CategoriaPoco> Atualizar([FromBody] CategoriaPoco poco)
        {
            try
            {
                CategoriaPoco atPoco = this.servico.Alterar(poco);
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
        public ActionResult<CategoriaPoco> DeletePorId(int codigo)
        {
            try
            {
                CategoriaPoco delPoco = this.servico.Excluir(codigo);
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
        public ActionResult<CategoriaPoco> DeletePorInstancia([FromBody] CategoriaPoco poco)
        {
            try
            {
                CategoriaPoco delPoco = this.servico.Excluir(poco.Codigo);
                return Ok(delPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
           
    }
}
