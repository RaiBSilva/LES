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
    public class AlterarSenhaViewHelper : AbstractViewHelper, IViewHelper
    {

        public AlterarSenhaViewHelper() : base()
        {

        }

protected override void ToEntidade()
        {
            AlterarSenhaModel vm = (AlterarSenhaModel)ViewModel;
            Cliente cliente = new Cliente
            {
                Codigo = vm.Codigo
            };

            Usuario user = new Usuario
            {
                Senha = vm.Senha
            };

            cliente.Usuario = user;

            Entidades[typeof(Cliente).Name] = cliente;
            Entidades[$"{typeof(Cliente).Name}Antigo"] = new Cliente
            {
                Usuario = new Usuario
                {
                    Senha = vm.VelhaSenha
                }
            };
        }

        protected override void ToViewModel()
        {
            Cliente cliente = (Cliente)Entidades[typeof(Cliente).Name];

            AlterarSenhaModel vm = new AlterarSenhaModel
            {
                VelhaSenha = cliente.Usuario.Senha,
                Codigo = cliente.Codigo
            };
            vm.VelhaSenha = cliente.Usuario.Senha;

            _viewModel = vm;
        }
    }
}
