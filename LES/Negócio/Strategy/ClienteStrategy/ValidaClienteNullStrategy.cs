using LES.Models.Entity;
using LES.Negocio.Strategy;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LES.Negócio.Strategy.ClienteStrategy
{
    public class ValidaClienteNullStrategy : IStrategy<EntidadeDominio>
    {
        public string Validar(EntidadeDominio e)
        {
            Cliente cliente = (Cliente)e;
            StringBuilder myStringBuilder = new StringBuilder("");

            if ((cliente.Nome is null) || cliente.Nome == "") myStringBuilder.Append("O campo Nome é obrigatório.;");

            if (cliente.Telefones is null) 
                myStringBuilder.Append("É necessario informar um Telefone.;");

            foreach (Telefone tel in cliente.Telefones)
            {
                if(tel.Ddd is null || tel.Ddd == "") 
                    myStringBuilder.Append("É necessario informar o Ddd.;");
                if(tel.Numero is null || tel.Numero == "") 
                    myStringBuilder.Append("É necessario informar o numero do telefone.;");
            }
            if (cliente.Usuario.Email is null || cliente.Usuario.Email == "") 
                myStringBuilder.Append("É necessario informar um E-mail.;");
            if (cliente.Usuario.Senha is null || cliente.Usuario.Senha == "") 
                myStringBuilder.Append("É necessario informar uma Senha.;");
            if (cliente.Cpf is null || cliente.Cpf == "") 
                myStringBuilder.Append("É necessario informar o Cpf.;");
            if (cliente.Enderecos is null)
            {
                myStringBuilder.Append("É necessario informar um endereço.;");
            }
            else
            {
                foreach (Endereco end in cliente.Enderecos)
                {
                    if (end.Cep is null || end.Cep == "") 
                        myStringBuilder.Append("O campo Cep é obrigatório.;");
                    if (end.Cidade.Estado.Nome is null || end.Cidade.Estado.Nome == "") 
                        myStringBuilder.Append("O campo Estado é obrigatório.;");
                    if (end.Cidade.Estado.Pais.Nome is null || end.Cidade.Estado.Pais.Nome == "") 
                        myStringBuilder.Append("O campo Pais é obrigatório.;");
                    if (end.Cidade.Nome is null || end.Cidade.Nome == "") 
                        myStringBuilder.Append("O campo Cidade é obrigatório.;");
                    if (end.Logradouro is null || end.Logradouro == "") 
                        myStringBuilder.Append("O campo Logradouro é obrigatório.;");
                    if (end.Numero is null || end.Numero == "") myStringBuilder.Append("O Numero da residencia deve ser informado.;");
                }
            }
            if (cliente.Cartoes is null)
            {
                myStringBuilder.Append("É necessário um cartão de crédito.;");
            }
            else
            {
                foreach (CartaoCredito card in cliente.Cartoes)
                {
                    if (card.Bandeira is null) 
                        myStringBuilder.Append("É necessário informar a bandeira do cartão.;");
                    if (card.Codigo is null || card.Codigo == "") 
                        myStringBuilder.Append("É necessário informar o código do cartão.;");
                    if (card.Cvv is null || card.Cvv == "") 
                        myStringBuilder.Append("É necessário informar o Cvv do cartão.;");
                    if (card.NomeImpresso is null || card.NomeImpresso == "") 
                        myStringBuilder.Append("É necessário informar o nome impresso no cartão.;");
                }
            }
            return myStringBuilder.ToString();
        }
    }
}
