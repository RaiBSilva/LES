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
    public class AlterarSenhaModelViewHelper : AbstractViewHelper, IViewHelper
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
            AlterarSenhaModel vm = (AlterarSenhaModel)ViewModel;
            Cliente cliente = new Cliente();

            Usuario user = new Usuario();

            user.Senha = vm.Senha;

            cliente.Usuario = user;

            Entidades[typeof(Cliente).Name] = cliente;
        }

        protected override void ToViewModel()
        {
            Cliente cliente = (Cliente)Entidades[typeof(Cliente).Name];

            AlterarSenhaModel vm = new AlterarSenhaModel();

            vm.VelhaSenha = cliente.Usuario.Senha;
            vm.Codigo = cliente.Codigo;
            vm.VelhaSenha = cliente.Usuario.Senha;

            ViewModel = vm;
        }
    }
}
