using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.ViewModel.Admin
{
    public class ListaPedidosAdminModel : IViewModel
    {
        public IList<AdminPedidoModel> Pedidos { get; set; } = new List<AdminPedidoModel>();

        public int PagAtual { get; set; } = 1;

        public int PagMax { get; set; } = 1;

    }
}
