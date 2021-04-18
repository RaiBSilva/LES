using LES.Models.Entity;
using LES.Models.ViewModel;
using LES.Models.ViewModel.Conta;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.ViewHelpers.Conta
{
    public class DetalhesTelefoneViewHelper : AbstractViewHelper, IViewHelper
    {

        public DetalhesTelefoneViewHelper() : base()
        {

        }

        protected override void ToEntidade()
        {
            DetalhesTelefoneModel vm = (DetalhesTelefoneModel)ViewModel;
            Telefone telefone = new Telefone
            {
                Ddd = vm.Ddd,
                EFavorito = vm.EPreferencial,
                Numero = vm.NumeroTelefone,
                TipoTelefone = new TipoTelefone { Id = Convert.ToInt32(vm.TipoTelefone) },
                Id = Convert.ToInt32(vm.Id)
            };

            Entidades[typeof(Telefone).Name] = telefone;
        }

        protected override void ToViewModel()
        {
            Telefone telefone = (Telefone)Entidades[typeof(Telefone).Name];

            DetalhesTelefoneModel vm = new DetalhesTelefoneModel
            {
                Id = telefone.Id.ToString(),
                Ddd = telefone.Ddd,
                NumeroTelefone = telefone.Numero,
                TipoTelefone = telefone.TipoTelefone.Nome,
                EPreferencial = telefone.EFavorito
            };

            _viewModel = vm;
        }
    }
}
