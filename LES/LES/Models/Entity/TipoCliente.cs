using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;

namespace LES.Models.Entity
{
    public class TipoCliente : EntidadeDominio
    {
        public string nome { get; set; }
        public string descricao { get; set; }

        //Construtores
        public TipoCliente() { }

        public TipoCliente(int id) : base(id) { }

        private void DefinirAtributos(string nome, string descricao)
        {
            this.nome = nome;
            this.descricao = descricao;
        }

        public TipoCliente(string nome, string descricao)
        {
            DefinirAtributos(nome, descricao);
        }

        public TipoCliente(string nome, string descricao, int id, DateTime dtCadastro) : base(id, dtCadastro)
        {
            DefinirAtributos(nome, descricao);
        }


    }
}
