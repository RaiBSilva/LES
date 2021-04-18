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
        public ValidaClienteNullStrategy()
        {
            

        }

        public string Validar(EntidadeDominio e)
        {
            Cliente cliente = (Cliente)e;
            StringBuilder myStringBuilder = new StringBuilder("");

            if (cliente.Nome is null) myStringBuilder.Append("O campo Nome é obrigatório.;");

            if (cliente.Telefones is null) myStringBuilder.Append("É necessario informar um Telefone.;");
            foreach (Telefone tel in cliente.Telefones)
            {
                if(tel.Ddd is null) myStringBuilder.Append("É necessario informar o Ddd.;");
                if(tel.Numero is null) myStringBuilder.Append("É necessario informar o numero do telefone.;");
            }
            if (cliente.Usuario.Email is null) myStringBuilder.Append("É necessario informar um E-mail.;");
            if (cliente.Usuario.Senha is null) myStringBuilder.Append("É necessario informar uma Senha.;");
            if (cliente.Cpf is null) myStringBuilder.Append("É necessario informar o Cpf.;");
            foreach (Endereco end in cliente.Enderecos)
            {
                if (end.Cep is null) myStringBuilder.Append("O campo Cep é obrigatório.;");
                if (end.Cidade.Estado.Nome is null) myStringBuilder.Append("O campo Estado é obrigatório.;");
                if (end.Cidade.Estado.Pais.Nome is null) myStringBuilder.Append("O campo Pais é obrigatório.;");
                if (end.Cidade.Nome is null) myStringBuilder.Append("O campo Cidade é obrigatório.;");
                if (end.Logradouro is null) myStringBuilder.Append("O campo Logradouro é obrigatório.;");
                if (end.Numero is null) myStringBuilder.Append("O Numero da residencia deve ser informado.;");
            }

            return myStringBuilder.ToString();
        }
    }
}
