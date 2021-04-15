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
            InfoBaseModel vm = (InfoBaseModel)ViewModel;
            Cliente cliente = new Cliente();

            cliente.Cpf = vm.Cpf;
            cliente.Codigo = vm.Codigo;
            cliente.DtNascimento = vm.DtNascimento;
            cliente.Genero = vm.Genero;
            cliente.Nome = vm.Nome;
            cliente.Usuario.Senha = vm.Senha;

            Entidades[typeof(Cliente).Name] = cliente;
        }

        protected override void ToViewModel()
        {
            Cliente cliente = (Cliente)Entidades[typeof(Cliente).Name];

            PaginaRegistroModel vm = new PaginaRegistroModel
            {
                InfoUsuario = ToInfoBaseModel(cliente)
            };

            ViewModel = vm;
        }

        public InfoBaseModel ToInfoBaseModel(Cliente input)
        {
            InfoBaseModel baseModel = new InfoBaseModel();

            baseModel.Nome = input.Nome;
            baseModel.Email = input.Usuario.Email;
            baseModel.Senha = input.Usuario.Senha;
            baseModel.Cpf = input.Cpf;
            baseModel.DtNascimento = input.DtNascimento;
            baseModel.Genero = input.Genero;
            baseModel.Codigo = input.Codigo;

            return baseModel;
        }
    }
}
