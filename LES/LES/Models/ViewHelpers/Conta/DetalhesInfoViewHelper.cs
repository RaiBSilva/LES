using LES.Models.Entity;
using LES.Models.ViewModel.Conta;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.ViewHelpers.Conta
{
    public class DetalhesInfoViewHelper : AbstractViewHelper, IViewHelper
    {

        public DetalhesInfoViewHelper():base()
        {
                
        }

        protected override void ToEntidade()
        {
            DetalhesInfoModel vm = (DetalhesInfoModel)ViewModel;

            Cliente c = new Cliente
            {
                Nome = vm.Nome,
                Cpf = vm.Cpf,
                Codigo = vm.Codigo,
                DtNascimento = vm.DtNascimento,
                Genero = vm.Genero,
                Nota = vm.NotaUsuario
            };

            c.Usuario = new Usuario { Email = vm.Email };

            Entidades[typeof(Cliente).Name] = c;
        }

        protected override void ToViewModel()
        {
            Cliente c = (Cliente)Entidades[typeof(Cliente).Name];

            DetalhesInfoModel vm = new DetalhesInfoModel 
            {
                Codigo = c.Codigo,
                Cpf = c.Cpf,
                DtNascimento = c.DtNascimento,
                Email = c.Usuario.Email,
                Genero = c.Genero,
                Nome = c.Nome,
                NotaUsuario = c.Nota
            };

            _viewModel = vm;
        }
    }
}
