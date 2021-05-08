using LES.Models.Entity;
using LES.Models.ViewModel.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.ViewHelpers.Admin
{
    public class ListaTrocasAdminViewHelper : AbstractViewHelper, IViewHelper
    {
protected override void ToEntidade()
        {
        }

        protected override void ToViewModel()
        {
            ListaTrocasAdminModel vm = new ListaTrocasAdminModel
            {
                PagAtual = (int)Entidades[nameof(ListaTrocasAdminModel.PagAtual)],
                PagMax = (int)Entidades[nameof(ListaTrocasAdminModel.PagMax)]
            };

            IList<Troca> trocas = (IList<Troca>)Entidades[typeof(IList<Troca>).FullName];

            AdminTrocaViewHelper trocaVh = new AdminTrocaViewHelper();
            foreach (var troca in trocas)
            {
                trocaVh.Entidades = new Dictionary<string, object>
                {
                    [typeof(Troca).Name] = troca
                };
                vm.Trocas.Add((AdminTrocaModel)trocaVh.ViewModel);
            }

            _viewModel = vm;
        }
    }
}
