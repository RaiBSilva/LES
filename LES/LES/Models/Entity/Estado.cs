using System;

namespace LES.Models.Entity
{
    public class Estado : EntidadeDominio
    {
        public String descricao { get; set; }
        public Estado() { }

        private void definirAtributos(String descricao)
        {
            this.descricao = descricao;
        }

        public Estado(String descricao) 
        {
            definirAtributos(descricao);
        }

        public Estado(int id, DateTime dtCadastro, String descricao) : base(id, dtCadastro)
        {
            definirAtributos(descricao);
        }


    }
}
