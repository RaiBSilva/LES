using LES.Models.Entity;
using LES.Models.ViewModel.Conta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.ViewModel.Carrinho
{
    public class PaginaFinalizarCompraModel : IViewModel
    {
        public DetalhesEnderecoModel Endereco { get; set; }
        public IDictionary<DetalhesCartaoModel, double> Cartoes { get; set; } = new Dictionary<DetalhesCartaoModel, double>();
        public CupomModel Cupom { get; set; }
        public CodigoPromocionalModel CodigoPromo { get; set; }
        public CarrinhoModel Pedido {get;set;}
        public double Frete { get; set; }

    }
}
