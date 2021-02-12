using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;

namespace LES.Models.Entity
{
    public class TipoDocumento : EntidadeDominio
    {
        public String nome { get; set; }
        public String descricao { get; set; }

        public TipoDocumento() {}

        private void definirAtributos(String nome, String descricao)
        {
            this.nome = nome;
            this.descricao = descricao;
        }

        public TipoDocumento(String nome, String descricao) 
        {
            definirAtributos(nome, descricao);
        }

        public TipoDocumento(String nome, String descricao, int id, DateTime dtCadastro) : base(id, dtCadastro)
        {
            definirAtributos(nome, descricao);
        }



    }
}
