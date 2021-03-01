using Microsoft.AspNetCore.Authentication;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace LES.Models.Entity
{

    public enum Genero { 
        Masculino,
        Feminino,
        Outro
    }

    [Table("CLIENTES")]
    public class Cliente : EntidadeDominio
    {
        #region Propriedades

        [Required, Column("cli_nome")]
        public string Nome { get; set; }

        [Required, Column("cli_dt_nascimento")]
        public DateTime DtNascimento { get; set; }

        [Required, Column("cli_genero")]
        public Genero Genero { get; set; }

        [Required, Column("cli_email")]
        public string Email { get; set; }

        [Required, Column("cli_senha")]
        public string Senha { get; set; }

        [Required, Column("cli_cpf")]
        public string Cpf { get; set; }

        [Required, Column("cli_telefone"), ForeignKey("FK_CLI_TEL")]
        public virtual Telefone Telefone { get; set; }

        [Required, Column("cli_enderecos"), ForeignKey("FK_CLI_END")]
        public virtual IList<Endereco> Enderecos { get; set; }
        #endregion

        #region Construtores da Classe
        public Cliente() { }

        public Cliente(int id) : base(id) { }

        private void DefinirAtributos(string nome, DateTime dtNascimento, Genero genero, string email,
            string senha, string cpf, Telefone telefone, IList<Endereco> enderecos) 
        {
            Nome = nome;
            DtNascimento = dtNascimento;
            Genero = genero;
            Email = email;
            Senha = senha;
            Cpf = cpf;
            Telefone = telefone;
            Enderecos = enderecos;
        }

        public Cliente(string nome, DateTime dtNascimento, Genero genero, string email,
            string senha, string cpf, Telefone telefone, IList<Endereco> enderecos)
        {
            DefinirAtributos(nome, dtNascimento, genero, email, senha, cpf, telefone, enderecos);
        }

        public Cliente(int id, DateTime dtCadastro, string nome, DateTime dtNascimento, Genero genero, string email,
            string senha, string cpf, Telefone telefone, IList<Endereco> enderecos) : base(id, dtCadastro)
        {
            DefinirAtributos(nome, dtNascimento, genero, email, senha, cpf, telefone, enderecos);
        }

        #endregion
    }


}
