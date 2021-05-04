using LES.Models.Entity;
using LES.Models.ViewHelpers.Conta;
using LES.Models.ViewModel.Admin;
using LES.Models.ViewModel.Conta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.ViewHelpers.Admin
{
    public class AdminTrocaViewHelper : AbstractViewHelper, IViewHelper
    {
        protected override void ToEntidade()
        {
        }

        protected override void ToViewModel()
        {
            Troca troca = (Troca)Entidades[typeof(Troca).Name];

            TrocaViewHelper baseVh = new TrocaViewHelper 
            {
                Entidades = new Dictionary<string, object>
                {
                    [typeof(Troca).Name] = troca
                }
            };

            AdminTrocaModel vm = (AdminTrocaModel)baseVh.ViewModel;
            PaginaDetalhesViewHelper clienteVh = new PaginaDetalhesViewHelper
            {
                Entidades = new Dictionary<string, object>
                {
                    [typeof(Cliente).Name] = troca.Cliente
                }
            };
            vm.Cliente = (PaginaDetalhesModel)clienteVh.ViewModel;

            _viewModel = vm;

        }
    }
}
