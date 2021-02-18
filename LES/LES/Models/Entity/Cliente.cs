using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.Entity
{
    public class Cliente : Pessoa
    {
        public string Nome { get; set; }
        public IList<Endereco> EnderecosEntrega { get; set; }
        public IList<Endereco> EnderecosCobranca { get; set; }

        //Construtores
        public Cliente() { }

        public Cliente(int id) : base(id) { }

        private void DefinirAtributos(string nome, IList<Endereco> enderecosEntrega) {
            this.Nome = nome;
            this.EnderecosEntrega = enderecosEntrega;
        }

        public Cliente(string nome, IList<Endereco> enderecosEntrega) 
        {
            DefinirAtributos(nome, enderecos);
        }

        public Cliente(int id, DateTime dtCadastro, IList<Documento> documentos, string nome, IList<Endereco> enderecosEntrega) : base(id, dtCadastro, documentos) 
        {
            DefinirAtributos(nome, enderecos);
        }

    }
}
