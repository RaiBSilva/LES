using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;

namespace LES.Models.Entity
{
    public class TipoDocumento : EntidadeDominio
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public TipoDocumento() {}

        public TipoDocumento(int id) : base(id) { }

        private void DefinirAtributos(string nome, string descricao)
        {
            this.Nome = nome;
            this.Descricao = descricao;
        }

        public TipoDocumento(string nome, string descricao) 
        {
            DefinirAtributos(nome, descricao);
        }

        public TipoDocumento(string nome, string descricao, int id, DateTime dtCadastro) : base(id, dtCadastro)
        {
            DefinirAtributos(nome, descricao);
        }



    }
}
