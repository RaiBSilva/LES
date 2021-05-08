using LES.Models.Entity;
using LES.Models.ViewHelpers.Conta;
using LES.Models.ViewModel.Carrinho;
using LES.Models.ViewModel.Conta;
using LES.Negócio.Strategy.ClienteStrategy;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.ViewHelpers.CarrinhoCompra
{
    public class UsarCupomViewHelper : AbstractViewHelper, IViewHelper
    {
        protected override void ToEntidade()
        {
            throw new NotImplementedException();
        }

        protected override void ToViewModel()
        {
            UsarCupomModel vm = new UsarCupomModel();

            IList<Cupom> cupons = (IList<Cupom>)Entidades[typeof(IList<Cupom>).Name];

            CupomViewHelper cupomVh = new CupomViewHelper();
            foreach(var cupom in cupons)
            {
                cupomVh.Entidades = new Dictionary<string, object>
                {
                    [typeof(Cupom).Name] = cupom
                };
                vm.Cupons.Add((CupomModel)cupomVh.ViewModel);    
            }

            _viewModel = vm;
        }
    }
}
