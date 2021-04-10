using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.ViewModel.Admin
{
    public class ConfigLojaLivroModel
    {
        public IList<AdminCategoriaModel> Categorias { get; set; }
        public IList<AdminGrupoPrecoModel> GrupoPrecos { get; set; }
        public AdminLivroModel Livro { get; set; }

        public ConfigLojaLivroModel()
        {
            Categorias = new List<AdminCategoriaModel>();
            GrupoPrecos = new List<AdminGrupoPrecoModel>();
        }

    }
}
