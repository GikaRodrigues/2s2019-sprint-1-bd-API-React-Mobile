using Microsoft.EntityFrameworkCore;
using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Repositories
{
    public class LancamentoRepository : ILancamentoRepository
    {
        /// <summary>
        /// Método para listar os Lançamentos
        /// </summary>
        /// <returns>Lista de Lançamentos</returns>
        public List<Lancamentos> Listar()
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.Lancamentos.Include(x => x.IdCategoriaNavigation).ToList();
            }
        }

        /// <summary>
        /// Método para cadastrar novos lancamentos
        /// </summary>
        /// <param name="lancamento"></param>
        public void Cadastrar(Lancamentos lancamento)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                ctx.Lancamentos.Add(lancamento);
                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// Método que altera algum dado de um lancamento
        /// </summary>
        /// <param name="lancamento"></param>
        public void Atualizar(Lancamentos lancamento)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                Lancamentos lancamentoBuscado = ctx.Lancamentos.FirstOrDefault(x => x.IdLancamento == lancamento.IdLancamento);
                lancamentoBuscado.Titulo = lancamento.Titulo;
                lancamentoBuscado.Tipo = lancamento.Tipo;
                lancamentoBuscado.Sinopse = lancamento.Sinopse;
                lancamentoBuscado.Duracao = lancamento.Duracao;
                lancamentoBuscado.DataLancamento = lancamento.DataLancamento;
                lancamentoBuscado.IdCategoria = lancamento.IdCategoria;
                ctx.Lancamentos.Update(lancamentoBuscado);
                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// Método que deleta um lancamento específico
        /// </summary>
        /// <param name="id"></param>
        public void Deletar(int id)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                Lancamentos lancamentoBuscado = ctx.Lancamentos.Find(id);
                ctx.Lancamentos.Remove(lancamentoBuscado);
                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// Método para encontrar um Lancamento pelo seu ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Um Lancamento buscado pelo ID </returns>
        public Lancamentos BuscarPorId(int id)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.Lancamentos.FirstOrDefault(x => x.IdLancamento == id);
            }
        }

        public List<Lancamentos> BuscarPorCategoria(int categoria)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.Lancamentos.Where(x => x.IdCategoria == categoria).Include(x => x.IdCategoriaNavigation).Include(x => x.Tipo).ToList();
            }
        }
    }
}