using LES.Models.Entity;
using LES.Models.ViewModel.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.ViewHelpers.Admin
{
    public class GrupoPrecoViewHelper : AbstractViewHelper, IViewHelper
    {
        protected override void ToEntidade()
        {
            GrupoPrecoModel vm = (GrupoPrecoModel)ViewModel;

            GrupoPreco g = new GrupoPreco
            {
                Id = vm.Id,
                MargemLucro = vm.MargemLucro,
                Nome = vm.Nome
            };

            _entidades = new Dictionary<string, object>
            {
                [typeof(GrupoPreco).Name] = g
            };
        }

        protected override void ToViewModel()
        {
            GrupoPreco grupoPreco = (GrupoPreco)Entidades[typeof(GrupoPreco).Name];

            GrupoPrecoModel vm = new GrupoPrecoModel
            {
                Id = grupoPreco.Id,
                Inativo = grupoPreco.Inativo,
                MargemLucro = grupoPreco.MargemLucro,
                Nome = grupoPreco.Nome
            };

            _viewModel = vm;
        }
    }
}
