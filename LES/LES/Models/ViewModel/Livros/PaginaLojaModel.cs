using LES.Models.ViewModel.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.ViewModel.Livros
{
    public class PaginaLojaModel
    {
        public LojaFiltrosModel Filtros { get; set; }
        public IList<LivroCardModel> Livros { get; set; }
    }
}
