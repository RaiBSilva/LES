using LES.Models.Entity;
using LES.Models.ViewModel.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.ViewHelpers.Admin
{
    public class ListaCategoriaLivroViewHelper : AbstractViewHelper, IViewHelper
    {
        protected override void ToEntidade()
        {
        }

        protected override void ToViewModel()
        {
            ListaCategoriaLivroModel vm = new ListaCategoriaLivroModel
            {
                PagAtual = (int)Entidades[nameof(ListaCategoriaLivroModel.PagAtual)],
                PagMax = (int)Entidades[nameof(ListaCategoriaLivroModel.PagMax)]
            };

            IList<CategoriaLivro> categorias = (IList<CategoriaLivro>)Entidades[typeof(IList<CategoriaLivro>).FullName];

            CategoriaLivroViewHelper catVh = new CategoriaLivroViewHelper();
            foreach (var ctg in categorias)
            {
                catVh.Entidades = new Dictionary<string, object>
                {
                    [typeof(CategoriaLivro).Name] = ctg
                };
                vm.Categorias.Add((CategoriaLivroModel)catVh.ViewModel);
            };

            _viewModel = vm;
        }
    }
}
