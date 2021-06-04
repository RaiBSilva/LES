using LES.Models.Entity;
using LES.Models.ViewHelpers.Conta;
using LES.Models.ViewModel.Admin;
using LES.Models.ViewModel.Conta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.ViewHelpers.Admin
{
    public class AdminClienteViewHelper : AbstractViewHelper, IViewHelper
    {
        protected override void ToEntidade()
        {
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

            AdminClienteModel vm = new AdminClienteModel
            {
                InfoUsuario = (DetalhesInfoModel)infoVH.ViewModel,
                Inativo = cliente.Inativo
            };

            IList<CartaoCredito> cartoes = cliente.Cartoes ?? new List<CartaoCredito>();
            IList<Cupom> cupons = cliente.Cupons ?? new List<Cupom>();
            IList<Endereco> enderecos = cliente.Enderecos ?? new List<Endereco>();
            IList<Pedido> pedidos = cliente.Pedidos ?? new List<Pedido>();
            IList<Telefone> telefones = cliente.Telefones ?? new List<Telefone>();
            IList<Troca> trocas = cliente.Trocas ?? new List<Troca>();

            foreach (var cartao in cartoes)
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

            foreach (var pedido in pedidos)
            {
                pedidoVh.Entidades = new Dictionary<string, object>
                {
                    [typeof(Pedido).Name] = pedido
                };

                vm.Pedidos.Add((PedidoModel)pedidoVh.ViewModel);
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
