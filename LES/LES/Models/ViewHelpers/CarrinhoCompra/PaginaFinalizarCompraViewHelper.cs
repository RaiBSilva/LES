using LES.Models.Entity;
using LES.Models.ViewHelpers.Conta;
using LES.Models.ViewModel;
using LES.Models.ViewModel.Carrinho;
using LES.Models.ViewModel.Conta;
using Microsoft.AspNetCore.Razor.Language;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.ViewHelpers.CarrinhoCompra
{
    public class PaginaFinalizarCompraViewHelper : AbstractViewHelper, IViewHelper
    {
        protected override void ToEntidade()
        {
            throw new NotImplementedException();
        }

        protected override void ToViewModel()
        {
            PaginaFinalizarCompraModel vm = new PaginaFinalizarCompraModel();

            Endereco endereco = (Endereco)Entidades[typeof(Endereco).Name];
            IDictionary<CartaoCredito, double> cartoes = (IDictionary<CartaoCredito, double>)Entidades[typeof(IDictionary<CartaoCredito, double>).Name];
            Cupom cupom = null;
            if(Entidades.ContainsKey(typeof(Cupom).Name))
                cupom = (Cupom)Entidades[typeof(Cupom).Name];
            Carrinho carrinho = (Carrinho)Entidades[typeof(Carrinho).Name];

            DetalhesEnderecoViewHelper enderecoVh = new DetalhesEnderecoViewHelper
            {
                Entidades = new Dictionary<string, object>
                {
                    [typeof(Endereco).Name] = endereco
                }
            };
            vm.Endereco = (DetalhesEnderecoModel)enderecoVh.ViewModel;

            DetalhesCartaoViewHelper cartaoVh = new DetalhesCartaoViewHelper();
            foreach(var entry in cartoes)
            {
                cartaoVh.Entidades = new Dictionary<string, object>
                {
                    [typeof(CartaoCredito).Name] = entry.Key
                };
                vm.Cartoes[(DetalhesCartaoModel)cartaoVh.ViewModel] = entry.Value;
            }

            if(cupom != null)
            {
                CupomViewHelper cupomVh = new CupomViewHelper();
                cupomVh.Entidades = new Dictionary<string, object>
                {
                    [typeof(Cupom).Name] = cupom
                };
                vm.Cupom = (CupomModel)cupomVh.ViewModel;
            }

            CarrinhoViewHelper carrinhoVh = new CarrinhoViewHelper 
            {
                Entidades = new Dictionary<string, object>
                {
                    [typeof(Carrinho).Name] = carrinho
                }
            };
            vm.Pedido = (CarrinhoModel)carrinhoVh.ViewModel;
            _viewModel = vm;
        }
    }
}
