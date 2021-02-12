using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.Entity
{
    public class TipoEndereco : EntidadeDominio
    {
        public String nome { get; set; }
        public String descricao { get; set; }

        public TipoEndereco() { }

        private void definirAtributos(String nome, String descricao)
        {
            this.nome = nome;
            this.descricao = descricao;
        }

        public TipoEndereco(String nome, String descricao)
        {
            definirAtributos(nome, descricao);
        }

        public TipoEndereco(String nome, String descricao, int id, DateTime dtCadastro) : base(id, dtCadastro)
        {
            definirAtributos(nome, descricao);
        }

    }
}
