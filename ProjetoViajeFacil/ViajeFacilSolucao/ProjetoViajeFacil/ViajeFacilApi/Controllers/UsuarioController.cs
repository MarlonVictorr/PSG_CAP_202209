using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViajeFacil.Dominio.EF;
using ViajeFacil.Poco;
using ViajeFacil.Service.Viajar;

namespace ViajeFacilApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/viajefacil/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private UsuarioService servico;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contexto"></param>
        public UsuarioController(ViajeFacilContexto contexto) : base()
        {
            this.servico = new UsuarioService(contexto);
        }

        /// <summary>
        /// Lista todos os registros da tabela.
        /// </summary>
        /// <param name="take"></param>
        /// <param name="skip"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<UsuarioPoco>> GetAll(int? take = null, int? skip = null)
        {
            try
            {
                List<UsuarioPoco> list = this.servico.Listar(take, skip);
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Lista o usúario de acordo com o código informado
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        [HttpGet("{codigo:long}")]
        public ActionResult<UsuarioPoco> GetPorId(long codigo)
        {
            try
            {
                UsuarioPoco poco = this.servico.PesquisarPelaChave(codigo);
                return Ok(poco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Lista o usúario de acordo com o código informado de endereço
        /// </summary>
        /// <param name="endcodigo"></param>
        /// <returns></returns>
        [HttpGet("PorEndereco/{endcodigo:long}")]
        public ActionResult<List<UsuarioPoco>> GetPorEndereco(long endcodigo)
        {
            try
            {
                List<UsuarioPoco> listaPoco = this.servico.Consultar(end => end.CodigoEndereco == endcodigo).ToList();
                return Ok(listaPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Lista o usúario de acordo com o código informado de tipo usúario
        /// </summary>
        /// <param name="tipcodigo"></param>
        /// <returns></returns>
        [HttpGet("PorTipoUsuario/{tipcodigo:long}")]
        public ActionResult<List<UsuarioPoco>> GetPorTipoUsuario(long tipcodigo)
        {
            try
            {
                List<UsuarioPoco> listaPoco = this.servico.Consultar(usu => usu.CodigoTipoUsuario == tipcodigo).ToList();
                return Ok(listaPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Lista o usúario de acordo com o código informado de instituição
        /// </summary>
        /// <param name="inscodigo"></param>
        /// <returns></returns>
        [HttpGet("PorInstituicao/{inscodigo:long}")]
        public ActionResult<List<UsuarioPoco>> GetPorInstituicao(long inscodigo)
        {
            try
            {
                List<UsuarioPoco> listaPoco = this.servico.Consultar(usu => usu.CodigoInstituicao == inscodigo).ToList();
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
        public ActionResult<UsuarioPoco> Post([FromBody] UsuarioPoco poco)
        {
            try
            {
                UsuarioPoco nova = this.servico.Inserir(poco);
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
        public ActionResult<UsuarioPoco> Put([FromBody] UsuarioPoco poco)
        {
            try
            {
                UsuarioPoco atPoco = this.servico.Alterar(poco);
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
        [HttpDelete("{codigo:long}")]
        public ActionResult<UsuarioPoco> DeletePorId(long codigo)
        {
            try
            {
                UsuarioPoco delPoco = this.servico.Excluir(codigo);
                return Ok(delPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
