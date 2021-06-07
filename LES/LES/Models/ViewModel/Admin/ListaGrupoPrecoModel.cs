using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.ViewModel.Admin
{
    public class ListaGrupoPrecoModel : IViewModel
    {
        public IList<GrupoPrecoModel> GrupoPrecos { get; set; }
        public int PagAtual { get; set; } = 1;
        public int PagMax { get; set; } = 1;
        public FiltrosGrupoPrecoModel Filtros { get; set; }
    }
}
