using LES.Models.ViewModel.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.ViewModel.Livros
{
    public class PaginaLojaModel : IViewModel
    {
        public LojaFiltrosModel Filtros { get; set; }
        public ListaCardLivrosModel Livros { get; set; }
    }
}
