using System;
using System.Collections.Generic;

namespace Senai.OpFlix.WebApi.Domains
{
    public partial class Lancamentos
    {
        public Lancamentos()
        {
            PlataformaLancamentos = new HashSet<PlataformaLancamentos>();
        }

        public int IdLancamento { get; set; }
        public string Titulo { get; set; }
        public string Sinopse { get; set; }
        public int Duracao { get; set; }
        public string Tipo { get; set; }
        public DateTime DataLancamento { get; set; }
        public int? IdCategoria { get; set; }

        public Categorias IdCategoriaNavigation { get; set; }
        public ICollection<PlataformaLancamentos> PlataformaLancamentos { get; set; }
    }
}
