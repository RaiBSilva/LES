using System;

namespace LES.Models.Entity
{
    public class Estado : EntidadeDominio
    {
        public string Descricao { get; set; }

        //Construtores
        public Estado() { }

        public Estado(int id) : base(id) { }

        private void DefinirAtributos(string descricao)
        {
            this.Descricao = descricao;
        }

        public Estado(string descricao) 
        {
            DefinirAtributos(descricao);
        }

        public Estado(int id, DateTime dtCadastro, string descricao) : base(id, dtCadastro)
        {
            DefinirAtributos(descricao);
        }


    }
}
