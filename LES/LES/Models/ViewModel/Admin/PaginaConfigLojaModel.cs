using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.ViewModel.Admin
{
    public class PaginaConfigLojaModel
    {
        public IList<AdminLivroModel> Livros { get; set; }
        public IList<CategoriaLivroModel> Categorias { get; set; }
        public IList<AdminGrupoPrecoModel> GrupoPrecos { get; set; }

        public PaginaConfigLojaModel()
        {
            Livros = new List<AdminLivroModel>();
            Categorias = new List<CategoriaLivroModel>();
            GrupoPrecos = new List<AdminGrupoPrecoModel>();
        }

    }
}
