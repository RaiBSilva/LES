using LES.Models.Entity;
using LES.Models.ViewHelpers.Admin;
using LES.Models.ViewHelpers.Shared;
using LES.Models.ViewModel;
using LES.Models.ViewModel.Admin;
using LES.Models.ViewModel.Conta;
using LES.Models.ViewModel.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.ViewHelpers.Conta
{
    public class PedidoViewHelper : AbstractViewHelper, IViewHelper
    {

        public PedidoViewHelper() : base()
        {

        }

        protected override void ToEntidade()
        {
            throw new NotImplementedException();
        }

        protected override void ToViewModel()
        {

            Pedido pedido = (Pedido)Entidades[typeof(Pedido).Name];

            PedidoModel vm = new PedidoModel()
            {
                DtPedido = pedido.DtCadastro,
                Id = pedido.Id.ToString(),
                PreçoTotal = pedido.CalcularValorTotal(),
                Status = pedido.Status
            };

            AdminLivroViewHelper livroVh = new AdminLivroViewHelper();
            foreach(var livro in pedido.LivrosPedidos)
            {
                livroVh.Entidades = new Dictionary<string, object>
                {
                    [typeof(Livro).Name] = livro.Livro
                };
                vm.Livros[livro.Id] = (AdminLivroModel)livroVh.ViewModel;
            }

            DetalhesCartaoViewHelper cartaoVh = new DetalhesCartaoViewHelper();
            foreach(var cartao in pedido.CartaoPedidos)
            {
                cartaoVh.Entidades = new Dictionary<string, object>
                {
                    [typeof(CartaoCredito).Name] = cartao.Cartao
                };
                vm.Cartoes[(CartaoBaseModel)cartaoVh.ViewModel] = cartao.Valor;
            }

            if (pedido.Cupom != null)
            {
                CupomViewHelper cupomVh = new CupomViewHelper
                {
                    Entidades =  new Dictionary<string, object>
                    {
                        [typeof(Cupom).Name] = pedido.Cupom
                    }
                };
                vm.Cupom = (CupomModel)cupomVh.ViewModel;
            }

            _viewModel = vm;
        }
    }
}
