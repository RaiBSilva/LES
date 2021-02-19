using System;

namespace LES.Models.Entity
{
    public class Estado : EntidadeDominio
    {
        public string Nome { get; set; }
        public Pais Pais { get; set; }

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
