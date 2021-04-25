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
    public class DetalhesEnderecoViewHelper : AbstractViewHelper, IViewHelper
    {
        public DetalhesEnderecoViewHelper() : base()
        {

        }

        protected override void ToEntidade()
        {
            DetalhesEnderecoModel vm = (DetalhesEnderecoModel)ViewModel;
            Pais pais = new Pais
            {
                Nome = vm.Pais
            };
            Estado estado = new Estado
            {
                Nome = vm.Estado,
                Pais = pais
            };
            Cidade cidade = new Cidade
            {
                Nome = vm.Cidade,
                Estado = estado
            };

            Endereco endereco = new Endereco
            {
                Cep = vm.Cep,
                Complemento = vm.Complemento,
                ECobranca = vm.ECobranca,
                EEntrega = vm.EEntrega,
                EFavorito = vm.EPreferencial,
                Cidade = cidade,
                Id = Convert.ToInt32(vm.Id),
                Logradouro = vm.Logradouro,
                Numero = vm.Numero,
                Observacoes = vm.Observacoes,
                NomeEndereco = vm.NomeEndereco
            };
            int n;
            if (int.TryParse(vm.TipoEndereco, out n))
                endereco.TipoEndereco = new TipoEndereco { Id = Convert.ToInt32(vm.TipoEndereco) };
            else
                endereco.TipoEndereco = new TipoEndereco();


            Entidades[typeof(Endereco).Name] = endereco;
        }

        protected override void ToViewModel()
        {
            Endereco endereco = (Endereco)Entidades[typeof(Endereco).Name];

            DetalhesEnderecoModel vm = new DetalhesEnderecoModel();

            vm.ECobranca = endereco.ECobranca;
            vm.EEntrega = endereco.EEntrega;
            vm.EPreferencial = endereco.EFavorito;
            vm.Cidade = endereco.Cidade.Nome;
            vm.Cep = endereco.Cep;
            vm.Complemento = endereco.Complemento;
            vm.Estado = endereco.Cidade.Estado.Nome;
            vm.Logradouro = endereco.Logradouro;
            vm.TipoEndereco = endereco.TipoEndereco.Nome;
            vm.Id = endereco.Id.ToString();
            vm.Numero = endereco.Numero;
            vm.Observacoes = endereco.Observacoes;
            vm.NomeEndereco = endereco.NomeEndereco;
            vm.Pais = endereco.Cidade.Estado.Pais.Nome;

            _viewModel = vm;
        }

    }
}

