using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LES.Models.Entity
{
    [Table("ESTADOS")]
    public class Estado : EntidadeDominio
    {
        [Required, Column("est_nome")]
        public string Nome { get; set; }
        [Required, Column("est_pai_id"), ForeignKey("FK_EST_PAI")]
        public virtual Pais Pais { get; set; }

        #region Construtores da Classe
        public Estado() { }

        public Estado(int id) : base(id) { }

        private void DefinirAtributos(string descricao, Pais pais)
        {
            Nome = descricao;
            Pais = pais;
        }

        public Estado(string descricao, Pais pais) 
        {
            DefinirAtributos(descricao, pais);
        }

        public Estado(int id, DateTime dtCadastro, string descricao, Pais pais) : base(id, dtCadastro)
        {
            DefinirAtributos(descricao, pais);
        }
        #endregion

    }
}
