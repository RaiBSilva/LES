using LES.Models.Entity;
using LES.Models.ViewModel.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.ViewHelpers.Admin
{
    public class PaginaConfigLojaViewHelper : AbstractViewHelper, IViewHelper
    {
        protected override void ToEntidade()
        {
        }

        protected override void ToViewModel()
        {
            IList<Livro> livros = (IList<Livro>)Entidades[typeof(IList<Livro>).FullName];
            IList<CategoriaLivro> categorias = (IList<CategoriaLivro>)Entidades[typeof(IList<CategoriaLivro>).FullName];
            IList<GrupoPreco> grupoprecos = (IList<GrupoPreco>)Entidades[typeof(IList<GrupoPreco>).FullName];

            ListaCategoriaLivroViewHelper ctgVh = new ListaCategoriaLivroViewHelper
            {
                Entidades = new Dictionary<string, object>
                {
                    [typeof(IList<CategoriaLivro>).FullName] = categorias,
                    [nameof(ListaCategoriaLivroModel.PagAtual)] = 1,
                    [nameof(ListaCategoriaLivroModel.PagMax)] = 1
                }
            };

            ListaGrupoPrecoViewHelper grpVh = new ListaGrupoPrecoViewHelper
            {
                Entidades = new Dictionary<string, object>
                {
                    [typeof(IList<GrupoPreco>).FullName] = grupoprecos,
                    [nameof(ListaGrupoPrecoModel.PagAtual)] = 1,
                    [nameof(ListaGrupoPrecoModel.PagMax)] = 1
                }
            };

            ListaAdminLivroViewHelper livroVh = new ListaAdminLivroViewHelper
            {
                Entidades = new Dictionary<string, object>
                {
                    [typeof(IList<Livro>).FullName] = livros,
                    [nameof(ListaAdminLivroModel.PagAtual)] = 1,
                    [nameof(ListaAdminLivroModel.PagMax)] = 1
                }
            };

            PaginaConfigLojaModel vm = new PaginaConfigLojaModel
            {
                Categorias = (ListaCategoriaLivroModel)ctgVh.ViewModel,
                GrupoPrecos = (ListaGrupoPrecoModel)grpVh.ViewModel,
                Livros = (ListaAdminLivroModel)livroVh.ViewModel
            };

            _viewModel = vm;
        }
    }
}
