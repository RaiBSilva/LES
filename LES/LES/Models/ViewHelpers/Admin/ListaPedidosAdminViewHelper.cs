using LES.Models.Entity;
using LES.Models.ViewModel.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.ViewHelpers.Admin
{
    public class ListaPedidosAdminViewHelper : AbstractViewHelper, IViewHelper
    {
protected override void ToEntidade()
        {
        }

        protected override void ToViewModel()
        {
            ListaPedidosAdminModel vm = new ListaPedidosAdminModel 
            {
                PagAtual = (int)Entidades[nameof(ListaPedidosAdminModel.PagAtual)],
                PagMax = (int)Entidades[nameof(ListaPedidosAdminModel.PagMax)]
            };

            IList<Pedido> pedidos = (IList<Pedido>)Entidades[typeof(IList<Pedido>).FullName];

            AdminPedidoViewHelper pedidoVh = new AdminPedidoViewHelper();
            foreach (var pedido in pedidos)
            {
                pedidoVh.Entidades = new Dictionary<string, object>
                {
                    [typeof(Pedido).Name] = pedido
                };
                vm.Pedidos.Add((AdminPedidoModel)pedidoVh.ViewModel);
            }

            _viewModel = vm;
        }
    }
}
