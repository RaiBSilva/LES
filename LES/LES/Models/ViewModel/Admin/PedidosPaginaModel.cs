using LES.Models.ViewModel.Conta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.ViewModel.Admin
{
    public class PedidosPaginaModel
    {

        public IList<AdminPedidoModel> Pedidos { get; set; }

        public PedidosPaginaModel()
        {
            Pedidos = new List<AdminPedidoModel>();
        }

    }
}
