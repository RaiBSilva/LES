using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.Entity
{
    public class TipoEndereco : EntidadeDominio
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public TipoEndereco() { }

        public TipoEndereco(int id) : base(id) { }

        private void DefinirAtributos(string nome, string descricao)
        {
            this.Nome = nome;
            this.Descricao = descricao;
        }

        public TipoEndereco(string nome, string descricao)
        {
            DefinirAtributos(nome, descricao);
        }

        public TipoEndereco(string nome, string descricao, int id, DateTime dtCadastro) : base(id, dtCadastro)
        {
            DefinirAtributos(nome, descricao);
        }

    }
}
