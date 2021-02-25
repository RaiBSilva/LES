using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.Entity
{
    public enum TipoTelefone { 
        Celular,
        Fixo
    }

    [Table("TELEFONES")]
    public class Telefone : EntidadeDominio
    {
        [Required, Column("tel_tipo")]
        public TipoTelefone TipoTelefone { get; set; }

        [Required, Column("tel_ddd")]
        public string Ddd { get; set; }

        [Required, Column("tel_numero")]
        public string Numero { get; set; }

        #region Construtores de Classe
        public Telefone() 
        { }

        public Telefone(int id) : base(id) 
        { }

        public void DefinirAtributos(TipoTelefone tipo, string ddd, string numero) 
        {
            TipoTelefone = tipo;
            Ddd = ddd;
            Numero = numero;
        }

        public Telefone(TipoTelefone tipo, string ddd, string numero)
        {
            DefinirAtributos(tipo, ddd, numero);
        }

        public Telefone(int id, DateTime dtCadastro, TipoTelefone tipo, string ddd, string numero) : base(id, dtCadastro)
        {
            DefinirAtributos(tipo, ddd, numero);
        }
        #endregion
    }
}
