using LES.Models.Entity;
using LES.Models.ViewModel.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.ViewHelpers.Admin
{
    public class ListaCodigosPromoViewHelper : AbstractViewHelper, IViewHelper
    {
        protected override void ToEntidade()
        {
        }

        protected override void ToViewModel()
        {
            ListaCodigosPromoModel vm = new ListaCodigosPromoModel
            {
                PagAtual = (int)Entidades[nameof(ListaAdminLivroModel.PagAtual)],
                PagMax = (int)Entidades[nameof(ListaAdminLivroModel.PagMax)],
                Codigos = (IList<CodigoPromocional>)Entidades[typeof(IList<CodigoPromocional>).FullName]
            };

            _viewModel = vm;
        }
    }
}
