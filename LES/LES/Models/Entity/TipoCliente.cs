using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;

namespace LES.Models.Entity
{
    public class TipoCliente : EntidadeDominio
    {
        public String nome { get; set; }
        public String descricao { get; set; }

        public TipoCliente() { }

        private void definirAtributos(String nome, String descricao)
        {
            this.nome = nome;
            this.descricao = descricao;
        }

        public TipoCliente(String nome, String descricao)
        {
            definirAtributos(nome, descricao);
        }

        public TipoCliente(String nome, String descricao, int id, DateTime dtCadastro) : base(id, dtCadastro)
        {
            definirAtributos(nome, descricao);
        }


    }
}
