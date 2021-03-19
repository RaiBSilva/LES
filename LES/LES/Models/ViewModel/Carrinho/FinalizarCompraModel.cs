using LES.Models.Entity;
using LES.Models.ViewModel.Conta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.ViewModel.Carrinho
{
    public class FinalizarCompraModel
    {
        public IList<DetalhesEnderecoModel> Enderecos { get; set; }
        public IList<DetalhesCartaoModel> Cartoes { get; set; }
        public IList<CupomModel> Cupons { get; set; }
        public CarrinhoModel Pedido {get;set;}

        public FinalizarCompraModel()
        {
            Enderecos = new List<DetalhesEnderecoModel>();
            Cartoes = new List<DetalhesCartaoModel>();
            Cupons = new List<CupomModel>();
        }
    }
}
