using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.Entity
{
    public class Documento : EntidadeDominio
    {
        public string Codigo { get; set; }
        public DateTime Validade { get; set; }
        public TipoDocumento TipoDocumento { get; set; }

        //Construtores
        public Documento() { }

        public Documento(int id) : base(id) { }

        private void DefinirAtributos(string codigo, DateTime validade, TipoDocumento tipoDocumento)
        {
            this.Codigo = codigo;
            this.Validade = validade;
            this.TipoDocumento = tipoDocumento;
        }

        public Documento(string codigo, DateTime validade, TipoDocumento tipoDocumento) 
        {
            DefinirAtributos(codigo, validade, tipoDocumento);
        }

        public Documento(int id, DateTime dtCadastro, string codigo, DateTime validade, TipoDocumento tipoDocumento) : base(id, dtCadastro) 
        {
            DefinirAtributos(codigo, validade, tipoDocumento);
        }


    }
}
