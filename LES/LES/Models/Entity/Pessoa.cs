using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.Entity
{
    public class Pessoa : EntidadeDominio
    {
        public IList<Documento> documentos { get; set; }
        public Pessoa() { }

        public Pessoa(int id) : base(id) { }

        private void definirAtributos (IList<Documento> documentos) {
            this.documentos = documentos;
        }

        public Pessoa(IList<Documento> documentos) {
            definirAtributos(documentos);
        }

        public Pessoa(int id, DateTime dtCadastro, IList<Documento> documentos) : base(id, dtCadastro)
        {
            definirAtributos(documentos);
        }
    }
}
