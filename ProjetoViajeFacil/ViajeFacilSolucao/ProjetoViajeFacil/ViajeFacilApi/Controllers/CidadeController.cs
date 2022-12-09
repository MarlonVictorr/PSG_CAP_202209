using LinqKit;
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
    public class CidadeController : ControllerBase
    {
        private CidadeService servico;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contexto"></param>
        public CidadeController(ViajeFacilContexto contexto) : base()
        {
            this.servico = new CidadeService(contexto);
        }

        /// <summary>
        /// Lista todos os registros da tabela.
        /// </summary>
        /// <param name="siglauf"></param>
        /// <param name="take"></param>
        /// <param name="skip"></param>
        /// <returns></returns>
        [HttpGet("{siglauf}")]
        public ActionResult<List<CidadePoco>> GetAll(string siglauf, int? take = null, int? skip = null)
        {
            try
            {
                List<CidadePoco> listPoco;
                var predicado = PredicateBuilder.New<Cidade>(true);
                if (take == null) //Opcional
                {
                    if (skip != null)
                    {
                        return BadRequest("Informe os parâmetro take e skip.");
                    }
                    else
                    {
                        predicado = predicado.And(s => s.SiglaUf == siglauf);
                        listPoco = this.servico.Consultar(predicado);
                        return Ok(listPoco);
                    }
                }
                else
                {
                    if (skip == null) //Opcional
                    {
                        return BadRequest("Informe os parâmetro take e skip.");
                    }
                    else
                    {
                        predicado = predicado.And(s => s.SiglaUf == siglauf);
                        listPoco = this.servico.Vasculhar(take, skip, predicado);
                        return Ok(listPoco);
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Lista a cidade de acordo com o código informado
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        [HttpGet("{codigo:long}")]
        public ActionResult<CidadePoco> GetPorId(long codigo)
        {
            try
            {
                CidadePoco poco = this.servico.PesquisarPelaChave(codigo);
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
        public ActionResult<CidadePoco> Post([FromBody] CidadePoco poco)
        {
            try
            {
                CidadePoco nova = this.servico.Inserir(poco);
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
        public ActionResult<CidadePoco> Put([FromBody] CidadePoco poco)
        {
            try
            {
                CidadePoco atPoco = this.servico.Alterar(poco);
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
        public ActionResult<CidadePoco> DeletePorId(long codigo)
        {
            try
            {
                CidadePoco delPoco = this.servico.Excluir(codigo);
                return Ok(delPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
