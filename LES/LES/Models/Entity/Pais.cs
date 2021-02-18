using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.Entity
{
    public class Pais : EntidadeDominio
    {
        public string Descricao { get; set; }

        public Pais() { }

        public Pais(int id) : base(id) { }

        private void DefinirAtributos(string descricao)
        {
            this.Descricao = descricao;
        }

        public Pais(string descricao)
        {
            DefinirAtributos(descricao);
        }

        public Pais(int id, DateTime dtCadastro, string descricao) : base(id, dtCadastro)
        {
            DefinirAtributos(descricao);
        }

    }
}
