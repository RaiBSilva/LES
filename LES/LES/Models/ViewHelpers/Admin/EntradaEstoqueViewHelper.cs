using LES.Models.Entity;
using LES.Models.ViewModel.Admin;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.ViewHelpers.Admin
{
    public class EntradaEstoqueViewHelper : AbstractViewHelper, IViewHelper
    {
        protected override void ToEntidade()
        {
        }

        protected override void ToViewModel()
        {
            Livro l = (Livro)Entidades[typeof(Livro).Name];

            EntradaEstoqueModel vm = new EntradaEstoqueModel
            {
                Autor = l.Autor,
                CodigoBarras = l.CodigoBarras,
                Titulo = l.Titulo
            };

            _viewModel = vm;
        }
    }
}
