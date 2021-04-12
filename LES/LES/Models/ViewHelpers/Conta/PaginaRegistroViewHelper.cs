using LES.Models.Entity;
using LES.Models.ViewModel;
using LES.Models.ViewModel.Conta;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.ViewHelpers.Conta
{
    public class PaginaRegistroViewHelper : AbstractViewHelper, IViewHelper
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
            PaginaRegistroModel vm = (PaginaRegistroModel)ViewModel;
            IList<Endereco> ListaEnderecos = new List<Endereco>();
            IList<Telefone> ListaTelefones = new List<Telefone>();

            Usuario user = new Usuario();
            user.Senha = vm.Senha.Senha;
            user.Email = vm.InfoUsuario.Email;

            ListaEnderecos.Add(ToEndereco(vm.Endereco));
            ListaTelefones.Add(ToTelefone(vm.Telefone));

            Cliente cliente = new Cliente
            {
                Cpf = vm.InfoUsuario.Cpf,
                DtNascimento = vm.InfoUsuario.DtNascimento,
                Genero = vm.InfoUsuario.Genero,
                Nome = vm.InfoUsuario.Nome,
                Enderecos = ListaEnderecos,
                Usuario = user,
                Telefones = ListaTelefones
            };

            Entidades[typeof(Cliente).Name] = cliente;
        }

        protected override void ToViewModel()
        {
            Cliente cliente = (Cliente)Entidades[typeof(Cliente).Name];

            PaginaRegistroModel vm = new PaginaRegistroModel
            {
                InfoUsuario = ToInfoBaseModel(cliente),
                Endereco = ToEnderecoBaseModel(cliente),
                Telefone = ToTelefoneBaseModel(cliente)
            };

            ViewModel = vm;
        }

        public TelefoneBaseModel ToTelefoneBaseModel(Cliente cli)
        {
            TelefoneBaseModel baseModel = new TelefoneBaseModel();
            Telefone tel = new Telefone();

            IList<Telefone> tels = cli.Telefones;
            foreach (Telefone e in tels)
            {
                tel = e;
            }

            baseModel.Ddd = tel.Ddd;
            baseModel.NumeroTelefone = tel.Numero;

            return baseModel;
        }

        public EnderecoBaseModel ToEnderecoBaseModel(Cliente cli)
        {
            EnderecoBaseModel baseModel = new EnderecoBaseModel();
            Endereco endereco = new Endereco();

            IList<Endereco> Enderecos = cli.Enderecos;
            foreach (Endereco e in Enderecos)
            {
                endereco = e;
            }

            baseModel.Cep = endereco.Cep;
            baseModel.Cidade = endereco.Cidade.Nome;
            baseModel.Complemento = endereco.Complemento;
            baseModel.Estado = endereco.Cidade.Estado.Nome;
            baseModel.Logradouro = endereco.Logradouro;
            baseModel.Numero = endereco.Numero;
            baseModel.Pais = endereco.Cidade.Estado.Pais.Nome;
            baseModel.TipoEndereco = endereco.TipoEndereco;
            baseModel.Observacoes = endereco.Observacoes;

            return baseModel;
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

        public Endereco ToEndereco(EnderecoBaseModel input)
        {
            Endereco endereco = new Endereco();

            endereco.Cep = input.Cep;
            endereco.Cidade.Nome = input.Cidade;
            endereco.Complemento = input.Complemento;
            endereco.TipoEndereco = input.TipoEndereco;
            endereco.Cidade.Estado.Nome = input.Estado;
            endereco.Cidade.Estado.Pais.Nome = input.Pais;
            endereco.Numero = input.Numero;
            endereco.Logradouro = input.Logradouro;

            return endereco;
        }

        public Telefone ToTelefone(TelefoneBaseModel input)
        {
            Telefone telefone = new Telefone();

            telefone.Ddd = input.Ddd;
            telefone.Numero = input.NumeroTelefone;
            telefone.Id = Convert.ToInt32(input.Id);
            telefone.TipoTelefoneId = input.TipoTelefone.Id;

            return telefone;
        }
    }
}
