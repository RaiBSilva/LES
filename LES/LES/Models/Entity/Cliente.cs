using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.Entity
{
    public class Cliente : Pessoa
    {
        public string Nome { get; set; }
        public IList<Endereco> Enderecos { get; set; }
        
        //Construtores
        public Cliente() { }

        public Cliente(int id) : base(id) { }

        private void DefinirAtributos(string nome, IList<Endereco> enderecos) {
            this.Nome = nome;
            this.Enderecos = enderecos;
        }

        public Cliente(string nome, IList<Endereco> enderecos) 
        {
            DefinirAtributos(nome, enderecos);
        }

        public Cliente(int id, DateTime dtCadastro, IList<Documento> documentos, string nome, IList<Endereco> enderecos) : base(id, dtCadastro, documentos) 
        {
            DefinirAtributos(nome, enderecos);
        }

    }
}
