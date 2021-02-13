using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.Entity
{
    public class Pessoa : EntidadeDominio
    {
        public IList<Documento> Documentos { get; set; }

        //Construtores
        public Pessoa() { }

        public Pessoa(int id) : base(id) { }

        private void DefinirAtributos (IList<Documento> documentos) {
            this.Documentos = documentos;
        }

        public Pessoa(IList<Documento> documentos) {
            DefinirAtributos(documentos);
        }

        public Pessoa(int id, DateTime dtCadastro, IList<Documento> documentos) : base(id, dtCadastro)
        {
            DefinirAtributos(documentos);
        }
    }
}
