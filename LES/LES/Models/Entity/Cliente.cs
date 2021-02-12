using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.Entity
{
    public class Cliente : Pessoa
    {
        public String nome { get; set; }
        public IList<Endereco> enderecos { get; set; }

        public Cliente() { }

        public Cliente(int id) : base(id) { }

        private void definirAtributos(String nome, IList<Endereco> enderecos) {
            this.nome = nome;
            this.enderecos = enderecos;
        }

        public Cliente(String nome, IList<Endereco> enderecos) 
        {
            definirAtributos(nome, enderecos);
        }

        public Cliente(int id, DateTime dtCadastro, IList<Documento> documentos, String nome, IList<Endereco> enderecos) : base(id, dtCadastro, documentos) 
        {
            definirAtributos(nome, enderecos);
        }

    }
}
