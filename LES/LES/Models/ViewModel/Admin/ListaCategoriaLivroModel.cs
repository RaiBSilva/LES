using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.ViewModel.Admin
{
    public class ListaCategoriaLivroModel : IViewModel
    {
        public IList<CategoriaLivroModel> Categorias { get; set; }
        public int PagAtual { get; set; }
        public int PagMax { get; set; }
        public FiltrosCategoriasModel Filtros { get; set; }

    }
}
