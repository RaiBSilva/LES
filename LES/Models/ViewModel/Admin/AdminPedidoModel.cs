using LES.Models.ViewModel.Conta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.ViewModel.Admin
{
    public class AdminPedidoModel : PedidoModel
    {

        public PaginaDetalhesModel Cliente { get; set; }

        public AdminPedidoModel()
        {
            Cliente = new PaginaDetalhesModel();
        }

    }
}
