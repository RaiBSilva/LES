using LES.Models.Entity;
using LES.Models.ViewModel.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.ViewHelpers.Admin
{
    public class ListaAdminLivroViewHelper : AbstractViewHelper, IViewHelper
    {
        protected override void ToEntidade()
        {
        }

        protected override void ToViewModel()
        {
            ListaAdminLivroModel vm = new ListaAdminLivroModel
            {
                PagAtual = (int)Entidades[nameof(ListaAdminLivroModel.PagAtual)],
                PagMax = (int)Entidades[nameof(ListaAdminLivroModel.PagMax)]
            };

            IList<Livro> livros = (IList<Livro>)Entidades[typeof(IList<Livro>).FullName];

            AdminLivroViewHelper livroVh = new AdminLivroViewHelper();
            foreach (var livro in livros)
            {
                livroVh.Entidades = new Dictionary<string, object>
                {
                    [typeof(Livro).Name] = livro
                };
                vm.Livros.Add((AdminLivroModel)livroVh.ViewModel);
            };

            _viewModel = vm;
        }
    }
}
