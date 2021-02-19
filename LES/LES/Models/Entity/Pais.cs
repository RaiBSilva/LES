using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.Entity
{
    public class Pais : EntidadeDominio
    {
        public string Nome { get; set; }

        #region Construtores da Classe
        public Pais() { }

        public Pais(int id) : base(id) { }

        private void DefinirAtributos(string descricao)
        {
            this.Nome = descricao;
        }

        public Pais(string descricao)
        {
            DefinirAtributos(descricao);
        }

        public Pais(int id, DateTime dtCadastro, string descricao) : base(id, dtCadastro)
        {
            DefinirAtributos(descricao);
        }
        #endregion
    }
}
