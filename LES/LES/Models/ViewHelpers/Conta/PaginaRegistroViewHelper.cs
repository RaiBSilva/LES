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
        protected override void ToEntidade()
        {
            PaginaRegistroModel vm = (PaginaRegistroModel)ViewModel;
            IList<Endereco> listaEnderecos = new List<Endereco>();
            IList<Telefone> listaTelefones = new List<Telefone>();
            IList<CartaoCredito> listaCartoes = new List<CartaoCredito>();

            Usuario user = new Usuario();
            user.Senha = vm.Senha.Senha;
            user.Email = vm.InfoUsuario.Email;

            listaEnderecos.Add(ToEndereco(vm.Endereco));
            listaTelefones.Add(ToTelefone(vm.Telefone));
            listaCartoes.Add(ToCartao(vm.Cartao));

            Cliente cliente = new Cliente
            {
                Cpf = vm.InfoUsuario.Cpf,
                DtNascimento = vm.InfoUsuario.DtNascimento,
                Genero = vm.InfoUsuario.Genero,
                Nome = vm.InfoUsuario.Nome,
                Enderecos = listaEnderecos,
                Usuario = user,
                Cartoes = listaCartoes,
                Telefones = listaTelefones
            };

            Entidades[typeof(Cliente).Name] = cliente;
        }

        protected override void ToViewModel()
        {
            if(Entidades.Count > 1) { 
                Cliente cliente = (Cliente)Entidades[typeof(Cliente).Name];

                PaginaRegistroModel vm = new PaginaRegistroModel
                {
                    InfoUsuario = ToInfoBaseModel(cliente),
                    Endereco = ToEnderecoBaseModel(cliente),
                    Telefone = ToTelefoneBaseModel(cliente)
                };

                _viewModel = vm;
            }
        }

        public TelefoneBaseModel ToTelefoneBaseModel(Cliente cli)
        {
            TelefoneBaseModel baseModel = new TelefoneBaseModel();

            Telefone tel = cli.Telefones[0];

            //baseModel.TipoTelefone = tel.TipoTelefone;
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
            //baseModel.TipoEndereco = endereco.TipoEndereco;
            baseModel.Observacoes = endereco.Observacoes;

            return baseModel;
        }

        public InfoBaseModel ToInfoBaseModel(Cliente input)
        {
            InfoBaseModel baseModel = new InfoBaseModel();

            baseModel.Nome = input.Nome;
            baseModel.Email = input.Usuario.Email;
            baseModel.Cpf = input.Cpf;
            baseModel.DtNascimento = input.DtNascimento;
            baseModel.Genero = input.Genero;
            baseModel.Codigo = input.Codigo;

            return baseModel;
        }

        public Endereco ToEndereco(EnderecoBaseModel input)
        {
            Endereco endereco = new Endereco
            {
                Cep = input.Cep,
                ECobranca = true,
                EEntrega = true,
                EFavorito = true,
                NomeEndereco = input.NomeEndereco,
                Complemento = input.Complemento,
                TipoEndereco = new TipoEndereco
                {
                    Id = Convert.ToInt32(input.TipoEndereco)
                },
                Numero = input.Numero,
                Logradouro = input.Logradouro,
                EResidencia = true,
                Observacoes = input.Observacoes,
                Cidade = new Cidade
                {
                    Nome = input.Cidade,
                    Estado = new Estado
                    {
                        Nome = input.Estado,
                        Pais = new Pais
                        {
                            Nome = input.Pais
                        }
                    }
                }
            };

            return endereco;
        }
        public CartaoCredito ToCartao(CartaoBaseModel input)
        {
            CartaoCredito c = new CartaoCredito
            {
                NomeImpresso = input.Nome,
                Bandeira = new BandeiraCartaoCredito {
                    Id = Convert.ToInt32(input.Bandeira)
                },
                Codigo = input.Codigo,
                Cvv = input.Cvv,
                EFavorito = true,
                Vencimento = input.Vencimento
            };

            return c;
        }
        public Telefone ToTelefone(TelefoneBaseModel input)
        {
            Telefone telefone = new Telefone
            {
                Ddd = input.Ddd,
                Numero = input.NumeroTelefone,
                EFavorito = true,
                Id = Convert.ToInt32(input.Id),
                TipoTelefone = new TipoTelefone {
                    Id = Convert.ToInt32(input.TipoTelefone)
                }
            };

            return telefone;
        }
    }
}
