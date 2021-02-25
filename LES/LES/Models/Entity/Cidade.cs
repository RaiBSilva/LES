using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace LES.Models.Entity
{
    [Table("CIDADES")]
    public class Cidade : EntidadeDominio
    {
        [Required, Column("cid_nome")]
        public string Nome { get; set; }

        [Required, Column("cid_est_id"), ForeignKey("FK_CID_EST")]
        public virtual Estado Estado { get; set; }

        #region Construtores da Classe
        public Cidade() { }

        public Cidade(int id) : base(id) { }

        private void DefinirAtributos(string nome, Estado estado) 
        {
            this.Nome = nome;
            this.Estado = estado;
        }

        public Cidade(string nome, Estado estado)
        {
            DefinirAtributos(nome, estado);
        }

        public Cidade(int id, DateTime dtCadastro, string nome, Estado estado) : base(id, dtCadastro) 
        {
            DefinirAtributos(nome, estado);
        }
        #endregion


    }
}
