using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private IUsuarioRepository UsuarioRepository { get; set; }

        public UsuariosController()
        {
            UsuarioRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Método para Admins cadastrar outros usuários da plataforma
        /// </summary>
        /// <param name="usuario">Informações do Usuario</param>
        /// <returns>Usuario Cadastrado</returns>
        [Authorize(Roles = "Administrador")]
        [HttpPost("CadastroAdmin")]
        public IActionResult CadastrarAdmin(Usuarios usuario)
        {
            try
            {
                UsuarioRepository.Cadastrar(usuario);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Ih, deu erro." + ex.Message });
            }
        }

        /// <summary>
        /// Método de cadastro público
        /// </summary>
        /// <param name="usuario">Informações do Usuario</param>
        /// <returns>Usuario Cadastrado com a permissão "Cliente"</returns>
        [HttpPost]
        public IActionResult Cadastrar(Usuarios usuario)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            try
            {
                string permissao = identity.FindFirst(ClaimTypes.Role).Value;
                if (permissao.Equals("Administrador")) usuario.Permissao = "Administrador";

            }
            catch (Exception)
            {
                usuario.Permissao = "Comum";
            }

            try
            {
                UsuarioRepository.Cadastrar(usuario);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Ocorreu um erro " + ex });
            }
        }
    }
}