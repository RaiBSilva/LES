using LES.Models.Entity;
using LES.Models.ViewModel.Admin;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.ViewHelpers.Admin
{
    public class ListaGrupoPrecoViewHelper : AbstractViewHelper, IViewHelper
    {
        protected override void ToEntidade()
        {
        }

        protected override void ToViewModel()
        {
            ListaGrupoPrecoModel vm = new ListaGrupoPrecoModel
            {
                PagAtual = (int)Entidades[nameof(ListaGrupoPrecoModel.PagAtual)],
                PagMax = (int)Entidades[nameof(ListaGrupoPrecoModel.PagMax)]
            };

            IList<GrupoPreco> grupoPrecos = (IList<GrupoPreco>)Entidades[typeof(IList<GrupoPreco>).FullName];

            GrupoPrecoViewHelper grpVh = new GrupoPrecoViewHelper();
            foreach (var gp in grupoPrecos)
            {
                grpVh.Entidades = new Dictionary<string, object>
                {
                    [typeof(GrupoPreco).Name] = gp
                };
                vm.GrupoPrecos.Add((GrupoPrecoModel)grpVh.ViewModel);
            };

            _viewModel = vm;
        }
    }
}
