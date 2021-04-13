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
    public class DetalhesTelefoneModelViewHelper : AbstractViewHelper, IViewHelper
    {
        //Atributo responsável por guardar as entidades que vêm do db, ou que vão para o db
        private IDictionary<string, EntidadeDominio> _entidades;
        public override IDictionary<string, EntidadeDominio> Entidades
        {
            get => _entidades;
            set
            {
                _entidades = value;
                ToViewModel();
            }
        }

        //Atributo responsável por guardar as entidades que vêm do request, ou vão para uma página razor
        private IViewModel _viewModel;
        public override IViewModel ViewModel
        {
            get => _viewModel;
            set
            {
                _viewModel = value;
                ToEntidade();
            }
        }

        protected override void ToEntidade()
        {
            DetalhesTelefoneModel vm = (DetalhesTelefoneModel)ViewModel;
            List<Telefone> listaTelefones = new List<Telefone>();
            Telefone telefone = new Telefone();
            Cliente cliente = new Cliente();

            telefone.Ddd = vm.Ddd;
            telefone.EFavorito = vm.EPreferencial;
            telefone.Numero = vm.NumeroTelefone;
            telefone.TipoTelefone = vm.TipoTelefone;
            telefone.Id = Convert.ToInt32(vm.Id);

            listaTelefones.Add(telefone);
            cliente.Telefones = listaTelefones;

            Entidades[typeof(Cliente).Name] = cliente;
        }

        protected override void ToViewModel()
        {
            Cliente cliente = (Cliente)Entidades[typeof(Cliente).Name];

            DetalhesTelefoneModel vm = new DetalhesTelefoneModel();

            vm.Id = cliente.Telefones[0].Id.ToString();
            vm.Ddd = cliente.Telefones[0].Ddd;
            vm.NumeroTelefone = cliente.Telefones[0].Numero;
            vm.TipoTelefone = cliente.Telefones[0].TipoTelefone;
            vm.EPreferencial = cliente.Telefones[0].EFavorito;

            ViewModel = vm;
        }
    }
}
