using LES.Models.Entity;
using LES.Models.ViewModel;
using LES.Models.ViewModel.Conta;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.ViewHelpers.Conta
{
    public class PaginaDetalhesViewHelper : AbstractViewHelper, IViewHelper
    {

        public PaginaDetalhesViewHelper() : base()
        {

        }

        protected override void ToEntidade()
        {
            PaginaDetalhesModel vm = (PaginaDetalhesModel)ViewModel;

            DetalhesInfoViewHelper infoVH = new DetalhesInfoViewHelper
            {
                ViewModel = vm.InfoUsuario
            };
            DetalhesCartaoViewHelper cartaoVH = new DetalhesCartaoViewHelper();
            DetalhesEnderecoViewHelper enderecoVH = new DetalhesEnderecoViewHelper();
            DetalhesTelefoneViewHelper telefoneVH = new DetalhesTelefoneViewHelper();
            CupomViewHelper cupomVH = new CupomViewHelper();
            //PedidoViewHelper pedidoVh = new PedidoViewHelper();

            Cliente cliente = (Cliente)infoVH.Entidades[typeof(Cliente).Name];

            foreach(var cartao in vm.Cartoes)
            {
                cartaoVH.ViewModel = cartao;
                cliente.Cartoes.Add((CartaoCredito)cartaoVH.Entidades[typeof(CartaoCredito).Name]);
            }

            foreach (var endereco in vm.Enderecos)
            {
                enderecoVH.ViewModel = endereco;
                cliente.Enderecos.Add((Endereco)enderecoVH.Entidades[typeof(Endereco).Name]);
            }

            foreach (var telefone in vm.Telefones)
            {
                telefoneVH.ViewModel = telefone;
                cliente.Telefones.Add((Telefone)telefoneVH.Entidades[typeof(Telefone).Name]);
            }

            foreach (var cupom in vm.Cupons)
            {
                cupomVH.ViewModel = cupom;
                cliente.Cupons.Add((Cupom)cupomVH.Entidades[typeof(Cupom).Name]);
            }

            Entidades[typeof(Cliente).Name] = cliente;
        }

        protected override void ToViewModel()
        {
            Cliente cliente = (Cliente)Entidades[typeof(Cliente).Name];

            DetalhesInfoViewHelper infoVH = new DetalhesInfoViewHelper
            {
                Entidades = new Dictionary<string, EntidadeDominio>
                {
                    [typeof(Cliente).Name] = cliente
                }
            };
            DetalhesCartaoViewHelper cartaoVH = new DetalhesCartaoViewHelper();
            DetalhesEnderecoViewHelper enderecoVH = new DetalhesEnderecoViewHelper();
            DetalhesTelefoneViewHelper telefoneVH = new DetalhesTelefoneViewHelper();
            CupomViewHelper cupomVH = new CupomViewHelper();
            //PedidoViewHelper pedidoVh = new PedidoViewHelper();

            PaginaDetalhesModel vm = new PaginaDetalhesModel 
            {
                InfoUsuario = (DetalhesInfoModel) infoVH.ViewModel
            };

            foreach(var cartao in cliente.Cartoes)
            {
                cartaoVH.Entidades = new Dictionary<string, EntidadeDominio>
                {
                    [typeof(CartaoCredito).Name] = cartao 
                };

                vm.Cartoes.Add((DetalhesCartaoModel)cartaoVH.ViewModel);
            }

            foreach(var endereco in cliente.Enderecos)
            {
                enderecoVH.Entidades = new Dictionary<string, EntidadeDominio>
                {
                    [typeof(Endereco).Name] = endereco
                };

                vm.Enderecos.Add((DetalhesEnderecoModel)enderecoVH.ViewModel);
            }

            foreach (var telefone in cliente.Telefones)
            {
                telefoneVH.Entidades = new Dictionary<string, EntidadeDominio>
                {
                    [typeof(Telefone).Name] = telefone
                };

                vm.Telefones.Add((DetalhesTelefoneModel)telefoneVH.ViewModel);
            }

            foreach (var cupom in cliente.Cupons)
            {
                cupomVH.Entidades = new Dictionary<string, EntidadeDominio>
                {
                    [typeof(Cupom).Name] = cupom
                };

                vm.Cupons.Add((CupomModel)cupomVH.ViewModel);
            }

            _viewModel = vm;
        }
    }
}
