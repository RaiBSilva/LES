using Microsoft.AspNetCore.Authentication;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
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

    public class Cliente : EntidadeDominio
    {
        #region Propriedades
        public string Nome { get; set; }
        public DateTime DtNascimento { get; set; }
        public Genero Genero { get; set; }
        public Login Login { get; set; }
        public string Cpf { get; set; }
        public Telefone Telefone { get; set; }
        public IList<Endereco> EnderecosCobranca { get; set; }
        public IList<Endereco> EnderecosEntrega { get; set; }
        public Endereco EnderecoResidencia { get; set; }
        #endregion

        #region Construtores da Classe
        public Cliente() { }

        public Cliente(int id) : base(id) { }

        private void DefinirAtributos(string nome, DateTime dtNascimento, Genero genero, 
            Login login, string cpf, Telefone telefone, IList<Endereco> enderecosCobranca, 
            IList<Endereco> enderecosEntrega, Endereco enderecoResidencia) 
        {
            Nome = nome;
            DtNascimento = dtNascimento;
            Genero = genero;
            Login = login;
            Cpf = cpf;
            Telefone = telefone;
            EnderecosCobranca = enderecosCobranca;
            EnderecosEntrega = enderecosEntrega;
            EnderecoResidencia = enderecoResidencia;
        }

        public Cliente(string nome, DateTime dtNascimento, Genero genero, Login login, string cpf,
            Telefone telefone, IList<Endereco> enderecosCobranca, IList<Endereco> enderecosEntrega, 
            Endereco enderecoResidencia)
        {
            DefinirAtributos(nome, dtNascimento, genero, login, cpf, telefone, enderecosCobranca, enderecosEntrega, enderecoResidencia);
        }

        public Cliente(int id, DateTime dtCadastro, string nome, DateTime dtNascimento, Genero genero, 
            Login login, string cpf, Telefone telefone, IList<Endereco> enderecosCobranca, 
            IList<Endereco> enderecosEntrega, Endereco enderecoResidencia) : base(id, dtCadastro)
        {
            DefinirAtributos(nome, dtNascimento, genero, login, cpf, telefone, enderecosCobranca, enderecosEntrega, enderecoResidencia);
        }

        #endregion
    }


}
