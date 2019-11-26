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
    [ApiController]
    [Authorize(Roles = "Administrador")]
    public class CategoriasController : ControllerBase
    {
        private ICategoriaRepository CategoriaRepository { get; set; }

        public CategoriasController()
        {
            CategoriaRepository = new CategoriaRepository();
        }

        /// <summary>
        /// Método para listar as Categorias
        /// </summary>
        /// <returns>Lista de Categorias</returns>
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(CategoriaRepository.Listar());
        }

        /// <summary>
        /// Método para cadastrar novas Categorias
        /// </summary>
        /// <param name="categoria"></param>
        /// <returns>Categoria cadastrada</returns>
        [HttpPost]
        public IActionResult Cadastrar(Categorias categoria)
        {
            try
            {
                CategoriaRepository.Cadastrar(categoria);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Ih, deu erro." + ex.Message });
            }
        }

        /// <summary>
        /// Método que altera algum dado de uma categoria
        /// </summary>
        /// <param name="categoria"></param>
        /// <returns>Categoria atualizada</returns>
        [HttpPut("{id}")]
        public IActionResult Atualizar(Categorias categoria, int id)
        {
            try
            {
                Categorias categoriaBuscado = CategoriaRepository.BuscarPorId
                    (id);
                if (categoriaBuscado == null)
                    return NotFound();

                categoria.IdCategoria = id;
                CategoriaRepository.Atualizar(categoria);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}