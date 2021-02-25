using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.Entity
{
    [Table("PAISES")]
    public class Pais : EntidadeDominio
    {
        [Required, Column("pai_nome")]
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
