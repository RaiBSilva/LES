using System;

namespace LES.Models.Entity
{
    public class Estado : EntidadeDominio
    {
        public string Descricao { get; set; }

        public Pais Pais { get; set; }

        //Construtores
        public Estado() { }

        public Estado(int id) : base(id) { }

        private void DefinirAtributos(string descricao, Pais pais)
        {
            this.Descricao = descricao;
        }

        public Estado(string descricao, Pais pais) 
        {
            DefinirAtributos(descricao, pais);
        }

        public Estado(int id, DateTime dtCadastro, string descricao, Pais pais) : base(id, dtCadastro)
        {
            DefinirAtributos(descricao, pais);
        }


    }
}
