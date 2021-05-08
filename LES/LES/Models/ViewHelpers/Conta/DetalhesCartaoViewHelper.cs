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

            DetalhesCartaoModel vm = new DetalhesCartaoModel
            {
                Codigo = card.Codigo,
                Cvv = card.Cvv,
                EPreferencial = card.EFavorito,
                Nome = card.NomeImpresso,
                Vencimento = card.Vencimento,
                Id = card.Id.ToString()
            };

            if(card.Bandeira != null)
                vm.Bandeira = card.Bandeira.Id.ToString();

            _viewModel = vm;
        }
    }
}
