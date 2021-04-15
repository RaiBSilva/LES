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
    public class DetalhesEnderecoModelViewHelper : AbstractViewHelper, IViewHelper
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
            DetalhesEnderecoModel vm = (DetalhesEnderecoModel)ViewModel;

            Cliente cliente = new Cliente();
            Endereco endereco = new Endereco();
            Cidade cidade = new Cidade();
            Estado estado = new Estado();
            Pais pais = new Pais();

            List<Endereco> listaEnderecos = new List<Endereco>();

            pais.Nome = vm.Pais;
            estado.Nome = vm.Estado;
            estado.Pais = pais;
            cidade.Nome = vm.Cidade;
            cidade.Estado = estado;

            endereco.Cep = vm.Cep;
            endereco.Complemento = vm.Complemento;
            endereco.ECobranca = vm.ECobranca;
            endereco.EEntrega = vm.EEntrega;
            endereco.EFavorito = vm.EPreferencial;
            endereco.Cidade = cidade;
            endereco.TipoEndereco = new TipoEndereco { Id = Convert.ToInt32(vm.TipoEndereco) };
            endereco.Id = Convert.ToInt32(vm.Id);
            endereco.Logradouro = vm.Logradouro;
            endereco.Numero = vm.Numero;
            endereco.Observacoes = vm.Observacoes;
            endereco.NomeEndereco = vm.NomeEndereco;

            listaEnderecos.Add(endereco);
            cliente.Enderecos = listaEnderecos;

            Entidades[typeof(Cliente).Name] = cliente;
        }

        protected override void ToViewModel()
        {
            Cliente cliente = (Cliente)Entidades[typeof(Cliente).Name];

            DetalhesEnderecoModel vm = new DetalhesEnderecoModel();

            vm.ECobranca = cliente.Enderecos[0].ECobranca;
            vm.EEntrega = cliente.Enderecos[0].EEntrega;
            vm.EPreferencial = cliente.Enderecos[0].EFavorito;
            vm.Cidade = cliente.Enderecos[0].Cidade.Nome;
            vm.Cep = cliente.Enderecos[0].Cep;
            vm.Complemento = cliente.Enderecos[0].Complemento;
            vm.Estado = cliente.Enderecos[0].Cidade.Estado.Nome;
            vm.Logradouro = cliente.Enderecos[0].Logradouro;
            vm.TipoEndereco = cliente.Enderecos[0].TipoEndereco.Nome;
            vm.Id = cliente.Enderecos[0].Id.ToString();
            vm.Numero = cliente.Enderecos[0].Numero;
            vm.Observacoes = cliente.Enderecos[0].Observacoes;
            vm.Pais = cliente.Enderecos[0].Cidade.Estado.Pais.Nome;

            ViewModel = vm;
        }

        public TelefoneBaseModel ToTelefoneBaseModel(Telefone tel)
        {
            TelefoneBaseModel baseModel = new TelefoneBaseModel();

            baseModel.Ddd = tel.Ddd;
            baseModel.NumeroTelefone = tel.Numero;

            return baseModel;
        }

        public Endereco ToEndereco(EnderecoBaseModel input)
        {
            Endereco endereco = new Endereco();

            endereco.Cep = input.Cep;
            endereco.Cidade.Nome = input.Cidade;
            endereco.Complemento = input.Complemento;
            endereco.TipoEndereco = new TipoEndereco { Id = Convert.ToInt32(input.TipoEndereco) };
            endereco.Cidade.Estado.Nome = input.Estado;
            endereco.Cidade.Estado.Pais.Nome = input.Pais;
            endereco.Numero = input.Numero;
            endereco.Logradouro = input.Logradouro;

            return endereco;
        }

    }
}

