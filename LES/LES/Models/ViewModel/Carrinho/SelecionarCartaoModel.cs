using LES.Models.ViewModel.Conta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.ViewModel.Carrinho
{
    public class SelecionarCartaoModel : DetalhesCartaoModel, IViewModel
    {
        public double ValorTotal { get; set; }
        public IList<ItemListaCartoesPedidoModel> Cartoes { get; set; } = new List<ItemListaCartoesPedidoModel>();

    }
}
