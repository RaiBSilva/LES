using LES.Models.Entity;
using LES.Models.ViewModel;
using LES.Models.ViewModel.Conta;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.ViewHelpers.Conta
{
    public class PaginaLoginViewHelper : AbstractViewHelper, IViewHelper
    {
        public PaginaLoginViewHelper()
        {
            Entidades = new Dictionary<string, EntidadeDominio>();
        }

        //Método é chamado quando um valor é settado no viewmodel
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

        //Método é chamado quando um valor é settado no dicionário de Entidades
        protected override void ToViewModel()
        {
            if (Entidades.Count > 0) { 
                Usuario usuario = (Usuario)Entidades[typeof(Usuario).Name];

                PaginaLoginModel vm = new PaginaLoginModel
                {
                    Username = usuario.Email
                };

                _viewModel = vm;
            }
        }
    }
}
