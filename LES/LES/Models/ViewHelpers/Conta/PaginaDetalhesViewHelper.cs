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
            PedidoViewHelper pedidoVh = new PedidoViewHelper();

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
                Entidades = new Dictionary<string, object>
                {
                    [typeof(Cliente).Name] = cliente
                }
            };

            DetalhesCartaoViewHelper cartaoVH = new DetalhesCartaoViewHelper();
            CupomViewHelper cupomVH = new CupomViewHelper();
            DetalhesEnderecoViewHelper enderecoVH = new DetalhesEnderecoViewHelper();
            PedidoViewHelper pedidoVh = new PedidoViewHelper();
            DetalhesTelefoneViewHelper telefoneVH = new DetalhesTelefoneViewHelper();
            TrocaViewHelper trocaVh = new TrocaViewHelper();

            PaginaDetalhesModel vm = new PaginaDetalhesModel 
            {
                InfoUsuario = (DetalhesInfoModel) infoVH.ViewModel
            };

            IList<CartaoCredito> cartoes = cliente.Cartoes != null ? cliente.Cartoes : new List<CartaoCredito>();
            IList<Cupom> cupons  = cliente.Cupons != null ? cliente.Cupons : new List<Cupom>();
            IList<Endereco> enderecos = cliente.Enderecos != null ? cliente.Enderecos : new List<Endereco>();
            IList<Pedido> pedidos = cliente.Pedidos != null ? cliente.Pedidos : new List<Pedido>();
            IList<Telefone> telefones = cliente.Telefones != null ? cliente.Telefones : new List<Telefone>();
            IList<Troca> trocas = cliente.Trocas != null ? cliente.Trocas : new List<Troca>();

            foreach(var cartao in cartoes)
            {
                cartaoVH.Entidades = new Dictionary<string, object>
                {
                    [typeof(CartaoCredito).Name] = cartao 
                };

                vm.Cartoes.Add((DetalhesCartaoModel)cartaoVH.ViewModel);
            }

            foreach (var cupom in cupons)
            {
                cupomVH.Entidades = new Dictionary<string, object>
                {
                    [typeof(Cupom).Name] = cupom
                };

                vm.Cupons.Add((CupomModel)cupomVH.ViewModel);
            }

            foreach (var endereco in enderecos)
            {
                enderecoVH.Entidades = new Dictionary<string, object>
                {
                    [typeof(Endereco).Name] = endereco
                };

                vm.Enderecos.Add((DetalhesEnderecoModel)enderecoVH.ViewModel);
            }

            foreach(var pedido in pedidos)
            {
                pedidoVh.Entidades = new Dictionary<string, object>
                {
                    [typeof(Pedido).Name] = pedido
                };

                vm.Pedidos.Add((PedidoModel)cupomVH.ViewModel);
            }

            foreach (var telefone in telefones)
            {
                telefoneVH.Entidades = new Dictionary<string, object>
                {
                    [typeof(Telefone).Name] = telefone
                };

                vm.Telefones.Add((DetalhesTelefoneModel)telefoneVH.ViewModel);
            }

            foreach (var troca in trocas)
            {
                trocaVh.Entidades = new Dictionary<string, object>
                {
                    [typeof(Troca).Name] = troca
                };
                vm.Trocas.Add((TrocaModel)trocaVh.ViewModel);
            }

            _viewModel = vm;
        }
    }
}
