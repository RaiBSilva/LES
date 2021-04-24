using LES.Models.Entity;
using LES.Models.ViewModel.Conta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.ViewModel.Carrinho
{
    public class PaginaFinalizarCompraModel
    {
        public IList<DetalhesEnderecoModel> Enderecos { get; set; }
        public IDictionary<DetalhesCartaoModel, double> Cartoes { get; set; } = new Dictionary<DetalhesCartaoModel, double>();
        public IList<CupomModel> Cupons { get; set; }
        public CarrinhoModel Pedido {get;set;}

    }
}
