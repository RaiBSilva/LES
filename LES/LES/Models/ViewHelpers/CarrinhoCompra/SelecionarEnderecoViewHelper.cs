using LES.Models.Entity;
using LES.Models.ViewHelpers.Conta;
using LES.Models.ViewModel.Carrinho;
using LES.Models.ViewModel.Conta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.ViewHelpers.CarrinhoCompra
{
    public class SelecionarEnderecoViewHelper : AbstractViewHelper, IViewHelper
    {
        protected override void ToEntidade()
        {
            SelecionarEnderecoModel vm = (SelecionarEnderecoModel)ViewModel;

            _entidades = new Dictionary<string, object> 
            {
                [typeof(Endereco).Name] = new Endereco
                {
                    Id = vm.EnderecoId
                }
            };
        }

        protected override void ToViewModel()
        {
            SelecionarEnderecoModel vm = new SelecionarEnderecoModel();
            IList<Endereco> enderecos = (IList<Endereco>)Entidades[typeof(IList<Endereco>).Name];

            DetalhesEnderecoViewHelper enderecosVh = new DetalhesEnderecoViewHelper();

            foreach(var item in enderecos)
            {
                enderecosVh.Entidades = new Dictionary<string, object>
                {
                    [typeof(Endereco).Name] = item
                };
                vm.Enderecos.Add((DetalhesEnderecoModel)enderecosVh.ViewModel);
            }

            _viewModel = vm;
        }
    }
}
