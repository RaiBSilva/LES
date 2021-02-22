using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.Entity
{
    public enum TipoTelefone { 
        Celular,
        Fixo
    }
    public class Telefone : EntidadeDominio
    {

        public TipoTelefone TipoTelefone { get; set; }

        public string Ddd { get; set; }

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
