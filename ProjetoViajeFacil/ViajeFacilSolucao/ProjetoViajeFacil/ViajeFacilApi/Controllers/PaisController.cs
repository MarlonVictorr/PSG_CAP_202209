﻿using Microsoft.AspNetCore.Http;
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
    public class PaisController : ControllerBase
    {
        private PaisService servico;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contexto"></param>
        public PaisController(ViajeFacilContexto contexto) : base()
        {
            this.servico = new PaisService(contexto);
        }

        /// <summary>
        /// Lista todos os registros da tabela.
        /// </summary>
        /// <param name="take"></param>
        /// <param name="skip"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<PaisPoco>> GetAll(int? take = null, int? skip = null)
        {
            try
            {
                List<PaisPoco> list = this.servico.Listar(take, skip);
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Lista o país de acordo com o código informado
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        [HttpGet("{codigo:long}")]
        public ActionResult<PaisPoco> GetPorId(long codigo)
        {
            try
            {
                PaisPoco poco = this.servico.PesquisarPelaChave(codigo);
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
        public ActionResult<PaisPoco> Post([FromBody] PaisPoco poco)
        {
            try
            {
                PaisPoco nova = this.servico.Inserir(poco);
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
        public ActionResult<PaisPoco> Put([FromBody] PaisPoco poco)
        {
            try
            {
                PaisPoco atPoco = this.servico.Alterar(poco);
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
        public ActionResult<PaisPoco> DeletePorId(long codigo)
        {
            try
            {
                PaisPoco delPoco = this.servico.Excluir(codigo);
                return Ok(delPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
