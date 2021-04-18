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
    public class DetalhesCartaoViewHelper : AbstractViewHelper, IViewHelper
    {

        public DetalhesCartaoViewHelper() : base()
        {

        }

        protected override void ToEntidade()
        {
            DetalhesCartaoModel vm = (DetalhesCartaoModel)ViewModel;

            CartaoCredito card = new CartaoCredito();

            card.Bandeira = new BandeiraCartaoCredito { Id = Convert.ToInt32(vm.Bandeira) };
            card.Codigo = vm.Codigo;
            card.Cvv = vm.Cvv;
            card.EFavorito = vm.EPreferencial;
            card.Id = Convert.ToInt32(vm.Id);
            card.NomeImpresso = vm.Nome;
            card.Vencimento = vm.Vencimento;

            Entidades[typeof(CartaoCredito).Name] = card;
        }

        protected override void ToViewModel()
        {
            CartaoCredito card = (CartaoCredito)Entidades[typeof(CartaoCredito).Name];

            DetalhesCartaoModel vm = new DetalhesCartaoModel();

            vm.Bandeira = card.Bandeira.Id.ToString();
            vm.Codigo = card.Codigo;
            vm.Cvv = card.Cvv;
            vm.EPreferencial = card.EFavorito;
            vm.Nome = card.NomeImpresso;
            vm.Vencimento = card.Vencimento;
            vm.Id = card.Id.ToString();

            _viewModel = vm;
        }
    }
}
