using LES.Models.Entity;
using LES.Models.ViewModel.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.ViewHelpers.Admin
{
    public class PaginaPedidosViewHelper : AbstractViewHelper, IViewHelper
    {
        protected override void ToEntidade()
        {
        }

        protected override void ToViewModel()
        {

            if (Entidades == null)
                _viewModel = new PaginaPedidosModel();

            PaginaPedidosModel vm = new PaginaPedidosModel();

            //ViewHelper Pedidos

            IList<Pedido> pedidos = Entidades.ContainsKey(typeof(IList<Pedido>).FullName) ?
                (IList<Pedido>)Entidades[typeof(IList<Pedido>).FullName] : new List<Pedido>();

            int pedidosPagAtual = Entidades.ContainsKey(nameof(ListaPedidosAdminModel.PagAtual)) ? 
                (int)Entidades[nameof(ListaPedidosAdminModel.PagAtual)] : 1;

            int pedidosPagMax = Entidades.ContainsKey(nameof(ListaPedidosAdminModel.PagMax)) ? 
                (int)Entidades[nameof(ListaPedidosAdminModel.PagMax)] : 1;

            ListaPedidosAdminViewHelper pedidosVh = new ListaPedidosAdminViewHelper
            {
                Entidades = new Dictionary<string, object>
                {
                    [typeof(IList<Pedido>).FullName] = pedidos,
                    [nameof(ListaPedidosAdminModel.PagAtual)] = pedidosPagAtual,
                    [nameof(ListaPedidosAdminModel.PagMax)] = pedidosPagMax
                }
            };

            vm.Pedidos = (ListaPedidosAdminModel)pedidosVh.ViewModel;

            //ViewHelper Trocas

            IList<Troca> trocas = Entidades.ContainsKey(typeof(IList<Troca>).FullName) ?
                (IList<Troca>)Entidades[typeof(IList<Troca>).FullName] : new List<Troca>();

            int trocasPagAtual = Entidades.ContainsKey(nameof(ListaTrocasAdminModel.PagAtual)) ? 
                (int)Entidades[nameof(ListaTrocasAdminModel.PagAtual)] : 1;

            int trocasPagMax = Entidades.ContainsKey(nameof(ListaTrocasAdminModel.PagMax)) ?
                (int)Entidades[nameof(ListaTrocasAdminModel.PagMax)] : 1;

            ListaTrocasAdminViewHelper trocasVh = new ListaTrocasAdminViewHelper
            {
                Entidades = new Dictionary<string, object>
                {
                    [typeof(IList<Troca>).FullName] = trocas,
                    [nameof(ListaTrocasAdminModel.PagAtual)] = trocasPagAtual,
                    [nameof(ListaTrocasAdminModel.PagMax)] = trocasPagMax
                }
            };

            vm.Trocas = (ListaTrocasAdminModel)trocasVh.ViewModel;

            string Id = nameof(FiltrosPedidosAdminModel.Id),
                Nome = nameof(FiltrosPedidosAdminModel.Nome),
                ValorMin = nameof(FiltrosPedidosAdminModel.ValorMin),
                ValorMax = nameof(FiltrosPedidosAdminModel.ValorMax),
                DtMin = nameof(FiltrosPedidosAdminModel.DtMin),
                DtMax = nameof(FiltrosPedidosAdminModel.DtMax),
                Status = nameof(FiltrosPedidosAdminModel.Status);

            vm.Filtros.Id = Entidades.ContainsKey(Id) ? (int)Entidades[Id] : 0;

            vm.Filtros.Nome = Entidades.ContainsKey(Nome) ? (string)Entidades[Nome] : null;

            vm.Filtros.ValorMin = Entidades.ContainsKey(ValorMin) ? (double)Entidades[ValorMin] : 0;

            vm.Filtros.ValorMax = Entidades.ContainsKey(ValorMax) ? (double)Entidades[ValorMax] : 0;

            vm.Filtros.DtMin = Entidades.ContainsKey(DtMin) ? (DateTime)Entidades[DtMin] : new DateTime();

            vm.Filtros.DtMax = Entidades.ContainsKey(DtMax) ? (DateTime)Entidades[DtMax] : new DateTime();

            vm.Filtros.Status = Entidades.ContainsKey(Status) ? (string)Entidades[Status] : null;

            _viewModel = vm;

        }
    }
}
