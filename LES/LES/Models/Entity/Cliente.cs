﻿using Microsoft.AspNetCore.Authentication;
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
        public string Nome { get; set; }
        public Genero Genero { get; set; }
        public Login Login { get; set; }
        public string Cpf { get; set; }
        public Telefone Telefone { get; set; }

        //Construtores
        public Cliente() { }

        public Cliente(int id) : base(id) { }

        private void DefinirAtributos(string nome, Genero genero, Login login, string cpf, Telefone telefone) 
        {
            Nome = nome;
            Genero = genero;
            Login = login;
            Cpf = cpf;
            Telefone = telefone;
        }

        public Cliente(string nome, Genero genero, Login login, string cpf, Telefone telefone)
        {
            DefinirAtributos(nome, genero, login, cpf, telefone);
        }

        public Cliente(int id, DateTime dtCadastro, string nome, Genero genero, 
            Login login, string cpf, Telefone telefone) : base(id, dtCadastro)
        {
            DefinirAtributos(nome, genero, login, cpf, telefone);
        }
    }
}
