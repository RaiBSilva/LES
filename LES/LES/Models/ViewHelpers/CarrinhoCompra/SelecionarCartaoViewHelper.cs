using LES.Models.Entity;
using LES.Models.ViewHelpers.Conta;
using LES.Models.ViewModel.Carrinho;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.ViewHelpers.CarrinhoCompra
{
    public class SelecionarCartaoViewHelper : AbstractViewHelper, IViewHelper
    {
        protected override void ToEntidade()
        {
            SelecionarCartaoModel vm = (SelecionarCartaoModel)ViewModel;

            IList<CartaoPedido> cartoesPedidos = new List<CartaoPedido>();
            foreach(var item in vm.Cartoes)
            {
                if (item.Ativado)
                    cartoesPedidos.Add(new CartaoPedido
                    {
                        CartaoId = Convert.ToInt32(item.Id) ,
                        Valor = item.Valor
                    });
            }

            _entidades[typeof(IList<CartaoPedido>).Name] = cartoesPedidos;
        }

        protected override void ToViewModel()
        {
            SelecionarCartaoModel vm = new SelecionarCartaoModel();

            IList<CartaoPedido> cartoesPedido = (IList<CartaoPedido>)Entidades["CartaoPedio"];
            IList<CartaoCredito> cartoes = (IList<CartaoCredito>)Entidades[typeof(IList<CartaoCredito>).Name];
            IEnumerable<int> ids = cartoesPedido.Select(c => c.CartaoId);

            foreach(var cart in cartoes)
            {
                ItemListaCartoesPedidoModel item = new ItemListaCartoesPedidoModel();
                item.Ativado = ids.Contains(cart.Id);
                item.Bandeira = cart.Bandeira.Nome;
                item.DtVencimento = cart.Vencimento;
                item.Id = cart.Id;
                item.UltimosDigitos = cart.Codigo.Substring(cart.Codigo.Length - 3, 2);
                if (item.Ativado)
                    item.Valor = cartoesPedido.Where(c => c.CartaoId == cart.Id).FirstOrDefault().Valor;
                else
                    item.Valor = 0;
                vm.Cartoes.Add(item);
            }

            _viewModel = vm;
        }
    }
}
