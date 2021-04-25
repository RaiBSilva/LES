using LES.Models.Entity;
using LES.Models.ViewModel;
using LES.Models.ViewModel.Conta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.ViewHelpers.Conta
{
    public class CupomViewHelper : AbstractViewHelper, IViewHelper
    {

        public CupomViewHelper() : base()
        {

        }

        protected override void ToEntidade()
        {
            CupomModel vm = (CupomModel)ViewModel;

            Entidades[typeof(Cupom).Name] = new Cupom
            {
                Valor = vm.Valor,
                Codigo = Convert.ToInt32(vm.Codigo)
            };
        }

        protected override void ToViewModel()
        {
            Cupom cupom = (Cupom)Entidades[typeof(Cupom).Name];

            CupomModel vm = new CupomModel
            {
                Codigo = cupom.Codigo.ToString(),
                Valor = (double)cupom.Valor
            };

            _viewModel = vm;

        }
    }
}
