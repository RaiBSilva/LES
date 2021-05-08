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
    public class AdminPedidoViewHelper : AbstractViewHelper, IViewHelper
    {
protected override void ToEntidade()
        {
            throw new NotImplementedException();
        }

        protected override void ToViewModel()
        {

            Pedido p = (Pedido)Entidades[typeof(Pedido).Name];
            Cliente cliente = p.Cliente;

            AdminPedidoModel vm = new AdminPedidoModel {
                DtPedido = p.DtCadastro,
                Id = p.Id.ToString(),
                PreçoTotal = p.CalcularValorTotal(),
                Status = p.Status
            };

            AdminLivroViewHelper livroVh = new AdminLivroViewHelper();
            foreach (var livro in p.LivrosPedidos)
            {
                livroVh.Entidades = new Dictionary<string, object>
                {
                    [typeof(Livro).Name] = livro.Livro
                };
                vm.Livros[livro.Id] = (AdminLivroModel)livroVh.ViewModel;
            }

            DetalhesCartaoViewHelper cartaoVh = new DetalhesCartaoViewHelper();
            foreach (var cartao in p.CartaoPedidos)
            {
                cartaoVh.Entidades = new Dictionary<string, object>
                {
                    [typeof(CartaoCredito).Name] = cartao.Cartao
                };
                vm.Cartoes[(CartaoBaseModel)cartaoVh.ViewModel] = cartao.Valor;
            }

            if (p.Cupom != null)
            {
                CupomViewHelper cupomVh = new CupomViewHelper
                {
                    Entidades = new Dictionary<string, object>
                    {
                        [typeof(Cupom).Name] = p.Cupom
                    }
                };
                vm.Cupom = (CupomModel)cupomVh.ViewModel;
            }

            PaginaDetalhesViewHelper clienteVh = new PaginaDetalhesViewHelper 
            {
                Entidades = new Dictionary<string, object>
                {
                    [typeof(Cliente).Name] = cliente
                }
            };

            vm.Cliente = (PaginaDetalhesModel)clienteVh.ViewModel;

            _viewModel = vm;

        }
    }
}
