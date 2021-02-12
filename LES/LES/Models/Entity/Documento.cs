using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.Entity
{
    public class Documento : EntidadeDominio
    {
        public String codigo { get; set; }
        public DateTime validade { get; set; }
        public TipoDocumento tipoDocumento { get; set; }

        public Documento() { }

        private void definirAtributos(String codigo, DateTime validade, TipoDocumento tipoDocumento)
        {
            this.codigo = codigo;
            this.validade = validade;
            this.tipoDocumento = tipoDocumento;
        }

        public Documento(String codigo, DateTime validade, TipoDocumento tipoDocumento) 
        {
            definirAtributos(codigo, validade, tipoDocumento);
        }

        public Documento(int id, DateTime dtCadastro, String codigo, DateTime validade, TipoDocumento tipoDocumento) : base(id, dtCadastro) 
        {
            definirAtributos(codigo, validade, tipoDocumento);
        }


    }
}
