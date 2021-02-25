using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LES.Models.Entity
{
    public class EntidadeDominio
    {
        [Key]
        [Required, Column("id")]
        public int Id { get; set; }

        [Required, Column("dt_cadastro")]
        public DateTime DtCadastro { get; set; }

        #region Construtores da Classe
        public EntidadeDominio() { }

        public EntidadeDominio(int id) 
        {
            this.Id = id;
        }

        public EntidadeDominio(int id, DateTime dtCadastro)
        {
            this.Id = id;
            this.DtCadastro = dtCadastro;
        }
        #endregion
    }
}
