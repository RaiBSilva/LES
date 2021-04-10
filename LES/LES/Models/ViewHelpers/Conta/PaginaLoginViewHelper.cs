using LES.Models.Entity;
using LES.Models.ViewModel;
using LES.Models.ViewModel.Conta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.ViewHelpers.Conta
{
    public class PaginaLoginViewHelper : AbstractViewHelper, IViewHelper
    {

        private IDictionary<string, EntidadeDominio> _entidades;
        public override IDictionary<string, EntidadeDominio> Entidades { get; set; }


        private ViewModel.IViewHelper _viewModel;
        public override ViewModel.IViewHelper ViewModel 
        { 
            get=> _viewModel; 
            set 
            {
                _viewModel = value;
                ToEntidade();
            } 
        }

        protected override void ToEntidade()
        {
            PaginaLoginModel vm = (PaginaLoginModel)ViewModel;
            Usuario usuario = new Usuario
            {
                Email = vm.Username,
                Senha = vm.Senha
            };

            Entidades[typeof(Usuario).Name] = usuario;
        }

        protected override void ToViewModel()
        {
            Usuario usuario = (Usuario)Entidades[typeof(Usuario).Name];

            PaginaLoginModel vm = new PaginaLoginModel
            {
                Username = usuario.Email
            };

            ViewModel = vm;
        }
    }
}
