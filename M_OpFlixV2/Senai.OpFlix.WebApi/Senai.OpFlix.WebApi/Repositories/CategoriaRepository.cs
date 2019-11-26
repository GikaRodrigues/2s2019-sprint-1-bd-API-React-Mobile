using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {

        /// <summary>
        /// Método para listar as Categorias
        /// </summary>
        /// <returns>Lista de Categorias</returns>
        public List<Categorias> Listar()
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.Categorias.OrderBy(x=>x.IdCategoria).ToList();
            }
        }

        /// <summary>
        /// Método para cadastrar novas Categorias
        /// </summary>
        /// <param name="categoria"></param>
        public void Cadastrar(Categorias categoria)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                ctx.Categorias.Add(categoria);
                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// Método para encontrar uma Categoria pelo seu ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Um Categoria buscada pelo ID </returns>
        public Categorias BuscarPorId(int id)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.Categorias.FirstOrDefault(x => x.IdCategoria == id);
            }
        }

        /// <summary>
        /// Método que altera algum dado de uma categoria
        /// </summary>
        /// <param name="categoria"></param>
        public void Atualizar(Categorias categoria)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                Categorias CategoriaBuscada = ctx.Categorias.FirstOrDefault(x => x.IdCategoria == categoria.IdCategoria);
                CategoriaBuscada.Categoria = categoria.Categoria;
                ctx.Categorias.Update(CategoriaBuscada);
                ctx.SaveChanges();
            }
        }
    }
}
