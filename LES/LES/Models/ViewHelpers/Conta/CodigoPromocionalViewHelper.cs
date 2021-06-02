using LES.Models.Entity;
using LES.Models.ViewModel.Conta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.ViewHelpers.Conta
{
    public class CodigoPromocionalViewHelper : AbstractViewHelper, IViewHelper
    {
        protected override void ToEntidade()
        {
        }

        protected override void ToViewModel()
        {
            CodigoPromocional cupom = (CodigoPromocional)Entidades[typeof(CodigoPromocional).Name];

            CodigoPromocionalModel vm = new CodigoPromocionalModel
            {
                Codigo = cupom.Codigo.ToString(),
                Valor = (double)cupom.Valor
            };

            _viewModel = vm;
        }
    }
}
