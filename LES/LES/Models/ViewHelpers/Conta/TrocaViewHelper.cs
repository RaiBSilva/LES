using LES.Models.Entity;
using LES.Models.ViewHelpers.Admin;
using LES.Models.ViewHelpers.Shared;
using LES.Models.ViewModel.Admin;
using LES.Models.ViewModel.Conta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.ViewHelpers.Conta
{
    public class TrocaViewHelper : AbstractViewHelper, IViewHelper
    {
        protected override void ToEntidade()
        {
            throw new NotImplementedException();
        }

        protected override void ToViewModel()
        {
            Troca t = (Troca)Entidades[typeof(Troca).Name];

            TrocaModel vm = new TrocaModel
            {
                Status = t.StatusTroca,
                LivroPedidoId = t.LivroPedido.Id,
                Id = t.Id,
                DtTroca = t.DtCadastro
            };

            AdminLivroViewHelper livroVh = new AdminLivroViewHelper
            {
                Entidades = new Dictionary<string, object>
                {
                    [typeof(Livro).Name] = t.LivroPedido.Livro
                }
            };

            vm.Livro = (AdminLivroModel)livroVh.ViewModel;

            _viewModel = vm;
        }
    }
}
