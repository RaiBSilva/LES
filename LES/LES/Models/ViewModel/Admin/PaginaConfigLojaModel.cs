using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.ViewModel.Admin
{
    public class PaginaConfigLojaModel : IViewModel
    {
        public ListaCategoriaLivroModel Categorias { get; set; }
        public ListaGrupoPrecoModel GrupoPrecos { get; set; }
        public ListaAdminLivroModel Livros { get; set; }

    }
}
