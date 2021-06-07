using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.ViewModel.Admin
{
    public class FiltrosAdminLivroModel : IViewModel
    {
        public int Id { get; set; }
        public string TituloAutor { get; set; }
        public double ValorMin { get; set; }
        public double ValorMax { get; set; }
        public string Categorias { get; set; }
        public bool IncluiInativos { get; set; }
        public int PagAtual { get; set; }

    }
}
