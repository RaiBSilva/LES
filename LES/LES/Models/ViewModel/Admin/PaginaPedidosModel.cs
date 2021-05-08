using LES.Models.ViewModel.Conta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.ViewModel.Admin
{
    public class PaginaPedidosModel : IViewModel
    {
        public FiltrosPedidosAdminModel Filtros = new FiltrosPedidosAdminModel();

        public ListaPedidosAdminModel Pedidos = new ListaPedidosAdminModel();

        public ListaTrocasAdminModel Trocas = new ListaTrocasAdminModel();
    }
}
