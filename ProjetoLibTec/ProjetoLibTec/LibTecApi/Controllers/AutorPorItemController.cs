using LibTec.Domain.EF;
using LibTec.Poco;
using LibTec.Service.Livraria;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibTecApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/libtec/[controller]")]
    [ApiController]
    public class AutorPorItemController : ControllerBase
    {
        private AutorItemServico servico;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public AutorPorItemController(LibTecContext context) : base()
        {
            this.servico = new AutorItemServico(context);
        }

        /// <summary>
        /// Lista todos os registros da tabela.
        /// </summary>
        /// <param name="take"></param>
        /// <param name="skip"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<AutorItemPoco>> GetAll(int? take = null, int? skip = null)
        {
            try
            {
                List<AutorItemPoco> list = this.servico.Listar(take, skip);
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Lista o item de acordo com o código informado
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        [HttpGet("{codigo:int}")]
        public ActionResult<AutorItemPoco> GetPorId(int codigo)
        {
            try
            {
                AutorItemPoco poco = this.servico.PesquisarPelaChave(codigo);
                return Ok(poco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Lista o item de acordo com o código informado do autor
        /// </summary>
        /// <param name="autcodigo"></param>
        /// <returns></returns>
        [HttpGet("PorAutor/{autcodigo:int}")]
        public ActionResult<List<AutorItemPoco>> GetPorAutor(int autcodigo)
        {
            try
            {
                List<AutorItemPoco> listaPoco = this.servico.Consultar(aut => aut.CodigoAutor == autcodigo).ToList();
                return Ok(listaPoco);
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
        public ActionResult<AutorItemPoco> Post([FromBody] AutorItemPoco poco)
        {
            try
            {
                AutorItemPoco nova = this.servico.Inserir(poco);
                return Ok(nova);
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
        public ActionResult<AutorItemPoco> Put([FromBody] AutorItemPoco poco)
        {
            try
            {
                AutorItemPoco atPoco = this.servico.Alterar(poco);
                return Ok(atPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Apaga um registro por código informado
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        [HttpDelete("{codigo:int}")]
        public ActionResult<AutorItemPoco> DeletePorId(int codigo)
        {
            try
            {
                AutorItemPoco delPoco = this.servico.Excluir(codigo);
                return Ok(delPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
