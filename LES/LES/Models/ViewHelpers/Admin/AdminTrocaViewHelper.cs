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

            AdminTrocaModel vm = new AdminTrocaModel{
                Status = troca.StatusTroca,
                LivroPedidoId = troca.LivroPedido.Id,
                Id = troca.Id,
                DtTroca = troca.DtCadastro
            };

            AdminLivroViewHelper livroVh = new AdminLivroViewHelper
            {
                Entidades = new Dictionary<string, object>
                {
                    [typeof(Livro).Name] = troca.LivroPedido.Livro
                }
            };

            vm.Livro = (AdminLivroModel)livroVh.ViewModel;

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
