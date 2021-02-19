using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LES.Models.Entity
{
    public class EntidadeDominio
    {

        public int Id { get; set; }
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
