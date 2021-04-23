using LES.Models.Entity;
using LES.Models.ViewModel.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.ViewHelpers.Shared
{
    public class ListaCardLivrosViewHelper : AbstractViewHelper, IViewHelper
    {
        protected override void ToEntidade()
        {
            throw new NotImplementedException();
        }

        protected override void ToViewModel()
        {
            ListaCardLivrosModel vm = new ListaCardLivrosModel();

            LivroBaseViewHelper livCarHelper = new LivroBaseViewHelper();

            IList<Livro> livros;

            if (Entidades == null)
            {
                _viewModel = vm;
                return;
            }

            if (Entidades.ContainsKey(typeof(IList<Livro>).Name))
            {
                livros = (IList<Livro>)Entidades[typeof(IList<Livro>).Name];

                foreach (var l in livros)
                {
                    livCarHelper.Entidades = new Dictionary<string, object>
                    {
                        [typeof(Livro).Name] = l
                    };

                    vm.Livros.Add((LivroBaseModel)livCarHelper.ViewModel);
                }
            }

            string pagAtual = nameof(ListaCardLivrosModel.PagAtual),
                pagMax = nameof(ListaCardLivrosModel.PagMax);

            if (Entidades.ContainsKey(pagAtual))
                vm.PagAtual = (int)Entidades[pagAtual];
            else
                vm.PagAtual = 1;

            if (Entidades.ContainsKey(pagMax))
                vm.PagMax = (int)Entidades[pagMax];

            _viewModel = vm;
        }
    }
}
