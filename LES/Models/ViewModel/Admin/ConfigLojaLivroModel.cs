using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.ViewModel.Admin
{
    public class ConfigLojaLivroModel
    {
        public IList<CategoriaLivroModel> Categorias { get; set; }
        public IList<AdminGrupoPrecoModel> GrupoPrecos { get; set; }
        public AdminLivroModel Livro { get; set; }

        public ConfigLojaLivroModel()
        {
            Categorias = new List<CategoriaLivroModel>();
            GrupoPrecos = new List<AdminGrupoPrecoModel>();
        }

    }
}
