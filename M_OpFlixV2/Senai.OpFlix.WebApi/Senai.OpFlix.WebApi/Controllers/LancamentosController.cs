using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.Interfaces;
using Senai.OpFlix.WebApi.Repositories;

namespace Senai.OpFlix.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [Authorize]
    [ApiController]
    public class LancamentosController : ControllerBase
    {
        private ILancamentoRepository LancamentoRepository { get; set; }

        public LancamentosController()
        {
            LancamentoRepository = new LancamentoRepository();
        }

        /// <summary>
        /// Lista todos os lançamentos.
        /// </summary>
        /// <returns>lista de lançamentos.</returns>
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(LancamentoRepository.Listar());
        }


        /// <summary>
        /// Cadastra um lançamento.
        /// </summary>
        /// <param name="lancamento">informações do lançamento.</param>
        /// <returns>Lançamento cadastrado</returns>
        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public IActionResult Cadastrar(Lancamentos lancamento)
        {
            try
            {
                LancamentoRepository.Cadastrar(lancamento);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Ih, deu erro." + ex.Message });
            }
        }

        /// <summary>
        /// Atualiza algum dado de um determinado Lançamento
        /// </summary>
        /// <param name="lancamento">Lançamento</param>
        /// <param name="id">Id do Lançamento</param>
        /// <returns>Lançamento atualizado</returns>
        [Authorize(Roles = "Administrador")]
        [HttpPut("{id}")]
        public IActionResult Atualizar(Lancamentos lancamento, int id)
        {
            try
            {
                Lancamentos lancamentoBuscado = LancamentoRepository.BuscarPorId
                    (id);
                if (lancamentoBuscado == null)
                    return NotFound();

                lancamento.IdLancamento = id;
                LancamentoRepository.Atualizar(lancamento);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Método que deleta um determinado Lançamento
        /// </summary>
        /// <param name="id">Id do Lançamento</param>
        /// <returns>Lançamento deletado</returns>
        [Authorize(Roles = "Administrador")]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            LancamentoRepository.Deletar(id);
            return Ok();
        }
    }
}