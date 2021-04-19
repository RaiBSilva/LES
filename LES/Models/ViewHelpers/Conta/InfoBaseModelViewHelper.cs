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
    public class InfoBaseModelViewHelper : AbstractViewHelper, IViewHelper
    {

        protected override void ToEntidade()
        {
            InfoBaseModel vm = (InfoBaseModel)ViewModel;
            Cliente cliente = new Cliente
            {
                Cpf = vm.Cpf,
                Codigo = vm.Codigo,
                DtNascimento = vm.DtNascimento,
                Genero = vm.Genero,
                Nome = vm.Nome
            };
            cliente.Usuario.Email = vm.Email;

            Entidades[typeof(Cliente).Name] = cliente;
        }

        protected override void ToViewModel()
        {
            Cliente cliente = (Cliente)Entidades[typeof(Cliente).Name];

            InfoBaseModel vm =  new InfoBaseModel 
            {
                Nome = cliente.Nome,
                Email = cliente.Usuario.Email,
                Cpf = cliente.Cpf,
                DtNascimento = cliente.DtNascimento,
                Genero = cliente.Genero,
                Codigo = cliente.Codigo
            };
            vm.Email = cliente.Usuario.Email;

            _viewModel = vm;
        }

    }
}
