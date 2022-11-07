﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Atacado.Poco.Estoque;
using Atacado.Servico.Estoque;
using Microsoft.IdentityModel.Tokens;

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
                List<CategoriaPoco> list = this.servico.Browse();
                return Ok(list);
            }
            catch(Exception ex)
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
                CategoriaPoco poco = this.servico.Read(codigo);
                return Ok(poco);
            }
            catch(Exception ex)
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
                CategoriaPoco nova = this.servico.Add(poco);
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
        public CategoriaPoco Atualizar([FromBody] CategoriaPoco poco)
        {
            return this.servico.Edit(poco);
        }

        /// <summary>
        /// Apaga um registro por codigo informado
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        [HttpDelete("{codigo:int}")]
        public ActionResult<CategoriaPoco> DeletePorId(int codigo)
        {
            CategoriaPoco delPoco = this.servico.Delete(codigo);
            return Ok(delPoco);
        }

        /// <summary>
        /// Apaga um registro de acordo com os dados informados 
        /// </summary>
        /// <param name="poco"></param>
        /// <returns></returns>
        [HttpDelete]
        public CategoriaPoco DeletePorInstancia([FromBody] CategoriaPoco poco)
        {
            return this.servico.Delete(poco);
        }
    }
}
