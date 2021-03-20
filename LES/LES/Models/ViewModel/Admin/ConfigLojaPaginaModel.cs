using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.ViewModel.Admin
{
    public class ConfigLojaPaginaModel
    {
        public IList<AdminLivroModel> Livros { get; set; }
        public IList<AdminCategoriaModel> Categorias { get; set; }
        public IList<AdminGrupoPrecoModel> GrupoPrecos { get; set; }

        public ConfigLojaPaginaModel()
        {
            Livros = new List<AdminLivroModel>();
            Categorias = new List<AdminCategoriaModel>();
            GrupoPrecos = new List<AdminGrupoPrecoModel>();
        }

    }
}
