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
            CodigoPromocional codigoPromo = null;
            if(Entidades.ContainsKey(typeof(Cupom).Name))
                cupom = (Cupom)Entidades[typeof(Cupom).Name];
            if (Entidades.ContainsKey(typeof(CodigoPromocional).Name))
                codigoPromo = (CodigoPromocional)Entidades[typeof(CodigoPromocional).Name];
            Carrinho carrinho = (Carrinho)Entidades[typeof(Carrinho).Name];

            CarrinhoViewHelper carrinhoVh = new CarrinhoViewHelper
            {
                Entidades = new Dictionary<string, object>
                {
                    [typeof(Carrinho).Name] = carrinho
                }
            };
            vm.Pedido = (CarrinhoModel)carrinhoVh.ViewModel;

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
                CupomViewHelper cupomVh = new CupomViewHelper
                {
                    Entidades = new Dictionary<string, object>
                    {
                        [typeof(Cupom).Name] = cupom
                    }
                };
                vm.Cupom = (CupomModel)cupomVh.ViewModel;
                vm.Pedido.PrecoTotal -= vm.Cupom.Valor;
            }

            if(codigoPromo != null)
            {
                CodigoPromocionalViewHelper codigoVh = new CodigoPromocionalViewHelper
                {
                    Entidades = new Dictionary<string, object>
                    {
                        [typeof(CodigoPromocional).Name] = codigoPromo
                    }
                };
                vm.CodigoPromo = (CodigoPromocionalModel)codigoVh.ViewModel;
                vm.Pedido.PrecoTotal -= vm.CodigoPromo.Valor;
            }

            _viewModel = vm;
        }
    }
}
